using System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NoteApp
{
    /// <summary>
    /// Класс Менеджер Проекта. Содержит методы для сохранения и считывания данных о всех записях.
    /// </summary>
    public static class ProjectManager
    {
        /// <summary>
        /// Путь для сохранения файла.
        /// </summary>
        public static string path { get; set; }

        /// <summary>
        /// Метод для сохранения данных в файл.
        /// </summary>
        public static void SaveToFile(Project project, string path)
        {
            
            // С сайта https://www.newtonsoft.com/json/help/html/SerializeWithJsonSerializerToFile.htm + ctrl+c с занятия serialize
            // serialize JSON to a string and then write string to a file
            File.WriteAllText(path, JsonConvert.SerializeObject(project));

            // serialize JSON directly to a file
           using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.NullValueHandling = NullValueHandling.Include;
                serializer.TypeNameHandling = TypeNameHandling.All;
                serializer.Formatting = Formatting.Indented;
                serializer.Serialize(file, project);
            }

            /* Работает, код из методички + ctrl+c с занятия serialize
            //Создаём экземпляр сериализатора
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Include;
            serializer.TypeNameHandling = TypeNameHandling.All;
            serializer.Formatting = Formatting.Indented;
            //Открываем поток для записи в файл с указанием пути
            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                //Вызываем сериализацию и передаем объект, который хотим сериализовать
                serializer.Serialize(writer, project);
            }
            */
        }


        /// <summary>
        /// Метод для считывания данных из файла. Если файл не найден, то возвращатся пустой экземпляр Project.
        /// </summary>
        public static Project LoadToFile(string path)
        {
            //Проверка существование файла
           if (File.Exists(path))
           {

                // read file into a string and deserialize JSON to a type
                Project project1 = JsonConvert.DeserializeObject<Project>(File.ReadAllText(path));

                // deserialize JSON directly from a file
                using (StreamReader file = File.OpenText(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.NullValueHandling = NullValueHandling.Include;
                    serializer.TypeNameHandling = TypeNameHandling.All;
                    serializer.Formatting = Formatting.Indented;
                    Project project2 = (Project) serializer.Deserialize(file, typeof(Project));
                }
                return project1;
            }
           else
           {
               Project project = new Project();
               return project;
           }
        }


    }

}

