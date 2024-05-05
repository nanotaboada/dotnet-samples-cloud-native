using Dotnet.Samples.CloudNative;
using Microsoft.EntityFrameworkCore;

/* -----------------------------------------------------------------------------
 * Services
 * https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis#add-services
 * -------------------------------------------------------------------------- */

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PlayerDbContext>(options => options.UseInMemoryDatabase("Players"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(settings =>
{
    settings.DocumentName = "players-api";
    settings.Title = "Players (Minimal API)";
    settings.Version = "v1";
    settings.Description =
        "Proof of Concept for a Minimal API made with .NET 8 (LTS) and ASP.NET Core 8.0";
});

/* -----------------------------------------------------------------------------
 * Middlewares
 * https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis#aspnet-core-middleware
 * -------------------------------------------------------------------------- */

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(settings =>
    {
        settings.DocumentTitle = "Players (Minimal API)";
        settings.Path = "/swagger";
        settings.DocumentPath = "/swagger/{documentName}/swagger.json";
        settings.DocExpansion = "list";
    });
}

/* -----------------------------------------------------------------------------
 * Routes
 * https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis#routing
 * -------------------------------------------------------------------------- */

var router = app.MapGroup("/players");

router.MapGet("/", RetrievePlayers);
router.MapGet("/{id}", RetrievePlayerById);
router.MapGet("/squadNumber/{squadNumber}", RetrievePlayerBySquadNumber);
router.MapPost("/", CreatePlayer);
router.MapPut("/{id}", UpdatePlayer);
router.MapDelete("/{id}", DeletePlayer);

/* -----------------------------------------------------------------------------
 * Route Handlers
 * https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis#route-handlers
 * -------------------------------------------------------------------------- */

// Retrieve --------------------------------------------------------------------

static async Task<IResult> RetrievePlayers(PlayerDbContext db)
{
    return TypedResults.Ok(await db.Players.ToArrayAsync());
}

static async Task<IResult> RetrievePlayerById(int id, PlayerDbContext db)
{
    if (await db.Players.FindAsync(id) is Player entity)
    {
        return TypedResults.Ok(entity);
    }

    return TypedResults.NotFound();
}

static async Task<IResult> RetrievePlayerBySquadNumber(int squadNumber, PlayerDbContext db)
{
    if (
        await db.Players.Where(player => player.SquadNumber == squadNumber).SingleOrDefaultAsync()
        is Player entity
    )
    {
        return TypedResults.Ok(entity);
    }

    return TypedResults.NotFound();
}

// Create ----------------------------------------------------------------------

static async Task<IResult> CreatePlayer(Player player, PlayerDbContext db)
{
    if (await db.Players.FindAsync(player.Id) is Player entity)
    {
        return TypedResults.Conflict(entity);
    }

    db.Players.Add(player);
    await db.SaveChangesAsync();

    return TypedResults.Created($"/players/{player.Id}", player);
}

// Update ----------------------------------------------------------------------

static async Task<IResult> UpdatePlayer(int id, Player player, PlayerDbContext db)
{
    if (await db.Players.FindAsync(id) is Player entity)
    {
        entity.MapFrom(player);
        await db.SaveChangesAsync();

        return TypedResults.NoContent();
    }

    return TypedResults.NotFound();
}

// Delete ----------------------------------------------------------------------

static async Task<IResult> DeletePlayer(int id, PlayerDbContext db)
{
    if (await db.Players.FindAsync(id) is Player entity)
    {
        db.Players.Remove(entity);
        await db.SaveChangesAsync();

        return TypedResults.NoContent();
    }

    return TypedResults.NotFound();
}

/* -----------------------------------------------------------------------------
 * Data Seeding
 * https://learn.microsoft.com/en-us/ef/core/modeling/data-seeding
 * -------------------------------------------------------------------------- */

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<PlayerDbContext>();

    dbContext.Seed();
}

app.Run();
