namespace WingTipToys.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal UnitPrice { get; set; }

        public string ImageUrl { get; set; }

        public ProductType Type { get; set; }
    }
}
