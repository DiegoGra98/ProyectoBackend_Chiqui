using ProyectoBackend_Chiqui.Data;
using ProyectoBackend_Chiqui.Data.Repositories.CategoriaData;
using ProyectoBackend_Chiqui.Data.Repositories.EmailData;
using ProyectoBackend_Chiqui.Data.Repositories.LoginData;
using ProyectoBackend_Chiqui.Data.Repositories.ProveedorData;
using ProyectoBackend_Chiqui.Data.Repositories.RolData;
using ProyectoBackend_Chiqui.Data.Repositories.RolPaginaData;
using ProyectoBackend_Chiqui.Data.Repositories.UsuarioData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

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
builder.Services.AddScoped<IRolRepository, RolRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IProveedorRepository, ProveedorRepository>();
builder.Services.AddScoped<IRolPaginaRepository, RolPaginaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Aplicar la política de CORS antes de la autorización
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

try
{
    app.Run();
}
catch (Exception ex)
{
    // Aquí puedes registrar o imprimir el error
    Console.WriteLine($"Error al iniciar la aplicación: {ex.Message}");
}
