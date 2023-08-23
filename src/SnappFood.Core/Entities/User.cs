using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappFood.Core.Entities
{
    public class User:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Order> Posts { get; } = new();
    }
}
