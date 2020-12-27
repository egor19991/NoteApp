using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.UnitTests
{
    
    using  NUnit.Framework;
    [TestFixture]
    public class ProjectManagerTests
    {

        public Project PrepareProject()
        {
            var sourceProject = new Project();
            sourceProject.Notes.Add(new Note()
            {
                Name = "ДР1 — серия советских дизель-поездов",
                Text = "В начале 60-х на железные дороги СССР поступили дизель-поезда серии Д венгерского производства." +
                       " Изучив зарубежный опыт, СССР начал разработку отечественных дизель-поездов.",
                Category = NoteCategory.Work,
                Created = new DateTime(2021, 1, 5),
                Modified = new DateTime(2021, 1, 25)
            });
            sourceProject.Notes.Add(new Note()
            {
                Name = "Д1 — серия дизель-поездов",
                Text = "Дизель-поезд базовой составности состоит из двух головных моторных вагонов и двух промежуточных прицепных вагонов; " +
                       "также может эксплуатироваться в пятивагонной и шестивагонной составности с тремя и четырьмя прицепными вагонами.",
                Category = NoteCategory.House,
                Created = new DateTime(2021, 2, 6),
                Modified = new DateTime(2021, 2, 26)
            });
            return sourceProject;
        }

        public string testPath()
        {
            var location = Assembly.GetExecutingAssembly().Location;
            return Path.GetDirectoryName(location) + @"\TestData";
        }


        [Test]
        public void SaveToFile_CorrectProject_FileSavedCorrectly()
        {
            // Setup
            var sourceProject = PrepareProject();
            var testDataFolder = testPath();
            var actualFilename = testDataFolder + @"\actualProject.json";
            var expectedFilename = testDataFolder + @"\expectedProject.json";

            if (File.Exists(actualFilename))
            {
                File.Delete(actualFilename);
            }

            //  Act
            ProjectManager.SaveToFile(sourceProject, actualFilename);

            var isFileExist = File.Exists(actualFilename);
            NUnit.Framework.Assert.AreEqual(true, isFileExist);

            // Assert
            var actualFileContent = File.ReadAllText(actualFilename);
            var expectedFileContent = File.ReadAllText(expectedFilename);
            NUnit.Framework.Assert.AreEqual(expectedFileContent, actualFileContent);
        }

        [Test]
        public void LoadToFile_CorrectFile_FileLoadCorrectly()
        {
            // Setup
            var sourceProject = PrepareProject();
            var testDataFolder = testPath();
            var expectedFilename = testDataFolder + @"\expectedProject.json";
            
            //  Act
            var isFileExist = File.Exists(expectedFilename);
            NUnit.Framework.Assert.AreEqual(true, isFileExist);
            var loadProject = ProjectManager.LoadToFile(expectedFilename);

            // Assert
            NUnit.Framework.Assert.AreEqual(sourceProject.Notes.ToString(), loadProject.Notes.ToString());
        }

        [Test]
        public void LoadToFile_NoCorrectFile_EmptyProject()
        {
            // Setup
            var sourceProject = new Project();
            var testDataFolder = testPath();
            var expectedFilename = testDataFolder + @"\noCorectedProject.json";

            //  Act
            var isFileExist = File.Exists(expectedFilename);
            //NUnit.Framework.Assert.AreEqual(false, isFileExist);
            var loadProject = ProjectManager.LoadToFile(expectedFilename);

            // Assert
            NUnit.Framework.Assert.AreEqual(sourceProject.Notes.ToString(), loadProject.Notes.ToString());
        }


        [Test]
        public void DefaultPath_Empty_ReturnDefaultPath()
        {
            // Setup
            var expectedDefaultPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\NoteApp.notes";

            //  Act
            var actualDefaultPath = ProjectManager.DefaultPath;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedDefaultPath, actualDefaultPath);
        }

    }
}
