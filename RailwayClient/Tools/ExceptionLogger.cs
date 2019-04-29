using System;
using System.IO;

namespace RailwayClient.Tools
{
    /// <summary>
    ///     Текстовый логер ошибок
    /// </summary>
    public class TextExceptionLogger : IExceptionLogger
    {
        private static readonly object SyncRoot = new object();
        private const int MAX_FILE_SIZE = 1024 * 1024; // 1MB
        private const string LOG_FILE_NAME = "_log.txt";
        private const string LOG_FOLDER = "_ArchiveLogFolder_";


        /// <summary> Потокобезопасное логирование ошибки в текстовый файл </summary>
        /// <param name="e">Возникшая ошибка</param>
        /// <param name="additionalInfo">Дополнительные сведения</param>
        public void Log(Exception e, string additionalInfo = null)
        {
            lock (SyncRoot)
            {
                try
                {
                    CheckFile();

                    using (var writer = File.AppendText(LOG_FILE_NAME))
                    {
                        writer.WriteLine();
                        writer.WriteLine();
                        writer.WriteLine("################################");
                        writer.WriteLine("Date: " + DateTime.Now);
                        if (!string.IsNullOrEmpty(additionalInfo))
                            writer.WriteLine("Дополнительная информация: " + additionalInfo);

                        var exception = e;
                        while (exception != null)
                        {
                            writer.WriteLine();
                            writer.WriteLine(exception.Message);
                            writer.WriteLine(exception.Source);
                            writer.WriteLine(exception.StackTrace);
                            exception = exception.InnerException;
                        }
                        writer.WriteLine("################################");
                    }
                }
                catch (Exception) {/*Нужно, чтобы не вылетело приложение*/}
            }
        }

        //Проверяем, что существует файл, в который можно записать лог
        private static void CheckFile()
        {
            //Если файла нет - создаём
            if (!File.Exists(LOG_FILE_NAME))
                File.Create(LOG_FILE_NAME).Close();

            //Если файл слишком вырос, то переносим в архив
            var fileSize = new FileInfo(LOG_FILE_NAME).Length;
            if (fileSize > MAX_FILE_SIZE)
            {
                //Проверяем, что директория существует
                if (!Directory.Exists(LOG_FOLDER))
                    Directory.CreateDirectory(LOG_FOLDER);

                //Получаем информацию для нового названия файла
                int count = Directory.GetFiles(LOG_FOLDER).Length + 1;
                string name = Path.GetFileNameWithoutExtension(LOG_FILE_NAME);
                string ext = Path.GetExtension(LOG_FILE_NAME);

                //Удаляем чёрточку в имени файла
                name = name?.TrimStart('_');

                //Перемещаем старый и создаём новый лог
                File.Move(LOG_FILE_NAME, string.Format("{0}\\{1}-{3}{2}", LOG_FOLDER, name, ext, count));
                File.Create(LOG_FILE_NAME).Close();
            }
        }
    }
}