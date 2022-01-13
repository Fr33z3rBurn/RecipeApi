using RecipeApi.Models;
using RecipeApi.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.Configure<RecipeDatabaseSettings>(
				builder.Configuration.GetSection(nameof(RecipeDatabaseSettings)));

builder.Services.Configure<UserDatabaseSettings>(
				builder.Configuration.GetSection(nameof(UserDatabaseSettings)));

builder.Services.AddSingleton<IRecipeDatabaseSettings>(sp =>
	sp.GetRequiredService<IOptions<RecipeDatabaseSettings>>().Value);

builder.Services.AddSingleton<IUserDatabaseSettings>(sp =>
	sp.GetRequiredService<IOptions<UserDatabaseSettings>>().Value);

builder.Services.AddSingleton<IRecipeService, RecipeService>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
