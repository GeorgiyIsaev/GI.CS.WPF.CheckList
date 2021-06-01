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
using System.Windows;

namespace GI.CS.WPF.FW.CheckList
{
    class EditionJson
    {              
        static public void WriteJSON(string namefile, bool ifWriteIndented = false, bool ifEncoder = false)
        {
            if (File.Exists(namefile))            
                File.Delete(namefile);

            var options = new JsonSerializerOptions { };
            if (ifEncoder)
            {
                options = new JsonSerializerOptions
                {
                    DefaultBufferSize = 100000, //максимальный буфер (по умолчанию 16 384 байт)             
                    WriteIndented = ifWriteIndented, // Если true - устанавливаются дополнительные пробелы и переносы (для красоты)
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) //Кодировка в юникоде вместо ескайп последовательности  

                };
            }
            else {
                options = new JsonSerializerOptions
                {
                    DefaultBufferSize = 100000, //максимальный буфер (по умолчанию 16 384 байт)             
                    WriteIndented = ifWriteIndented, // Если true - устанавливаются дополнительные пробелы и переносы (для красоты)
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) //Кодировка в юникоде вместо ескайп последовательности  
                };
            }

            using (FileStream file = new FileStream(namefile, FileMode.Create))
            {
                JsonSerializer.SerializeAsync(file, QuestsBox.questItems, options);
            }            
        }

        public static int ReadJSON(string namefile)
        {
            try
            {
                ObservableCollection<QuestItem> questItemsTemp = new ObservableCollection<QuestItem>();
                int countRead = questItemsTemp.Count;
                int countBefore = QuestsBox.questItems.Count;
             
                using (FileStream fs = new FileStream(namefile, FileMode.Open))
                {
                    questItemsTemp = JsonSerializer.DeserializeAsync<ObservableCollection<QuestItem>>(fs).Result;
                }
                QuestsBox.DeleteOneQuest();
                foreach (QuestItem questItem in questItemsTemp)
                    QuestsBox.questItems.Add(questItem);
                QuestsBox.AddOneQuest();
                return (QuestsBox.questItems.Count - countBefore);
            }
            catch (Exception ex)
            {
                string textError = "При чтении из файла namefile произошла ошибка,\n" +
                    "проверте, соответствует ли содержимое файла формату JSON!\n\n" +
                    "ОПИСАНИЕ ОШИБКИ:\n" + ex +"\n"+ex.Message;
                MessageBox.Show(textError);
            }
            return 0;
        }
    }
}
