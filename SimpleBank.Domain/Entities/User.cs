namespace SimpleBank.Domain.Entities
{
    public enum AccountType
    {
        Common, // usuario simples
        Merchant // lojista
    }
    public class User : EntityBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public string Password { get; set; }
        public AccountType AccountType { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
