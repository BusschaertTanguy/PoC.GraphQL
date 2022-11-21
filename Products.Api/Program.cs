using Products.Application.Extensions;
using Products.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationLayer()
    .AddInfrastructureLayer(builder.Configuration)
    .AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.CustomSchemaIds(s => s.FullName!.Replace("+", ".")));

builder.Services.AddCors(options => options.AddPolicy("CustomPolicy", policyBuilder => policyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CustomPolicy");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapGraphQL();
app.Run();