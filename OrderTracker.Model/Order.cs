using System.Collections.Generic;

namespace OrderTracker.Model
{
    public class Order
    {
        public int Id { get; set; }
        public List<Item> Items { get; set; }
    }
}
