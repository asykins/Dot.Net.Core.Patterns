using System;

namespace Pattern.Domain
{
    public interface IProduct
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        double Price { get; set; }
        double ApplicableVAT { get; set; }
    }
}
