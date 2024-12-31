using System;
using UnityEngine;

namespace Unity_one_love.FieldsOfMiraclesTestTask
{
    public class NumberOfAttemtsController : MonoBehaviour
    {
        public int NumberOfAttemts { get; private set; }

        private ResourceProvider resourceProvider = new();

        [SerializeField] private WordChecker wordChecker;
        [SerializeField] private NumberOfAttemtesView view;

        public event Action OnNumberOfAttemtsOver;

        public void Init(GameType gameType)
        {
            if (gameType == GameType.Restart)
                NumberOfAttemts = resourceProvider.GetGameSettings().NumberOfAttempts;
            view.SetValue(NumberOfAttemts);
        }

        private void OnEnable()
        {
            wordChecker.OnNotFoundLetter += DecreaseNumberOfAttemts;
        }

        private void DecreaseNumberOfAttemts()
        {
            NumberOfAttemts--;

            if (NumberOfAttemts <= 0)
                OnNumberOfAttemtsOver?.Invoke();
            else
                view.SetValue(NumberOfAttemts);
        }
    }
}