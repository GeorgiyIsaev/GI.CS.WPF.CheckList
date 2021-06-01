using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json;
using System.IO;

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
    }
}
