using BackendExam.ApplicationContract.Enums;
using BackendExam.Domain.Entities;
using BackendExam.Persistence.Context;
using Bogus;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BackendExam.Persistence.Seed
{
    public static class DataSeed
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();

            var context = scope.ServiceProvider.GetService<SqlServerDbContext>();

            context.Database.Migrate();

            if(context.Employees.Any())
            {
                context.Database.ExecuteSqlRaw("DELETE FROM WorkLogs");
                context.Database.ExecuteSqlRaw("DELETE FROM Employees");
                context.SaveChanges();
            }

            if (context.Employees.Count() == 0)
            {
                for (int i = 0; i <= 10; i++)
                {
                    var data = new Faker<Employee>()
                    .RuleFor(f => f.IdentityNo, a => a.Random.Double(10000000000, 99999999999).ToString())
                    .RuleFor(f => f.Name, a => a.Name.FirstName(Bogus.DataSets.Name.Gender.Male))
                    .RuleFor(f => f.Surname, a => a.Name.LastName(Bogus.DataSets.Name.Gender.Male))
                    .RuleFor(f => f.Salary, a => a.Random.Int(1000, 20000))
                    .RuleFor(f => f.WorkType, a => (eWorkType)a.Random.Byte(0, 2));

                    Employee output = data.Generate();

                    context.Employees.Add(output);

                    context.SaveChanges();

                    for (int j = 0; j <= 10; j++)
                    {
                        var startWork = new DateTime(DateTime.Now.Year, DateTime.Now.Month, j + 1, 9, 0, 0, 0, 0);
                        var endWork = new DateTime(DateTime.Now.Year, DateTime.Now.Month, j + 1, new Random().Next(15, 20), 0, 0, 0, 0);

                        WorkLog workLog = new WorkLog()
                        {
                            EmployeeId = output.Id,
                            StartDate = startWork,
                            EndDate = endWork,
                            Description = "Test çalışma kaydı"
                        };

                        context.WorkLogs.Add(workLog);
                    }
                }
            }

            context.SaveChanges();
        }
    }
}
