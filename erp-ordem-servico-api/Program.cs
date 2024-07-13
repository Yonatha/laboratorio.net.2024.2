using erp_ordem_servico_api.Domain.Entities;
using erp_ordem_servico_api.Dto.Atividade;
using erp_ordem_servico_api.Infrastructure.Persistence;
using erp_ordem_servico_api.Infrastructure.Persistence.Repositories;
using erp_ordem_servico_api.Infrastructure.Services;
using erp_ordem_servico_api.Infrastructure.Services.Atividade;
using erp_ordem_servico_api.Infrastructure.Services.OrdemServico;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<ErpDbContext>();
builder.Services.AddScoped<IOrdemServicoService, OrdemServicoService>();

builder.Services.AddScoped(typeof(IGenericService<,,>), typeof(GenericService<,,>));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


builder.Services.AddScoped<AtividadeService>();

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