using System;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Unity_one_love.FieldsOfMiraclesTestTask
{
    public class WordsGenerator : MonoBehaviour
    {
        private string path =
            "D:\\Unity\\FieldOfMiraclesTestTask\\FieldOfMiraclesTestTask\\Assets\\Internal\\Resources\\StaticData\\TextFiles\\OriginalTextOfAlicesBook.txt";

        string text;
        int minLength;
        private int currentWordIndex;

        private string[] words;

        string[] dlm = { " ", "\n", ".", ",", "`", "!", "?", ";", ":", "(", ")", "-", "'", "\"", "[", "]", "_", "*" };

        private ResourceProvider resourceProvider = new();

        public event Action OnWordsOver;

        public void Init(GameType gameType)
        {
            if (gameType == GameType.Restart)
                minLength = resourceProvider.GetGameSettings().WordMinLength;
        }

        private string[] GetRandomWordArray()
        {
            return text.Split(dlm, StringSplitOptions.RemoveEmptyEntries)
                .Where(word => !string.IsNullOrEmpty(word) && word.Length >= minLength)
                .Select(s => s.ToUpper()).Distinct().OrderBy(w => Guid.NewGuid()).ToArray();
        }

        private string[] GetWordArray()
        {
            return text.Split(dlm, StringSplitOptions.RemoveEmptyEntries)
                .Where(word => !string.IsNullOrEmpty(word))
                .Select(s => s.ToUpper()).Distinct().OrderByDescending(w => w.Length).ToArray();
        }

        public string GetWord(GameType gameType)
        {
            if (gameType == GameType.Restart)
            {
                ReadFile();
                currentWordIndex = 0;
                words = GetRandomWordArray();
            }

            if (currentWordIndex >= words.Length)
            {
                OnWordsOver?.Invoke();
                return null;
            }

            return words[currentWordIndex++];
        }

        private void ReadFile()
        {
            using (StreamReader reader = new StreamReader(path))
            {
                text = reader.ReadToEnd();
            }
        }

        public int GetMaxWordLength()
        {
            ReadFile();
            Debug.Log(path);
            return GetWordArray().FirstOrDefault().Length;
        }

        public int GetMinWordLength()
        {
            ReadFile();
            return GetWordArray().LastOrDefault().Length;
        }
    }
}