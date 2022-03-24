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
                };
            }

            using (FileStream file = new FileStream(namefile, FileMode.CreateNew))
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
                /*Удаляем первый вопрос - который меню*/
                if (questItemsTemp.Count > 0)
                    questItemsTemp.RemoveAt(0);

                /*Загружаем результат в контейнер*/
                int countAddQuest = 0;
                foreach (QuestItem questItem in questItemsTemp)
                {
                    countAddQuest++;
                    QuestsBox.AddQuestToDBAndQuestBox(questItem.GetQuestFormDB());
                }

                return countAddQuest;
            }
            catch (Exception ex)
            {
                string textError = "При чтении из файла namefile произошла ошибка,\n" +
                    "проверте, соответствует ли содержимое файла формату JSON!\n\n" +
                    "ОШИБКА:\n" + ex + "\nОПИСАНИЕ ОШИБКИ:\n" + ex.Message;
                MessageBox.Show(textError);
            }
            return 0;
        }
    }
}
