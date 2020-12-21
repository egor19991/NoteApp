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
        public void Name_GoodName_ReternsSameName()
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
        public void Name_EmptyName_ReternsDefaultName()
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
        public void Text_GoodText_ReternsSameText()
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
        public void Text_EmptyText_ReternsDefaultText()
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
        public void Category_GoodCategory_ReternsSameCategory()
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

    }
}
