using System;
using System.Collections.Generic;


namespace CQRSExample.Application.Products
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public double Prix { get; set; }
    }
}
