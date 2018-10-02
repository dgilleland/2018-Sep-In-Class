namespace NorthwindTraders.Entities.POCOs
{
    public class ProductInfo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? Price { get; set; }
        public short? InStock { get; set; }
    }
}
