using System;
using UnityEngine;
using UnityEngine.UI;

namespace Unity_one_love.FieldsOfMiraclesTestTask
{
    public class RestartButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        public event Action OnButtonClicked;
        private void Start()
        {
            button.onClick.AddListener(InvokeOnButtonClicked);
        }
        
        private void InvokeOnButtonClicked()
        {
            Debug.Log("Button clicked");
            OnButtonClicked?.Invoke();
        }
    }
}