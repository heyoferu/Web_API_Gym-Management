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

    public Task<List<Category>> Read()
    {
        List<Category> list = new List<Category>();
        using (var connection = new data.SQLServer.InitDb())
        {
            var query = (
                from item in connection.Category
                select item
            ).ToList();

            foreach (var item in query)
            {
                list.Add(new Category()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description
                });
            }
            
            return Task.FromResult(list);
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

    public Task<bool> Delete(Category category)
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
                connection.Category.Remove(query);
                result = connection.SaveChanges() > 0;
            }
        }

        return Task.FromResult(result);
    }
}