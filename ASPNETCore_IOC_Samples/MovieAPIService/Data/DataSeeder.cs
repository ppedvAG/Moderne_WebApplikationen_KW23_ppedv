namespace MovieAPIService.Data
{
    public static class DataSeeder
    {
        public static void Seed (MovieDbContext context)
        {
            if (!context.Movies.Any())
            {
                context.Movies.Add(new Movie() { Id = 1, Title = "Jurassic World", Description = "Dinosauer", Price = 9.99m, Genre = GenreType.Action });
                context.Movies.Add(new Movie() { Id = 2, Title = "Star Wars", Description = "Imperium ist böse", Price = 19.99m, Genre = GenreType.ScienceFiction });
                context.Movies.Add(new Movie() { Id = 3, Title = "Top Gun Maverick", Description = "Ist besser als Teil 1", Price = 15.99m, Genre = GenreType.Action });
                context.SaveChanges();
            }
        }
    }
}
