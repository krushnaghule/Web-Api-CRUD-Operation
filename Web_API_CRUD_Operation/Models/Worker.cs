namespace Web_API_CRUD_Operation.Models
{
    public class Worker
    {
        public Guid ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Phone { get; set; }
        public string? Email { get; set; }
        public string City { get; set; }
        public string Salary { get; set; }
    }
}
