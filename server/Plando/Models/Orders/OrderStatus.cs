namespace Plando.Models.Orders
{
    public enum OrderStatus
    {
        NEW,            // created
        IN_PROCESS,     // laundry is processing order
        FINISHED,       // laundry finished order
        PASSED,         // client picked order from laundry
    }
}