namespace MVCWebApp.Models
{
    public class MovieCustomerComments
    {
        public int Id { get; set; }
        public string Comment { get; set; }

        public int MovieId { get; set; }

        public virtual Movie MovieRef {get;set;}

    }
}
