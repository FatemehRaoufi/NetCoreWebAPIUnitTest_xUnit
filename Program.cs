using Microsoft.AspNetCore.Mvc;
using NetCoreWebAPIUnitTest_xUnit.Model;
using NetCoreWebAPIUnitTest_xUnit.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
//Customized Map
//app.MapPut("/employee/{id}", ([FromServices] IEmployeeService db, Employee employee) =>
//{
//    return db.Add(employee);
//});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//https://sd.blackball.lv/en/articles/read/18991-unit-testing-in-net-6-web-api-using-xunit#:~:text=Unit%20testing%20is%20one%20of,code%20during%20your%20development%20phases.
//https://github.com/shubhadeepchat/UnitTestCaseDemo