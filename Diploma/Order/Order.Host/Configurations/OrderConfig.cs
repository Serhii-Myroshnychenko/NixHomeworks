namespace Order.Host.Configurations;

public class OrderConfig
{
    public string CdnHost { get; set; } = null!;
    public string BasketUrl { get; set; } = null!;
    public string CatalogApi { get; set; } = null!;
    public string ConnectionString { get; set; } = null!;
}