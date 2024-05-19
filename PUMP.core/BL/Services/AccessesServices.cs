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

    public Task<List<Accesses>> Read()
    {
        List<Accesses> list = new List<Accesses>();
        using (var connection = new data.SQLServer.InitDb())
        {
            var query = (
                from item in connection.Accesses
                select item
            ).ToList();

            foreach (var item in query)
            {
                list.Add(new Accesses()
                {
                    Id = item.Id,
                    Membership = item.Membership,
                    DateSa = item.DateSa
                });
            }
            
            return Task.FromResult(list);
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