using UnityEngine;

namespace Unity_one_love.FieldsOfMiraclesTestTask
{
    public class ScoreController : MonoBehaviour
    {
        public int Score { get; private set; }
        [SerializeField] private WordChecker wordChecker;
        [SerializeField] private NumberOfAttemtsController numberOfAttemtsController;
        [SerializeField] private ScoreView view;

        public void Init(GameType gameType)
        {
            if (gameType == GameType.Restart)
            {
                Score = 0;
                view.SetValue(Score);
            }
        }

        private void OnEnable()
        {
            wordChecker.OnFoundWord += AddScore;
        }
        
        private void OnDisable()
        {
            wordChecker.OnFoundWord -= AddScore;
        }

        private void AddScore()
        {
            Score += numberOfAttemtsController.NumberOfAttemts;
            view.SetValue(Score);
        }
    }
}