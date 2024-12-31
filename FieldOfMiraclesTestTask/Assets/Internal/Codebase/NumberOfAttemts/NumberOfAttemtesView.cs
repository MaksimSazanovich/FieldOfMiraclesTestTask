using TMPro;
using UnityEngine;

namespace Unity_one_love.FieldsOfMiraclesTestTask
{
    public class NumberOfAttemtesView : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        private string str = "Number of attemts : ";

        public void SetValue(int value)
        {
            text.text = str + value;
        }
    }
}