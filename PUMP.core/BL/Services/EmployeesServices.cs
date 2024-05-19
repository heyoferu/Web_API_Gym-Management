using PUMP.core.BL.Interfaces;
using PUMP.models;

namespace PUMP.core.BL.Services;

public class EmployeesServices : IEmployees
{
    public Task<bool> Create(Employees employees)
    {
        bool result = false;
        using (var connection = new data.SQLServer.InitDb())
        {
            var query = (
                from item in connection.Employees
                where item.Id == employees.Id
                select item
            ).FirstOrDefault();

            if (query == null)
            {
                Employees emp = new Employees();
                emp.Id = employees.Id;
                emp.Name = employees.Name;
                emp.Lastname = employees.Lastname;
                emp.Age = employees.Age;
                connection.Employees.Add(emp);
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
                var query = (from item in connection.Employees
                    where item.Id == id.Value
                    select new
                    {
                        item.Id,
                        item.Name,
                        item.Lastname,
                        item.Age
                    }).FirstOrDefault();
                return Task.FromResult<object?>(query);
            }

            if (id == null)
            {
                var query = (
                    from item in connection.Employees
                    select new
                    {
                        item.Id,
                        item.Name,
                        item.Lastname,
                        item.Age
                    }).ToList();
                
                return Task.FromResult<object?>(query);
            }
            else
            {
                return Task.FromResult<object?>(null);
            }
        }
    }

    public Task<bool> Update(Employees employees)
    {
        bool result = false;
        using (var connection = new data.SQLServer.InitDb())
        {
            var query = (
                from item in connection.Employees
                where item.Id == employees.Id
                select item
            ).FirstOrDefault();

            if (query != null)
            {
                query.Id = employees.Id;
                query.Name = employees.Name;
                query.Lastname = employees.Lastname;
                query.Age = employees.Age;
                result = connection.SaveChanges() > 0;
            }
        }

        return Task.FromResult(result);
    }
    
    public Task<bool> Delete(Employees employees)
    {
        bool result = false;
        using (var connection = new data.SQLServer.InitDb())
        {
            var query = (
                from item in connection.Employees
                where item.Id == employees.Id
                select item
            ).FirstOrDefault();

            if (query != null)
            {
                connection.Employees.Remove(query);
                result = connection.SaveChanges() > 0;
            }
        }

        return Task.FromResult(result);
    }

}
