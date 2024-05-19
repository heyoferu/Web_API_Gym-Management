using PUMP.core.BL.Interfaces;
using PUMP.models;

namespace PUMP.core.BL.Services;

public class AccessesServices : IAccesses
{
    public Task<bool> Create(Accesses accesses)
    {
        bool result = false;
        using (var connection = new data.SQLServer.InitDb())
        {
            var query = (
                from item in connection.Accesses
                where item.Id == accesses.Id
                select item
            ).FirstOrDefault();

            if (query == null)
            {
                Accesses acc = new Accesses();
                acc.Id = accesses.Id;
                acc.Membership = accesses.Membership;
                acc.DateSa = accesses.DateSa;
                connection.Accesses.Add(acc);
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
                var query = (from item in connection.Accesses
                    where item.Id == id.Value
                    select new
                    {
                        item.Id,
                        item.Membership,
                        item.DateSa
                    }).FirstOrDefault();
                return Task.FromResult<object?>(query);
            }

            if (id == null)
            {
                var query = (
                    from item in connection.Accesses
                    select new
                    {
                        item.Id,
                        item.Membership,
                        item.DateSa
                    }).ToList();
                
                return Task.FromResult<object?>(query);
            }
            else
            {
                return Task.FromResult<object?>(null);
            }
        }
    }

    public Task<bool> Update(Accesses accesses)
    {
        bool result = false;
        using (var connection = new data.SQLServer.InitDb())
        {
            var query = (
                from item in connection.Accesses
                where item.Id == accesses.Id
                select item
            ).FirstOrDefault();

            if (query != null)
            {
                query.Id = accesses.Id;
                query.Membership = accesses.Membership;
                query.DateSa = accesses.DateSa;
                result = connection.SaveChanges() > 0;
            }
        }

        return Task.FromResult(result);
    }

    public Task<bool> Delete(Accesses accesses)
    {
        bool result = false;
        using (var connection = new data.SQLServer.InitDb())
        {
            var query = (
                from item in connection.Accesses
                where item.Id == accesses.Id
                select item
            ).FirstOrDefault();

            if (query != null)
            {
                connection.Accesses.Remove(query);
                result = connection.SaveChanges() > 0;
            }
        }

        return Task.FromResult(result);
    }
}