namespace PUMP.models;

public class ProductsPayments
{
    public int Id { get; set; }
    public int Employee { get; set; }
    public DateTime DatePayment { get; set; }
    public int Product { get; set; }
    public int Quantity { get; set; }
}