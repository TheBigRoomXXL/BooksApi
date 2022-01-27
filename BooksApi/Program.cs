using BooksApi.Models;
using BooksApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.Configure<BooksDatabaseSettings>(
    builder.Configuration.GetSection("BooksDatabaseSettings"));

builder.Services.AddSingleton<BooksService>();

builder.Services.AddControllers();
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
