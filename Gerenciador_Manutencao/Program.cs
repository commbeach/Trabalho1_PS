using Controle_Manutencao.Repository;
using Gerenciador_Manutencao.Data;
using Gerenciador_Manutencao.Repository.Implementacao;
using Microsoft.EntityFrameworkCore;
using Controle_Manutencao.Service; 

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseInMemoryDatabase(databaseName: "TestDb"),
    ServiceLifetime.Scoped
);


// Registro dos repositories
builder.Services.AddScoped<IEquipamentoRep, EquipamentoRep>();
builder.Services.AddScoped<IItemRep, ItemRep>();
builder.Services.AddScoped<IManutencaoRep, ManutencaoRep>();
builder.Services.AddScoped<IModeloRep, ModeloRep>();
//builder.Services.AddScoped<IOrdemServicoRep, OrdemServicoRep>();

// Registro do serviço EquipamentoService
builder.Services.AddScoped<IEquipamentoService, EquipamentoService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IManutencaoService, ManutencaoService>();
builder.Services.AddScoped<IModeloService, ModeloService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
