namespace NZWalks.API.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }   
        public string Password { get; set; }
        public List<string> Roles  { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }


    }
}
