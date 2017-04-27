using System;
using NUnit.Framework;
using Tools;
using Tools.libs;

namespace NUnit.Tools
{
    [TestFixture]
    public class ConversionTest
    {
        [Test]
        public void ConversionNumberToRoman()
        {
            Assert.AreEqual(Conversion.ToRoman(1), "I");
            Assert.AreEqual(Conversion.ToRoman(7), "VII");
            Assert.AreEqual(Conversion.ToRoman(10), "X");
            Assert.AreEqual(Conversion.ToRoman(123), "CXXIII");
            Assert.AreEqual(Conversion.ToRoman(1234), "MCCXXXIV");
            Assert.AreEqual(Conversion.ToRoman(4999), "MMMMCMXCIX");
            Assert.Pass("Passing test");
        }

        [Test]
        public void ConversionStringToRoman()
        {
            Assert.AreEqual(Conversion.ToRoman("1"), "I");
            Assert.AreEqual(Conversion.ToRoman("7"), "VII");
            Assert.AreEqual(Conversion.ToRoman("10"), "X");
            Assert.AreEqual(Conversion.ToRoman("123"), "CXXIII");
            Assert.AreEqual(Conversion.ToRoman("1234"), "MCCXXXIV");
            Assert.AreEqual(Conversion.ToRoman("4999"), "MMMMCMXCIX");
            Assert.Pass("Passing test");
        }

        [Test]
        public void ExceptionConversionToRoman()
        {
            Exception exception;
            exception = Assert.Throws<FormatException>(() => Conversion.ToRoman(""));
            Assert.AreEqual("Format non supporté", exception.Message);
            exception = Assert.Throws<FormatException>(() => Conversion.ToRoman("ABC"));
            Assert.AreEqual("Format non supporté", exception.Message);
            exception = Assert.Throws<FormatException>(() => Conversion.ToRoman(0));
            Assert.AreEqual("Doit être compris entre 1 et 4999", exception.Message);
            exception = Assert.Throws<FormatException>(() => Conversion.ToRoman(5000));
            Assert.AreEqual("Nombre supérieur à 4999", exception.Message);
            Assert.Pass("Passing test");
        }
    }

    [TestFixture]
    public class RomanTest
    {
        [Test]
        public void ExceptionRoman()
        {
            Exception exception;
            exception = Assert.Throws<FormatException>(() => Roman.ToString(-1));
            Assert.AreEqual("Doit être compris entre 1 et 4999", exception.Message);
            exception = Assert.Throws<FormatException>(() => Roman.ToString(0));
            Assert.AreEqual("Doit être compris entre 1 et 4999", exception.Message);
            exception = Assert.Throws<FormatException>(() => Roman.ToString(5000));
            Assert.AreEqual("Doit être compris entre 1 et 4999", exception.Message);
            Assert.Pass("Passing test");
        }

        [Test]
        public void RomanToString()
        {
            Assert.AreEqual(Roman.ToString(1), "I");
            Assert.AreEqual(Roman.ToString(7), "VII");
            Assert.AreEqual(Roman.ToString(10), "X");
            Assert.AreEqual(Roman.ToString(123), "CXXIII");
            Assert.AreEqual(Roman.ToString(1234), "MCCXXXIV");
            Assert.AreEqual(Roman.ToString(4999), "MMMMCMXCIX");
            Assert.Pass("Passing test");
        }
    }
}