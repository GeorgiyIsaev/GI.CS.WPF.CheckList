using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GI.CS.WPF.FW.CheckList.FileBackend
{
    /*Класс который читает файл и выводит информацию о прочитаном*/
    public static class ReadFile
    {
        public static void Read(String fileName)
        {
            int count = 0;
            if (fileName.LastIndexOf(".txt") > -1)
                count = EditionTXT.file_readTXT(fileName);
            else if (fileName.LastIndexOf(".html") > -1)
                count = EditionHTML.readHTML(fileName);
            else if (fileName.LastIndexOf(".json") > -1)
                count = EditionJson.ReadJSON(fileName);

            if (count == 0)
                MessageBox.Show($"В данном файле вопросы не обнаруженны!");
            else
                MessageBox.Show($"Добавлено {count} вопросов.\n\n Закрыть окно?");
        }
    }
}
