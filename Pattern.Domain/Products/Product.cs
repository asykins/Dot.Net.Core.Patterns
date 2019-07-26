using System;

namespace Pattern.Domain
{
    public class Product : IProduct
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double ApplicableVAT { get; set; }
    }   
}