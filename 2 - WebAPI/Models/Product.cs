
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Dto;

namespace TiendaWeb.Models
{
    public class ProductBase
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal? Price { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public ProductStatus Status { get; set; }
    }

    public class ProductForList
    {
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }

        public int CategoryId { get; }

        public ProductStatus Status { get; }

        public ProductForList(int id, string name, string description, decimal price, int categoryId, ProductStatus status )
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
            Status = status;
        }
    }
}
