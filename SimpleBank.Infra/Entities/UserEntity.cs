namespace SimpleBank.Infra.Entities
{
    public class UserEntity
    {
    //    ID = Column(Integer, primary_key= True, index= True)
    //FULL_NAME = Column(String, unique= True, index= True)
    //EMAIL = Column(String, unique= True, index= True)
    //PASSWORD_HASH = Column(String)
    //ROLE = Column(String)
    //CREATED_AT = Column(DateTime, default=datetime.utcnow)
    //UPDATED_AT = Column(DateTime)
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string CpfCnpj { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
