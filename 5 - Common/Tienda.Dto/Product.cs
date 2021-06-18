using System;
using Tienda.Dto;

namespace Dtos
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public ProductStatus Status { get; set; }
        public int CategoryId { get; set; }
    }
}
