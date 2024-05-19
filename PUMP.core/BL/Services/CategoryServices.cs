using PUMP.core.BL.Interfaces;
using PUMP.models;

namespace PUMP.core.BL.Services;

public class CategoryServices : ICategory
{    
    public Task<bool> Create(Category category)
    {
        bool result = false;
        using (var connection = new data.SQLServer.InitDb())
        {
            var query = (
                from item in connection.Category
                where item.Id == category.Id
                select item
            ).FirstOrDefault();

            if (query == null)
            {
                Category cat = new Category();
                cat.Id = category.Id;
                cat.Name = category.Name;
                cat.Description = category.Description;
                connection.Category.Add(cat);
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
                var query = (from item in connection.Category
                    where item.Id == id.Value
                    select new
                    {
                        item.Id,
                        item.Name,
                        item.Description
                    }).FirstOrDefault();
                return Task.FromResult<object?>(query);
            }

            if (id == null)
            {
                var query = (
                    from item in connection.Category
                    select new
                    {
                        item.Id,
                        item.Name,
                        item.Description
                    }).ToList();
                
                return Task.FromResult<object?>(query);
            }
            else
            {
                return Task.FromResult<object?>(null);
            }
        }
    }

    public Task<bool> Update(Category category)
    {
        bool result = false;
        using (var connection = new data.SQLServer.InitDb())
        {
            var query = (
                from item in connection.Category
                where item.Id == category.Id
                select item
            ).FirstOrDefault();

            if (query != null)
            {
                query.Id = category.Id;
                query.Name = category.Name;
                query.Description = category.Description;
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
                from item in connection.Category
                where item.Id == id.Value
                select item
            ).FirstOrDefault();

            if (query != null)
            {
                connection.Category.Remove(query);
                result = connection.SaveChanges() > 0;
            }
        }

        return Task.FromResult(result);
    }
}