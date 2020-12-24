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


        [Test]
        public void SortList_NotSorList_SortList()
        {
            // Setup
            var notSortProject = new Project();
            var sortProject = new Project();
            notSortProject.Notes.Add(new Note()
            {
                Name = "ДР1 — серия советских дизель-поездов",
                Text = "В начале 60-х на железные дороги СССР поступили дизель-поезда серии Д венгерского производства." +
                       " Изучив зарубежный опыт, СССР начал разработку отечественных дизель-поездов.",
                Category = NoteCategory.Work,
                Created = new DateTime(2021, 1, 5),
                Modified = new DateTime(2021, 1, 25)
            });
            notSortProject.Notes.Add(new Note()
            {
                Name = "Д1 — серия дизель-поездов",
                Text = "Дизель-поезд базовой составности состоит из двух головных моторных вагонов и двух промежуточных прицепных вагонов; " +
                       "также может эксплуатироваться в пятивагонной и шестивагонной составности с тремя и четырьмя прицепными вагонами.",
                Category = NoteCategory.House,
                Created = new DateTime(2021, 2, 6),
                Modified = new DateTime(2021, 2, 26)
            });
            sortProject.Notes.Add(new Note()
            {
                Name = "Д1 — серия дизель-поездов",
                Text = "Дизель-поезд базовой составности состоит из двух головных моторных вагонов и двух промежуточных прицепных вагонов; " +
                       "также может эксплуатироваться в пятивагонной и шестивагонной составности с тремя и четырьмя прицепными вагонами.",
                Category = NoteCategory.House,
                Created = new DateTime(2021, 2, 6),
                Modified = new DateTime(2021, 2, 26)
            });
            sortProject.Notes.Add(new Note()
            {
                Name = "ДР1 — серия советских дизель-поездов",
                Text = "В начале 60-х на железные дороги СССР поступили дизель-поезда серии Д венгерского производства." +
                       " Изучив зарубежный опыт, СССР начал разработку отечественных дизель-поездов.",
                Category = NoteCategory.Work,
                Created = new DateTime(2021, 1, 5),
                Modified = new DateTime(2021, 1, 25)
            });

            // Act
            var sortedList = notSortProject.SortList();

            // Assert
            NUnit.Framework.Assert.AreEqual(sortedList.ToString(), sortProject.Notes.ToString());
        }


        [Test]
        public void SortListСategory_NotSorList_SortList()
        {
            // Setup
            var notSortProject = new Project();
            var sortProject = new Project();
            notSortProject.Notes.Add(new Note()
            {
                Name = "ДР1 — серия советских дизель-поездов",
                Text = "В начале 60-х на железные дороги СССР поступили дизель-поезда серии Д венгерского производства." +
                       " Изучив зарубежный опыт, СССР начал разработку отечественных дизель-поездов.",
                Category = NoteCategory.Work,
                Created = new DateTime(2021, 1, 5),
                Modified = new DateTime(2021, 1, 25)
            });
            notSortProject.Notes.Add(new Note()
            {
                Name = "Д1 — серия дизель-поездов",
                Text = "Дизель-поезд базовой составности состоит из двух головных моторных вагонов и двух промежуточных прицепных вагонов; " +
                       "также может эксплуатироваться в пятивагонной и шестивагонной составности с тремя и четырьмя прицепными вагонами.",
                Category = NoteCategory.House,
                Created = new DateTime(2021, 2, 6),
                Modified = new DateTime(2021, 2, 26)
            });
            sortProject.Notes.Add(new Note()
            {
                Name = "ДР1 — серия советских дизель-поездов",
                Text = "В начале 60-х на железные дороги СССР поступили дизель-поезда серии Д венгерского производства." +
                       " Изучив зарубежный опыт, СССР начал разработку отечественных дизель-поездов.",
                Category = NoteCategory.Work,
                Created = new DateTime(2021, 1, 5),
                Modified = new DateTime(2021, 1, 25)
            });
            var sortCategory = NoteCategory.Work;

            // Act
            var sortedList = notSortProject.SortList(sortCategory);

            // Assert
            NUnit.Framework.Assert.AreEqual(sortedList.ToString(), sortProject.Notes.ToString());
        }

        [Test]
        public void SelectIndex_GoodSelectIndex_SameSelectIndex()
        {
            // Setup
            var sourceSelectIndex = 1;
            var actualProject = new Project();
            var expectedSelectIndex = sourceSelectIndex;

            // Act
            actualProject.SelectNote = sourceSelectIndex;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedSelectIndex, actualProject.SelectNote);
        }


    }
}

    