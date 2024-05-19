using PUMP.core.BL.Interfaces;
using PUMP.models;

namespace PUMP.core.BL.Services;

public class MembershipsServices : IMemberships
{
        public Task<bool> Create(Memberships memberships)
    {
        bool result = false;
        using (var connection = new data.SQLServer.InitDb())
        {
            var query = (
                from item in connection.Memberships
                where item.Id == memberships.Id
                select item
            ).FirstOrDefault();

            if (query == null)
            {
                Memberships mship = new Memberships();
                mship.Id = memberships.Id;
                mship.Member = memberships.Member;
                mship.DateStart = memberships.DateStart;
                mship.DateEnd = memberships.DateEnd;
                connection.Memberships.Add(mship);
                result = connection.SaveChanges() > 0;
            }
        }

        return Task.FromResult(result);
    }

    public Task<List<Memberships>> Read()
    {
        List<Memberships> list = new List<Memberships>();
        using (var connection = new data.SQLServer.InitDb())
        {
            var query = (
                from item in connection.Memberships
                select item
            ).ToList();

            foreach (var item in query)
            {
                list.Add(new Memberships()
                {
                    Id = item.Id,
                    Member = item.Member,
                    DateStart = item.DateStart,
                    DateEnd = item.DateEnd
                });
            }
            
            return Task.FromResult(list);
        }
        
    }

    public Task<bool> Update(Memberships memberships)
    {
        bool result = false;
        using (var connection = new data.SQLServer.InitDb())
        {
            var query = (
                from item in connection.Memberships
                where item.Id == memberships.Id
                select item
            ).FirstOrDefault();

            if (query != null)
            {
                query.Id = memberships.Id;
                query.Member = memberships.Member;
                query.DateStart = memberships.DateStart;
                query.DateEnd = memberships.DateEnd;
                result = connection.SaveChanges() > 0;
            }
        }

        return Task.FromResult(result);
    }

    public Task<bool> Delete(Memberships memberships)
    {
        bool result = false;
        using (var connection = new data.SQLServer.InitDb())
        {
            var query = (
                from item in connection.Memberships
                where item.Id == memberships.Id
                select item
            ).FirstOrDefault();

            if (query != null)
            {
                connection.Memberships.Remove(query);
                result = connection.SaveChanges() > 0;
            }
        }

        return Task.FromResult(result);
    }
}