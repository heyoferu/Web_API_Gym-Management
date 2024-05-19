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

    public Task<List<Employees>> Read()
    {
        List<Employees> list = new List<Employees>();
        using (var connection = new data.SQLServer.InitDb())
        {
            var query = (
                from item in connection.Employees
                select item
            ).ToList();

            foreach (var item in query)
            {
                list.Add(new Employees()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Lastname = item.Lastname,
                        Age = item.Age,
                    });
            }
            
            return Task.FromResult(list);
        }
    }
}