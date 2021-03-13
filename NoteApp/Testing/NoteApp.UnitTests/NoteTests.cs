using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace NoteApp.UnitTests
{
    [TestFixture]
    public class NoteTests
    {
        [Test]
        public void Name_GoodName_ReturnsSameName()
        {
            // Setup
            var note = new Note();
            var sourceName = "ДР1 — серия советских дизель-поездов";
            var expectedName = sourceName;

            // Act
            note.Name = sourceName;
            var actualName = note.Name;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void Name_TooLongName_ThrowsException()
        {
            // Setup
            var note = new Note();
            var sourceName = "012345678901234567890123456789012345678901234567890";

            // Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
                (() =>
                {
                    // Act
                    note.Name = sourceName;
                }
            );

        }

        [Test]
        public void Name_EmptyName_ReturnsDefaultName()
        {
            // Setup
            var note = new Note();
            var sourceName = "";
            var expectedName = "Без названия";

            // Act
            note.Name = sourceName;
            var actualName = note.Name;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void Text_GoodText_ReturnsSameText()
        {
            // Setup
            var note = new Note();
            var sourceText = "ЭР2 (Электропоезд Рижский, 2-й тип) — серия электропоездов постоянного тока, " +
                             "выпускавшихся с июня 1962 года по август — сентябрь 1984 года[";
            var expectedName = sourceText;

            // Act
            note.Text = sourceText;
            var actualText = note.Text;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedName, actualText);
        }

        [Test]
        public void Text_EmptyText_ReturnsDefaultText()
        {
            // Setup
            var note = new Note();
            var sourceText = "";
            var expectedName = "Текст заметки";

            // Act
            note.Text = sourceText;
            var actualText = note.Text;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedName, actualText);
        }

        [Test]
        public void Category_GoodCategory_ReturnsSameCategory()
        {
            // Setup
            var note = new Note();
            var sourceCategory = NoteCategory.Finance;
            var expectedCategory = NoteCategory.Finance;

            // Act
            note.Category = sourceCategory;
            var actualCategory = note.Category;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedCategory, actualCategory);
        }

        [Test]
        public void Created_GoodDate_ReturnsSameDate()
        {
            // Setup
            var note = new Note();
            var sourceDate = DateTime.Now;
            var expectedDate = DateTime.Now;

            // Act
            note.Created = sourceDate;
            var actualDate = note.Created;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedDate, actualDate);
        }

        [Test]
        public void Modified_GoodDate_ReturnsSameDate()
        {
            // Setup
            var note = new Note();
            var sourceDate = DateTime.Now;
            var expectedDate = DateTime.Now;

            // Act
            note.Modified = sourceDate;
            var actualDate = note.Modified;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedDate, actualDate);
        }

        [Test]
        public void InterfaceNoteNameTextCategory_GoodData_ReturnsSameData()
        {
            // Setup
            var sourceName = "ВЛ10 — советский грузопассажирский электровоз";
            var expectedName = sourceName;
            var sourceText = "Электровозы строились на ТЭВЗ с 1961 по 1976 годы, а также НЭВЗ с 1969 по 1976 годы." +
                             " Механическую часть для всех электровозов выпускал НЭВЗ.";
            var expectedText = sourceText;
            var sourceCategory = NoteCategory.Work;
            var expectedCategory = sourceCategory;

            // Act
            var note = new Note(sourceName, sourceText, sourceCategory);
            var actualName = note.Name;
            var actualText = note.Text;
            var actualCategory = note.Category;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedName, actualName);
            NUnit.Framework.Assert.AreEqual(expectedText, actualText);
            NUnit.Framework.Assert.AreEqual(expectedCategory, actualCategory);
        }

        [Test]
        public void Clone_GoodData_ReturnsSameData()
        {
            // Setup
            var sourceName = "ЭД4 — серия электропоездов постоянного тока";
            var expectedName = sourceName;
            var sourceText = "Первый шестивагонный электропоезд ЭД4 - 0001 был изготовлен в 1996 году и к 13 марта 1997 года прошёл " +
                             "испытания на экспериментальном кольце ВНИИЖТ.Основные показатели при испытаниях соответствовали электропоезду ЭД2Т.";
            var expectedText = sourceText;
            var sourceCategory = NoteCategory.Work;
            var expectedCategory = sourceCategory;
            var sourceNote = new Note(sourceName, sourceText, sourceCategory);
            
            // Act
            var expectedNote = (Note) sourceNote.Clone();
            var actualName = expectedNote.Name;
            var actualText = expectedNote.Text;
            var actualCategory = expectedNote.Category;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedName, actualName);
            NUnit.Framework.Assert.AreEqual(expectedText, actualText);
            NUnit.Framework.Assert.AreEqual(expectedCategory, actualCategory);
        }
    }
}
