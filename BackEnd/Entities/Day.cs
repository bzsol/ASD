using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace BackEnd.Entities
{
    public class Day
    {
        [Key]
        public int id { get; set; }

        public DateTime date { get; set; }

        public string? description { get; set; }

        public int happiness { get; set; }

        public string? motto { get; set; }



    }
}
