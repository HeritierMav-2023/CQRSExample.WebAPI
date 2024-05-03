using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSExample.Domain.Entities
{
    /// <summary>
    /// Customer
    /// </summary>
    public class Customer 
    {
        public Customer() 
        { 
            //this.Rentals = new List<Rental>();
        }

        public string Name { get; set; }
        public string Phone { get; set; }
        public bool IsGold { get; set; }
        //public ICollection<Rental> Rentals { get; set; }
    }
}
