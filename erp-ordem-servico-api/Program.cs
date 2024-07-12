using LaboratorioDev.Data;
using LaboratorioDev.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<ErpDbContext>();
builder.Services.AddScoped<IOrdemServicoService, OrdemServicoService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddSingleton<OrdemServicoAdapter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseHttpsRedirection();
app.Run();