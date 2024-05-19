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

    public Task<object?> Read(int? id)
    {
        using (var connection = new data.SQLServer.InitDb())
        {
            if (id.HasValue)
            {
                var query = (from item in connection.Memberships
                    where item.Id == id.Value
                    select new
                    {
                        item.Id,
                        item.Member,
                        item.DateStart,
                        item.DateEnd
                    }).FirstOrDefault();
                return Task.FromResult<object?>(query);
            }

            if (id == null)
            {
                var query = (
                    from item in connection.Memberships
                    select new
                    {
                        item.Id,
                        item.Member,
                        item.DateStart,
                        item.DateEnd
                    }).ToList();
                
                return Task.FromResult<object?>(query);
            }
            else
            {
                return Task.FromResult<object?>(null);
            }
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