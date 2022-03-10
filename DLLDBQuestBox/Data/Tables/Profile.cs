using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Tables
{
   

    [Table("Profiles")]
    public class Profile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Unique] //уникальный
        [Required] //требуемый
        public string Name { get; set; }
        public string Password { get; set; }

        public ICollection<Test> Tests { get; set; }
        public Profile()
        {
            Tests = new List<Test>();
           

        }

    }
}
