using ProyectoBackend_Chiqui.Data;
using ProyectoBackend_Chiqui.Data.Repositories.EmailData;
using ProyectoBackend_Chiqui.Data.Repositories.LoginData;
using ProyectoBackend_Chiqui.Data.Repositories.UsuarioData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mySQLConfiguration = new MySQLConfiguration(builder.Configuration.GetConnectionString("MySqlConnection"));
builder.Services.AddSingleton(mySQLConfiguration);

var emailConfiguration = new EmailConfiguration(builder.Configuration.GetSection("Email:Host").Value, 
    builder.Configuration.GetSection("Email:Port").Value,
    builder.Configuration.GetSection("Email:UserName").Value,
    builder.Configuration.GetSection("Email:Password").Value);
builder.Services.AddSingleton(emailConfiguration);

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<IEmailRepository, EmailRepository>();

var app = builder.Build();

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
