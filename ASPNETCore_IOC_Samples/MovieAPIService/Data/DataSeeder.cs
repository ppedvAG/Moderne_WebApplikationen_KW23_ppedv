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
                context.Movies.Add(new Movie() { Id = 4, Title = "Jurassic World 2", Description = "Dinosauer", Price = 9.99m, Genre = GenreType.Action });
                context.Movies.Add(new Movie() { Id = 5, Title = "Star Wars 2", Description = "Imperium ist böse", Price = 19.99m, Genre = GenreType.ScienceFiction });
                context.Movies.Add(new Movie() { Id = 6, Title = "Top Gun Maverick 2", Description = "Ist besser als Teil 1", Price = 15.99m, Genre = GenreType.Action });
                context.Movies.Add(new Movie() { Id = 7, Title = "Jurassic World 3", Description = "Dinosauer", Price = 9.99m, Genre = GenreType.Action });
                context.Movies.Add(new Movie() { Id = 8, Title = "Star Wars 3", Description = "Imperium ist böse", Price = 19.99m, Genre = GenreType.ScienceFiction });
                context.Movies.Add(new Movie() { Id = 9, Title = "Top Gun Maverick 3", Description = "Ist besser als Teil 1", Price = 15.99m, Genre = GenreType.Action });
                context.Movies.Add(new Movie() { Id = 10, Title = "Jurassic World 4", Description = "Dinosauer", Price = 9.99m, Genre = GenreType.Action });
                context.Movies.Add(new Movie() { Id = 11, Title = "Star Wars 4", Description = "Imperium ist böse", Price = 19.99m, Genre = GenreType.ScienceFiction });


                context.SaveChanges();
            }
        }
    }
}
