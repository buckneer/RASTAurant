using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RASTAurant.Database.Models
{
    public class Order
    {
        public int TableId { get; set; }
        public int OrderId { get; set; }
        public string Item { get; set; }
        public decimal Price { get; set; }

        public Order(int orderId, int tableId, string item, decimal price)
        {
            TableId = tableId;
            OrderId = orderId;
            Item = item;
            Price = price;
        }
        public Order(int orderId, string item, decimal price)
        {
            OrderId = orderId;
            Item = item;
            Price = price;
        }
    }
}
