using UnityEngine;

namespace Unity_one_love.FieldsOfMiraclesTestTask
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private WordsGenerator wordsGenerator;
        [SerializeField] private WordPanel wordPanel;
        [SerializeField] private Keyboard keyboard;
        [SerializeField] private WordChecker wordChecker;
        [SerializeField] private NumberOfAttemtsController numberOfAttemtsController;
        [SerializeField] private LevelController levelController;
        [SerializeField] private LosePanel losePanel;
        [SerializeField] private WinPanel winPanel;
        [SerializeField] private ScoreController scoreController;
        

        private string word;
        private void Awake()
        {
            Restart(GameType.Restart);
        }

        private void OnEnable()
        {
            levelController.OnNextLevel += Restart;
            levelController.OnRestarted += Restart;
        }
        
        private void OnDisable()
        {
            levelController.OnNextLevel -= Restart;
            levelController.OnRestarted -= Restart;
        }

        private void Restart(GameType gameType)
        {
            if(gameType == GameType.Restart)
                Debug.Log("Restarting game");
            else if(gameType == GameType.Continue)
                Debug.Log("Continue game");
            numberOfAttemtsController.Init(gameType);
            losePanel.Init();
            winPanel.Init();
            scoreController.Init(gameType);
            
            wordsGenerator.Init(gameType);
            word = wordsGenerator.GetWord(gameType);
            wordPanel.Init(word);
            wordChecker.Init(word);
            keyboard.Init();
        }
    }
}