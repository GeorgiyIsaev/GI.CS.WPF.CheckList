using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLDBQuestBox.Data.Tables
{
    [Table("Answer")]
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string TextAnswer { get; set; }
        public int QuestId { get; set; }
        public bool isTrue { get; set; }
    }
}
