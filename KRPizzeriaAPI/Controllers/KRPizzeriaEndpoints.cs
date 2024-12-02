using Microsoft.EntityFrameworkCore;
using KRPizzeriaAPI.Data;
using KRPizzeriaAPI.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace KRPizzeriaAPI.Controllers;

public static class KRPizzeriaEndpoints
{
    public static void MapKRPizzeriaEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/KRPizzeria").WithTags(nameof(KRPizzeria));

        group.MapGet("/", async (KrproyectoPizzeriaContext db) =>
        {
            return await db.Krpizzeria.ToListAsync();
        })
        .WithName("GetAllKRPizzeria")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<KRPizzeria>, NotFound>> (int idkrpizzeria, KrproyectoPizzeriaContext db) =>
        {
            return await db.Krpizzeria.AsNoTracking()
                .FirstOrDefaultAsync(model => model.idKRPizzeria == idkrpizzeria)
                is KRPizzeria model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetKRPizzeriaById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int idkrpizzeria, KRPizzeria kRPizzeria, KrproyectoPizzeriaContext db) =>
        {
            var affected = await db.Krpizzeria
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

        group.MapPost("/", async (KRPizzeria kRPizzeria, KrproyectoPizzeriaContext db) =>
        {
            db.Krpizzeria.Add(kRPizzeria);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/KRPizzeria/{kRPizzeria.idKRPizzeria}",kRPizzeria);
        })
        .WithName("CreateKRPizzeria")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int idkrpizzeria, KrproyectoPizzeriaContext db) =>
        {
            var affected = await db.Krpizzeria
                .Where(model => model.idKRPizzeria == idkrpizzeria)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteKRPizzeria")
        .WithOpenApi();
    }
}
