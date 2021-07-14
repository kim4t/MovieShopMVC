using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    [Table("Genre")]
    public class Genre
    {
        public int Id { get; set; }

        [MaxLength(24)]
        public String Name { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }

    //To change entity/table
    //2 option
    //DataAnnotation, Fluent API
}
