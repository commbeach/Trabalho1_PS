using Controle_Manutencao.Repository;
using Gerenciador_Manutencao.Data;
using Gerenciador_Manutencao.Repository.Implementacao;
using Microsoft.EntityFrameworkCore;

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
builder.Services.AddScoped<IOrdemServicoRep, OrdemServicoRep>();

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

