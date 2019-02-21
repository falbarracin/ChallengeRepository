using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Challenge.Domain
{
    public class Location
    {
        [Key]
        public string PostCode { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
      
    }

}
