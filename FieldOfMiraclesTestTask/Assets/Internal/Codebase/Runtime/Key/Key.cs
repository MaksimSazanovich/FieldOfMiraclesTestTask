using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Unity_one_love.FieldsOfMiraclesTestTask
{
    public class Key : MonoBehaviour
    {
        [SerializeField] private TMP_Text letterText;
        [SerializeField] private Button button;

        private char letter;
        public static event Action<char> OnKeyPressed;

        public void Init(char letter)
        {
            this.letter = letter;
            letterText.text = letter.ToString();
        }

        private void Start()
        {
            button.onClick.AddListener(() =>
            {
                OnKeyPressed?.Invoke(letter);
            });
        }
    }
}
