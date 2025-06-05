using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LR_DB.Model
{
    [Table("genre")]
    public class Genre
    {
        [Key]
        [Column("id_genre")]
        public int Id { get; set; }

        [Column("genre")]
        public string Name { get; set; }

        
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}