using Microsoft.EntityFrameworkCore;
using NihonItarareApi.Context;
using NihonItarareApi.Repository.Estoques;
using NihonItarareApi.Repository.Itens;
using NihonItarareApi.Repository.Mesas;
using NihonItarareApi.Repository.Pedidos;
using NihonItarareApi.Repository.Produtos;
using NihonItarareApi.Services.Estoques;
using NihonItarareApi.Services.Itens;
using NihonItarareApi.Services.Mesas;
using NihonItarareApi.Services.Produtos;

var builder = WebApplication.CreateBuilder(args);

string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection") ?? "";
builder.Services.AddDbContextPool<AppDbContext>(op => op.UseNpgsql(mySqlConnection));
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IEstoqueService, EstoqueService>();
builder.Services.AddScoped<IEstoqueRepository, EstoqueRepository>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IMesaService, MesaService>();
builder.Services.AddScoped<IMesaRepository, MesaRepository>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
