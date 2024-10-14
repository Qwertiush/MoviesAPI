using Microsoft.EntityFrameworkCore;

namespace tut.Data;

public static class DataExtentions
{
    public static async Task MigrateDbAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<MovieStoreContext>(); 
        await dbContext.Database.MigrateAsync();
    }
}
