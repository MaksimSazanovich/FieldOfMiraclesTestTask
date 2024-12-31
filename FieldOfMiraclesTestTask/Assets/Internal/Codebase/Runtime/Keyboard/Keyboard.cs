using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Unity_one_love.FieldsOfMiraclesTestTask
{
    public class Keyboard : MonoBehaviour
    {
        [SerializeField] private Key[] keys;
        private string letters = "QWERTYUIOPASDFGHJKLZXCVBNM";

        private List<KeyLetter> keyLetters = new();

        private int keysLength;

        public void Init()
        {
            if (keyLetters.Any() == false)
            {
                keysLength = keys.Length;

                for (int i = 0; i < keysLength; i++)
                {
                    keys[i].Init(letters[i]);
                    keyLetters.Add(new(letters[i], keys[i]));
                }
            }

            ShowKeys();
        }

        private void OnEnable()
        {
            Key.OnKeyPressed += HideKey;
        }

        private void OnDisable()
        {
            Key.OnKeyPressed -= HideKey;
        }

        private void ShowKeys()
        {
            foreach (var key in keys)
            {
                if (!key.gameObject.activeSelf)
                    key.gameObject.SetActive(true);
            }
        }

        private void HideKey(char letter)
        {
            var key = keyLetters.FirstOrDefault(k => (k.Letter == letter));
            key.Key.gameObject.SetActive(false);
        }
    }

    public struct KeyLetter
    {
        public char Letter { get; private set; }
        public Key Key { get; private set; }

        public KeyLetter(char letter, Key key)
        {
            Letter = letter;
            Key = key;
        }
    }
}