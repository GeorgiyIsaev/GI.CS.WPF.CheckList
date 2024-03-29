﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Tables
{ 
    [Table("Quests")]
    public class Quest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string TextQuest { get; set; }
        public string TextComment { get; set; }
        public Test Test { get; set; }
        public long TestId { get; set; }

        public ICollection<Answer> Answers { get; set; }
        public Quest()
        {
            Answers = new List<Answer>();
            TextComment = "";
        }

    }
}
