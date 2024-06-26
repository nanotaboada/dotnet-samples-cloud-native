namespace Dotnet.Samples.CloudNative;

public static class PlayerDbContextExtensions
{
    public static void Seed(this PlayerDbContext context)
    {
        if (!context.Players.Any())
        {
            context.Players.AddRange(PlayerData.CreateStarting11());

            context.SaveChanges();
        }
    }
}
