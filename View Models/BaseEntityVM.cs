namespace Credit_Managment_System_ASP.NET_MVC.View_Models
{
    public class BaseEntityVM 
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
