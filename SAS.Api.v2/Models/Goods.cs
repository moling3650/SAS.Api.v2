namespace SAS.Api.v2.Models
{
    public class Goods
    {
        public long Id { get; private set; }
        public string Category { get; private set; }
        public string GoodsName { get; private set; }
        public double Cost { get; private set; }

        public Goods(long id, string category, string goodsName, double cost)
        {
            this.Id = id;
            this.Category = category;
            this.GoodsName = goodsName;
            this.Cost = cost;
        }
    }
}
