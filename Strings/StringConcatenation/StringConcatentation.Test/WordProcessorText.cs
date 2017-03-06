using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using StringConcatenation;

namespace StringConcatentation.Test
{
    [TestFixture]
    public class WordProcessorText
    {
        [Test()]
        [TestCase("f,abcde")]
        [TestCase("f,abcde,f")]
        [TestCase("abcde,f")]
        [TestCase("abcd,ef")]
        [TestCase("abc,def")]
        [TestCase("ab,cdef")]
        [TestCase("a,bcdef")]
        public void Should_GetConcatenatedStrings_Return(string input)
        {
            string finalWord = "abcdef";
            WordProcessor wp = new WordProcessor(input + "," + finalWord);
            var actual = wp.GetFilteredWords();

            var expected = new List<string>() {finalWord};
            Assert.AreEqual(expected, actual.ToList());
        }

        [Test()]
        [TestCase("f,äbčde")]
        public void Should_GetConcatenatedStrings_Return_CultureDependent(string input)
        {
            string finalWord = "äbčdef";
            WordProcessor wp = new WordProcessor(input + "," + finalWord);
            var actual = wp.GetFilteredWords();

            var expected = new List<string>() {finalWord};
            Assert.AreEqual(expected, actual.ToList());
        }

        [Test()]
        [TestCase("ab,ef,f")]
        [TestCase("ab, c, d,e,f")]
        [TestCase("a, b, c, d,df")]
        public void Should_GetConcatenatedStrings_Empty(string input)
        {
            string finalWord = "abcdef";
            WordProcessor wp = new WordProcessor(input + "," + finalWord);
            var actual = wp.GetFilteredWords();

            var expected = new List<string>() {};
            Assert.AreEqual(expected, actual.ToList());
        }

        [Test()]
        [TestCase("input", null)]
        [TestCase("input", "")]
        public void Should_GetConcatenatedStrings_ThrowsInvalidArgumentException_Input(string attributeName, string input)
        {
            Assert.Throws(
                Is.TypeOf<ArgumentNullException>().With.Property("ParamName").EqualTo(attributeName),
                () => new WordProcessor(input));
        }

        [Test()]
        [TestCase("maximumWordsInFinalWord", -1)]
        [TestCase("maximumWordsInFinalWord", 0)]
        public void Should_GetConcatenatedStrings_ThrowsInvalidArgumentException_MaximumWordsInFinalWord(
            string attributeName,
            int maximumWordsInFinalWord)
        {
            Assert.Throws(
                Is.TypeOf<ArgumentOutOfRangeException>().With.Property("ParamName").EqualTo(attributeName),
                () => new WordProcessor("abc", maximumWordsInFinalWord));
        }

        [Test()]
        [TestCase("maximumLenght", -1)]
        [TestCase("maximumLenght", 0)]
        public void Should_GetConcatenatedStrings_ThrowsInvalidArgumentException_MaximumLenght(
            string attributeName,
            int maximumLenght)
        {
            Assert.Throws(
                Is.TypeOf<ArgumentOutOfRangeException>().With.Property("ParamName").EqualTo(attributeName),
                () => new WordProcessor("abc", 2, maximumLenght));
        }
    }
}