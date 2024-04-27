using PUMP.core.BL.Interfaces;
using PUMP.models;

namespace PUMP.core.BL.Services;

public class MembersServices : IMembers
{
    public Task<bool> Save(Members members)
    {
        bool result = false;

        using (var connection = new data.SQLServer.InitDb())
        {
            var query = (
                from item in connection.Members
                where item.Id == members.Id
                select item
            ).FirstOrDefault();
            if (query == null)
            {
                Members mbr = new Members();
                mbr.Id = members.Id;
                mbr.Name = members.Name;
                mbr.Lastname = members.Lastname;
                mbr.Age = members.Age;
                mbr.Mail = members.Mail;
                connection.Members.Add(mbr);
                result = connection.SaveChanges() > 0;
            }
        }

        return Task.FromResult(result);
    }

    public Task<List<Members>> Get()
    {
        List<Members> list = new List<Members>();
        using (var connection = new data.SQLServer.InitDb())
        {
            var query = (
                from item in connection.Members
                select item
            ).ToList();

            foreach (var item in query)
            {
                list.Add(new Members()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Lastname = item.Lastname,
                    Age = item.Age,
                    Mail = item.Mail,
                });
            }
            
            return Task.FromResult(list);
        }
    }

    public Task<bool> Update(Members members)
    {
        bool result = false;
        using (var connection = new data.SQLServer.InitDb())
        {
            var query = (
                from item in connection.Members
                where item.Id == members.Id
                select item
            ).FirstOrDefault();

            if (query != null)
            {
                query.Id = members.Id;
                query.Name = members.Name;
                query.Lastname = members.Lastname;
                query.Age = members.Age;
                query.Mail = members.Mail;
                result = connection.SaveChanges() > 0;
            }
        }

        return Task.FromResult(result);
    }

    public Task<bool> Delete(Members members)
    {
        bool result = false;
        using (var connection = new data.SQLServer.InitDb())
        {
            var query = (
                from item in connection.Members
                where item.Id == members.Id
                select item
            ).FirstOrDefault();

            if (query != null)
            {
                connection.Members.Remove(query);
                result = connection.SaveChanges() > 0;
            }
        }

        return Task.FromResult(result);    }
}