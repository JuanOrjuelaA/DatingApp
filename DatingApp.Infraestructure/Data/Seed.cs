namespace DatingApp.Infrastructure.Data
{
    using System.Collections.Generic;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using DbContext;
    using Microsoft.EntityFrameworkCore;
    using Models.Entities;

    public class Seed
    {
        public static async Task SeedUser(DatingDbContext context)
        {
            if (await context.Users.AnyAsync())
            {
                return;
            }

            var userData = await File.ReadAllTextAsync("Data/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);

            users?.ForEach(item =>
            {
                using var hmac = new HMACSHA512();
                item.UserName = item.UserName.ToLower();
                item.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));
                context.Users.Add(item);
            });

            await context.SaveChangesAsync();
        }
    }
}