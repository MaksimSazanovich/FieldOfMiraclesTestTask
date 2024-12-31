using TMPro;
using UnityEngine;

namespace Unity_one_love.FieldsOfMiraclesTestTask
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        private string str = "Score : ";

        public void SetValue(int value)
        {
            text.text = str + value;
        }
    }
}