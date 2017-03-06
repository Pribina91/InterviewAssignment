using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringConcatenation
{
    public class WordProcessor
    {
        private readonly string[] inputs;
        private readonly int maximumWordsInFinalWord;
        private readonly int maximumLenght;

        public WordProcessor(string input, int maximumWordsInFinalWord = 2, int maximumLenght = 6)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (maximumWordsInFinalWord < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(maximumWordsInFinalWord));
            }

            if (maximumLenght < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(maximumLenght));
            }

            this.maximumLenght = maximumLenght;
            this.maximumWordsInFinalWord = maximumWordsInFinalWord;
            this.inputs = input
                .Split(
                    new[] {','},
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .Where(s => !string.IsNullOrEmpty(s) && s.Length <= maximumLenght)
                .ToArray();
        }

        public IEnumerable<string> GetFilteredWords()
        {
            //we filter inputs values only for strings of expected lenght
            foreach (var finalWord in inputs.Where(s => s.Length == this.maximumLenght))
            {
                //search inputs for subwords 
                var subwords = inputs.Where(i => finalWord != i && finalWord.Contains(i)).ToList();

                //check if subwords can make actual word 
                if (subwords.Any()
                    && CabSubwordsMakeOneWord(subwords, finalWord))
                {
                    yield return finalWord;
                }
            }
        }

        private bool CabSubwordsMakeOneWord(List<string> subwords, string finalWord)
        {
            if (subwords == null)
            {
                throw new ArgumentNullException(nameof(subwords));
            }

            subwords = subwords.Where(s => !string.IsNullOrEmpty(s.Trim())).ToList();
            var permutations = GetPermutations(subwords, this.maximumWordsInFinalWord);

            foreach (var permutation in permutations)
            {
                var concatenatedWord = string.Join(string.Empty, permutation.ToArray());
                if (string.Compare(concatenatedWord, finalWord, StringComparison.CurrentCulture) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1)
            {
                return list.Select(t => new T[] {t});
            }

            return GetPermutations(list, length - 1)
                .SelectMany(
                    t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] {t2}));
        }
    }
}