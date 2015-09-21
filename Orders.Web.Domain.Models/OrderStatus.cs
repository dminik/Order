namespace Orders.Web.Domain.Models
{    
    public enum OrderStatus
    {
        NotSet = -1,
        New = 1, 
        InProgress = 2,
        Done = 3
    }
}