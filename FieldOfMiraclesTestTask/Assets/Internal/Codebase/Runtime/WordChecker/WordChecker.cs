using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Unity_one_love.FieldsOfMiraclesTestTask
{
    public class WordChecker : MonoBehaviour
    {
        private string word;
        private HashSet<char> wordLetters;
        private int numberOfWords;
        
        public event Action<char> OnFoundLetter;
        public event Action OnNotFoundLetter;
        public event Action OnFoundWord;
        public void Init(string word)
        {
            if (word == null)
                return;
            this.word = word;
            wordLetters = word.ToHashSet();
            numberOfWords = wordLetters.Count;
        }

        private void OnEnable()
        {
            Key.OnKeyPressed += CheckLetterInWord;
        }

        private void OnDisable()
        {
            Key.OnKeyPressed -= CheckLetterInWord;
        }

        private void CheckLetterInWord(char letter)
        {
            if (wordLetters.Contains(letter))
            {
                OnFoundLetter?.Invoke(letter);
                
                numberOfWords--;
                if (numberOfWords <= 0)
                {
                    OnFoundWord?.Invoke();
                }
            }
            else
                OnNotFoundLetter?.Invoke();
        }
    }
}