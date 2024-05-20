using PUMP.core.BL.Interfaces;
using PUMP.models;

namespace PUMP.core.BL.Services;

public class DetailMembershipsServices : IDetailMemberships
{
    public Task<bool> Create(DetailMemberships detailMemberships)
    {
        bool result = false;
        using (var connection = new data.SQLServer.InitDb())
        {
            var query = (
                from item in connection.DetailMemberships
                where item.Id == detailMemberships.Id
                select item
            ).FirstOrDefault();

            if (query == null)
            {
                DetailMemberships dm = new DetailMemberships();
                dm.Id = detailMemberships.Id;
                dm.Membership = detailMemberships.Membership;
                dm.Employee = detailMemberships.Employee;
                dm.Price = detailMemberships.Price;
                connection.DetailMemberships.Add(dm);
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
                var query = (from item in connection.DetailMemberships
                    where item.Id == id.Value
                    select new
                    {
                        item.Id,
                        item.Membership,
                        item.Employee,
                        item.Price
                    }).FirstOrDefault();
                return Task.FromResult<object?>(query);
            }

            if (id == null)
            {
                var query = (
                    from item in connection.DetailMemberships
                    select new
                    {
                        item.Id,
                        item.Membership,
                        item.Employee,
                        item.Price
                    }).ToList();
                
                return Task.FromResult<object?>(query);
            }
            else
            {
                return Task.FromResult<object?>(null);
            }
        }
    }

    public Task<bool> Update(DetailMemberships detailMemberships)
    {
        bool result = false;
        using (var connection = new data.SQLServer.InitDb())
        {
            var query = (
                from item in connection.DetailMemberships
                where item.Id == detailMemberships.Id
                select item
            ).FirstOrDefault();

            if (query != null)
            {
                query.Id = detailMemberships.Id;
                query.Membership = detailMemberships.Membership;
                query.Employee = detailMemberships.Employee;
                query.Price = detailMemberships.Price;
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
                from item in connection.DetailMemberships
                where item.Id == id.Value
                select item
            ).FirstOrDefault();

            if (query != null)
            {
                connection.DetailMemberships.Remove(query);
                result = connection.SaveChanges() > 0;
            }
        }

        return Task.FromResult(result);
    }    
}