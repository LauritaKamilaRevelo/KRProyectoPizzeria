using Microsoft.EntityFrameworkCore;
using KRProyectoPizzeria.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace KRPizzeriaAPI.Controllers;

public static class KRPizzeriaEndpoints
{
    public static void MapKRPizzeriaEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/KRPizzeria").WithTags(nameof(KRPizzeria));

        group.MapGet("/", async (KRPizzeriaAPIContext db) =>
        {
            return await db.KRPizzeria.ToListAsync();
        })
        .WithName("GetAllKRPizzeria")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<KRPizzeria>, NotFound>> (int idkrpizzeria, KRPizzeriaAPIContext db) =>
        {
            return await db.KRPizzeria.AsNoTracking()
                .FirstOrDefaultAsync(model => model.idKRPizzeria == idkrpizzeria)
                is KRPizzeria model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetKRPizzeriaById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int idkrpizzeria, KRPizzeria kRPizzeria, KRPizzeriaAPIContext db) =>
        {
            var affected = await db.KRPizzeria
                .Where(model => model.idKRPizzeria == idkrpizzeria)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.idKRPizzeria, kRPizzeria.idKRPizzeria)
                    .SetProperty(m => m.KR_Name, kRPizzeria.KR_Name)
                    .SetProperty(m => m.KR_WithCocaCola, kRPizzeria.KR_WithCocaCola)
                    .SetProperty(m => m.KR_Precio, kRPizzeria.KR_Precio)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateKRPizzeria")
        .WithOpenApi();

        group.MapPost("/", async (KRPizzeria kRPizzeria, KRPizzeriaAPIContext db) =>
        {
            db.KRPizzeria.Add(kRPizzeria);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/KRPizzeria/{kRPizzeria.idKRPizzeria}",kRPizzeria);
        })
        .WithName("CreateKRPizzeria")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int idkrpizzeria, KRPizzeriaAPIContext db) =>
        {
            var affected = await db.KRPizzeria
                .Where(model => model.idKRPizzeria == idkrpizzeria)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteKRPizzeria")
        .WithOpenApi();
    }
}
