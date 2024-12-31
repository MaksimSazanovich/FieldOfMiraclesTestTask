using TMPro;
using UnityEngine;

namespace Unity_one_love.FieldsOfMiraclesTestTask
{
    public class LetterTile : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private GameObject frontground;
        
        public char Letter { get; private set; }
        public void Init(char letter)
        {
            Letter = letter;
            text.text = letter.ToString();
            
            frontground.SetActive(true);
        }

        public void ShowLetter()
        {
            frontground.SetActive(false);
        }
    }
}