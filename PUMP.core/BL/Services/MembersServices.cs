using PUMP.core.BL.Interfaces;
using PUMP.models;

namespace PUMP.core.BL.Services;

public class MembersServices : IMembers
{
    public Task<bool> Create(Members members)
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

    public Task<object?> Read(int? id)
    {
        using (var connection = new data.SQLServer.InitDb())
        {
            if (id.HasValue)
            {
                var query = (from item in connection.Members
                    where item.Id == id.Value
                    select new
                    {
                        item.Id,
                        item.Name,
                        item.Lastname,
                        item.Age,
                        item.Mail
                    }).FirstOrDefault();
                return Task.FromResult<object?>(query);
            }

            if (id == null)
            {
                var query = (
                    from item in connection.Members
                    select new
                    {
                        item.Id,
                        item.Name,
                        item.Lastname,
                        item.Age,
                        item.Mail
                    }).ToList();
                
                return Task.FromResult<object?>(query);
            }
            else
            {
                return Task.FromResult<object?>(null);
            }
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

    public Task<bool> Delete(int? id)
    {
        bool result = false;
        using (var connection = new data.SQLServer.InitDb())
        {
            var query = (
                from item in connection.Members
                where item.Id == id.Value
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