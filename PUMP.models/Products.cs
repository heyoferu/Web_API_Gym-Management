namespace PUMP.models;

public class Products
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double? Price { get; set; }
    public int Category { get; set; }
    public int? Stock { get; set; }
}