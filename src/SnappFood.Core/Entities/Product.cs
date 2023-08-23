using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappFood.Core.Entities
{
    [Index(nameof(Title), IsUnique = true)]
    public class Product : IEntity
    {
        public int Id { get; set; }

        [StringLength(40)]
        public string Title { get; set; }
        public int InventoryCount { get; set; } 
        public decimal Price { get; set; }
        public int Discount { get; set; }
    }
}
