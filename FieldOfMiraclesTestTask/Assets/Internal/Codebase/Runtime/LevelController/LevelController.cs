using System;
using UnityEngine;

namespace Unity_one_love.FieldsOfMiraclesTestTask
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private WordChecker wordChecker;
        [SerializeField] private NumberOfAttemtsController numberOfAttemtsController;
        [SerializeField] private RestartButton restartButton;
        [SerializeField] private WordsGenerator wordsGenerator;
        
        
        public event Action<GameType> OnNextLevel;
        public event Action OnLost;
        public event Action OnWon;
        public event Action<GameType> OnRestarted;
        
        private void OnEnable()
        {
            wordChecker.OnFoundWord += InvokeNextLevel;
            numberOfAttemtsController.OnNumberOfAttemtsOver += InvokeLost;
            restartButton.OnButtonClicked += InvokeOnRestarted;
            wordsGenerator.OnWordsOver += InvokeWon;
        }

        private void OnDisable()
        {
            wordChecker.OnFoundWord -= InvokeNextLevel;
            numberOfAttemtsController.OnNumberOfAttemtsOver -= InvokeLost;
            restartButton.OnButtonClicked -= InvokeOnRestarted;
            wordsGenerator.OnWordsOver -= InvokeWon;
        }

        private void InvokeNextLevel()
        {
            OnNextLevel?.Invoke(GameType.Continue);
        }

        private void InvokeLost()
        {
            OnLost?.Invoke();
        }

        private void InvokeWon()
        {
            OnWon?.Invoke();
        }

        private void InvokeOnRestarted()
        {
            OnRestarted?.Invoke(GameType.Restart);
        }
    }
}