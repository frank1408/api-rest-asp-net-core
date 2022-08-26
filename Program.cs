
using Microsoft.EntityFrameworkCore;
using ProyectoApi.Repositories;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen();


builder.Services.AddRouting( routing => routing.LowercaseUrls = true );


builder.Services.AddDbContext<CustomerContext>( mysqlBuilder =>
{

	mysqlBuilder.UseMySQL( builder.Configuration.GetConnectionString("urlconexionmysql")    );

});


// para inyectar dependencia que implementa interfaz
builder.Services.AddScoped<ICustomerContext, CustomerContext>();




var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();


app.UseAuthorization();


app.MapControllers();


app.Run();

