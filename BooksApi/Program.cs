using BooksApi.Models;
using BooksApi.Services;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.Configure<BooksDatabaseSettings>(builder.Configuration.GetSection("BooksDatabaseSettings"));

builder.Services.AddSingleton<IMongoDatabase>(sp =>
{

    var connectionString = builder.Configuration["BooksDatabaseSettings:ConnectionString"];
    var mongoDatabase = new MongoClient(connectionString).GetDatabase(builder.Configuration["BooksDatabaseSettings:DatabaseName"]);
    return mongoDatabase;
});

builder.Services.AddSingleton<BooksService>();
builder.Services.AddSingleton<TagsService>();

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
