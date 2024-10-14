using System;
using Microsoft.EntityFrameworkCore;
using tut.Data;
using tut.Mapping;

namespace tut.Endpoints;

public static class GeneresEndpoints
{
    public static RouteGroupBuilder MapGeneresEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("genres").WithParameterValidation();

        //GET /generes
        group.MapGet("/", async (MovieStoreContext dbContext)=>{
            return await dbContext.Genres.Select(genere => genere.ToDto()).AsNoTracking().ToListAsync();
        });

        return group;
    }
}
