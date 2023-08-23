using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappFood.Core.Entities
{
    public class Order:IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public DateTime CreationDate { get; set; }
        public int BuyerId { get; set; }
        public User Buyer { get; set; }
       
    }
}
