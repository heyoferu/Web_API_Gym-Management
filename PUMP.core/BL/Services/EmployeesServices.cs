using PUMP.core.BL.Interfaces;
using PUMP.models;

namespace PUMP.core.BL.Services;

public class EmployeesServices : IEmployees
{
    public Task<bool> SaveEmployees(Employees employees)
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
                emp.Mail = employees.Mail;
                emp.Password = employees.Password;
                connection.Employees.Add(emp);
                result = connection.SaveChanges() > 0;
            }
        }

        return Task.FromResult(result);
    }

    public Task<bool> DeleteEmployees(Employees employees)
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

    public Task<bool> UpdateEmployees(Employees employees)
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
                query.Mail = employees.Mail;
                query.Password = employees.Password;
                result = connection.SaveChanges() > 0;
            }
        }

        return Task.FromResult(result);
    }

    public Task<List<Employees>> GetEmployees()
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
                        Mail = item.Mail,
                        Password = item.Password,
                        
                    });
            }
            
            return Task.FromResult(list);
        }
    }
}