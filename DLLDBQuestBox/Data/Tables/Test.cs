using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Tables
{
   

    [Table("Tests")]
    public class Test
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Group { get; set; }
        public string Name { get; set; }
        public Profile Profile { get; set; }
        public long ProfileId { get; set; }

        public ICollection<Quest> Quests { get; set; }
        public Test()
        {
            Quests = new List<Quest>();
        }
    }
}
