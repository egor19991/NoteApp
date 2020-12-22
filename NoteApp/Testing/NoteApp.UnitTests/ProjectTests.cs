using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.UnitTests
{
    using NUnit.Framework;

    [TestFixture]
    public class ProjectTests
    {
        [Test]
        public void Project_GoodProject_NotNull()
        {
            // Setup
            var expectedProject = new Project();
            var actualProject= new  Project();
            var sourceName = "ЭД4 — серия электропоездов постоянного тока";
            var sourceText = "Первый шестивагонный электропоезд ЭД4 - 0001 был изготовлен в 1996 году и к 13 марта 1997 года прошёл " +
                             "испытания на экспериментальном кольце ВНИИЖТ.Основные показатели при испытаниях соответствовали электропоезду ЭД2Т.";
           
            var sourceCategory = NoteCategory.Work; ;
            var sourceNote = new Note(sourceName, sourceText, sourceCategory);

            // Act
             actualProject.Notes.Add(sourceNote);
             expectedProject.Notes = null;

            // Assert
            NUnit.Framework.Assert.AreNotEqual(expectedProject, actualProject);
        }

    }
}

    