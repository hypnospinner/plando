namespace Plando.Models.Orders
{
    public enum OrderStatus
    {
        NEW,        // created but being in process
        PASSED,     // in process
        FINISHED    // finished
    }
}