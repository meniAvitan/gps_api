using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mySqlConnectionDemo.Data
{
    public class Location
    {
        public int Id { get; set; }

        public float Lat { get; set; }

        public float Lng { get; set; }
    }
}
