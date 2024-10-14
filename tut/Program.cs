using tut.Data;
using tut.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("MovieStore");
builder.Services.AddSqlite<MovieStoreContext>(connString);

var app = builder.Build();

app.MapMoviesEndpoints();
app.MapGeneresEndpoints();

await app.MigrateDbAsync();

app.Run();
