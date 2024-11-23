using Microsoft.EntityFrameworkCore;
using EnergyAPI.Data;
using EnergyAPI.Models;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Adicionar o DbContext com a conexão com o Oracle
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("FiapOracleConnection")));

// Adicionar serviços ao contêiner
builder.Services.AddControllers();

// Configuração do Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new OpenApiInfo {
        Title = "EnergyAPI",
        Version = "v1",
        Description = "API para gerenciamento de dispositivos e predição de consumo de energia",
        Contact = new OpenApiContact {
            Name = "João Vitor Souza Nunes",
            Email = "joaovitorsouza546@gmail.com",
            Url = new Uri("https://seu-site.com")
        }
    });
});

var app = builder.Build();

// Configuração do pipeline de requisição HTTP
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "EnergyAPI v1");
        c.RoutePrefix = string.Empty; // Swagger na raiz do projeto (ex: http://localhost:5000)
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
