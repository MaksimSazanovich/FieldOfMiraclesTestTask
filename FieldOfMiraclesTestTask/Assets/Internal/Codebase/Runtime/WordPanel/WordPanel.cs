using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Unity_one_love.FieldsOfMiraclesTestTask
{
    public class WordPanel : MonoBehaviour
    {
        [SerializeField] private RectTransform root;
        private LetterTileFactory letterTileFactory = new();

        [SerializeField] private WordChecker wordChecker;

        private List<LetterTile> letterTiles = new();
        private List<LetterTile> showingLetterTiles = new();

        private int wordLength;
        private string word;
        

        private void OnEnable()
        {
            wordChecker.OnFoundLetter += ShowLetters;
        }

        private void OnDisable()
        {
            wordChecker.OnFoundLetter -= ShowLetters;
        }

        public void Init(string word)
        {
            if (word == null)
                return;
            
            if (this.word != null)
            {
                DespawnPanel();
            }

            this.word = word;
            wordLength = word.Length;
            
            SpawnPanel();
        }

        private void SpawnPanel()
        {
            letterTiles.Clear();
            for (int i = 0; i < wordLength; i++)
            {
                letterTiles.Add(letterTileFactory.CreateLetterTile(word[i], root.transform));
            }
        }

        private void DespawnPanel()
        {
            foreach (LetterTile letterTile in letterTiles)
            {
                Destroy(letterTile.gameObject);
            }
        }

        private void ShowLetters(char letter)
        {
            showingLetterTiles = letterTiles.Where(w => w.Letter == letter).ToList();

            foreach (var showingLetterTile in showingLetterTiles)
            {
                showingLetterTile.ShowLetter();
            }
        }
    }
}