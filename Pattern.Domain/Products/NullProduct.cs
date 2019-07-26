
using System;

namespace Pattern.Domain
{
    public class NullProduct : IProduct
    {
        public Guid Id { get; set; }
        public string Name { get { return "This product is not defined"; } 
                             set { this.Name = value; } }
        public string Description { get { return "This product is not defined"; } 
                                    set { this.Description = value; } }
        public double Price { get{ return 0;} 
                              set { this.Price = value; } }
        public double ApplicableVAT { get { return 0; } 
                                      set { this.ApplicableVAT = value; } }
    }
}