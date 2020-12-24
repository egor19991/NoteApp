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
        /// Переменная, хранящее стандартный путь для сохранения файла
        /// </summary>
        private static string _defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\NoteApp.notes";
        
        /// <summary>
        /// Поле, хранящее стандартный путь для сохранения файла
        /// </summary>
        public static string DefaultPath { get { return _defaultPath; } }

        /// <summary>
        /// Метод для сохранения данных в файл.
        /// </summary>
        public static void SaveToFile(Project project, string fullfilaname)
        {
            using (StreamWriter file = File.CreateText(fullfilaname))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.NullValueHandling = NullValueHandling.Include;
                serializer.TypeNameHandling = TypeNameHandling.All;
                serializer.Formatting = Formatting.Indented;
                serializer.Serialize(file, project);
            }
        }

        /// <summary>
        /// Метод для считывания данных из файла. Если файл не найден, то возвращатся пустой экземпляр Project.
        /// </summary>
        public static Project LoadToFile(string path)
        {
           try
           {
                Project project1 = JsonConvert.DeserializeObject<Project>(File.ReadAllText(path));
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
           catch (Exception)
           {
                Project project = new Project();
                return project;
           }
        }
    }
}

