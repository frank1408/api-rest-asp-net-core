
using Microsoft.EntityFrameworkCore;
using ProyectoApi.Repositories;






var builder = WebApplication.CreateBuilder(args);



// CORS paso 1/3
var OrigenPermitido = "_origenPermitido";
// CORS paso 1/3



// CORS paso 2/3
builder.Services.AddCors(
  opciones => opciones.AddPolicy(name: OrigenPermitido, policy =>
  {
    policy.WithOrigins("*")
		.AllowAnyHeader()
		.AllowAnyMethod();
  })
);
// CORS paso 2/3








builder.Services.AddControllers();

// swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// swagger

builder.Services.AddRouting( routing => routing.LowercaseUrls = true );


builder.Services.AddDbContext<CustomerContext>( mysqlBuilder =>
{

	mysqlBuilder.UseMySQL( builder.Configuration.GetConnectionString("urlconexionmysql")    );

});


// para inyectar dependencia que implementa interfaz
builder.Services.AddScoped<ICustomerContext, CustomerContext>();




var app = builder.Build();


// CORS paso 3/3
app.UseCors(OrigenPermitido);
// CORS paso 3/3


if (app.Environment.IsDevelopment())
{
// swagger
app.UseSwagger();
app.UseSwaggerUI();
// swagger
}






app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();


app.Run();

