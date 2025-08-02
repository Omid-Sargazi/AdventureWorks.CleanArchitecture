namespace AdventureWorks.Domain.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!; // For demo only. Use hashed password in production
        public string Role { get; set; } = "User";
    }
}