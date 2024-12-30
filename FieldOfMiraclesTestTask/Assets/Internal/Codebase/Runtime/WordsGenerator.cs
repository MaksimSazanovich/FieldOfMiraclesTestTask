using System;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Unity_one_love.FieldsOfMiraclesTestTask
{
    public class WordsGenerator
    {
        private string path = "D:\\Unity\\FieldOfMiraclesTestTask\\FieldOfMiraclesTestTask\\Assets\\Internal\\Resources\\StaticData\\TextFiles\\OriginalTextOfAlicesBook.txt";
        string text;
        int minLength;
        private int currentWordIndex;

        private string[] words;

        string[] dlm = { " ", "\n", ".", ",", "`", "!", "?", ";", ":", "(", ")", "-", "'", "\"", "[", "]", "_", "*" };

        public void Init()
        {
            minLength = Resources.Load<GameSettings>(ConfigsPaths.GameSettingsPath).WordMinLength;
        }

        public string GetWord()
        {
            using (StreamReader reader = new StreamReader(path))
            {
                text = reader.ReadToEnd();
            }

            string[] words = GetRandomWordArray();
            
            return words[currentWordIndex++];
        }

        private string[] GetRandomWordArray()
        {
            return text.Split(dlm, StringSplitOptions.RemoveEmptyEntries)
                .Where(word => !string.IsNullOrEmpty(word) && word.Length >= minLength)
                .Select(s => s.ToUpper()).Distinct().OrderBy(w => Guid.NewGuid()).ToArray();
        }
    }
}