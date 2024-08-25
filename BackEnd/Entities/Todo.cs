using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace BackEnd.Entities
{
    public class Todo
    {
        [Key]
        public int id { get; set; }

        public DateTime date { get; set; }

        public string title { get; set; }

        public string? description { get; set; }

        public int level { get; set; }


    }
}
