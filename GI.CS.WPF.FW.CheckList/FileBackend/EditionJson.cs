using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json;
using System.IO;
using System.Collections.ObjectModel;

namespace GI.CS.WPF.FW.CheckList
{
    class EditionJson
    {
        static public void WriteJSON(string namefile)
        {
            if (File.Exists(namefile))            
                File.Delete(namefile);          

            var options = new JsonSerializerOptions
            {
                // WriteIndented = true, // Если true - устанавливаются дополнительные пробелы и переносы (для красоты)
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) //Кодировка в юникоде вместо ескайп последовательности          
            };           
            using (FileStream file = new FileStream("test.json", FileMode.Create))
            {
                JsonSerializer.SerializeAsync(file, QuestsBox.questItems, options);
            }            
        }

        public static void ReadJSON()
        {
            ObservableCollection<QuestItem> questItemsTemp = new ObservableCollection<QuestItem>();
                       
            using (FileStream fs = new FileStream("test.json", FileMode.Open))
            {
                questItemsTemp = JsonSerializer.DeserializeAsync<ObservableCollection<QuestItem>>(fs).Result;               
            }
            foreach(QuestItem questItem in questItemsTemp)
                QuestsBox.questItems.Add(questItem);
        }
    }
}
