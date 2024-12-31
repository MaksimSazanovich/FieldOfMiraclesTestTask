using UnityEngine;

namespace Unity_one_love.FieldsOfMiraclesTestTask
{
    public class LosePanel : MonoBehaviour
    {
        [SerializeField] private GameObject losePanel;
        [SerializeField] private LevelController levelController;
        [SerializeField] private RestartButton restartButton;
        

        private void OnEnable()
        {
            levelController.OnLost += ShowLosePanel;
        }

        private void OnDisable()
        {
            levelController.OnLost -= ShowLosePanel;
        }

        public void Init()
        {
            HideLosePanel();
        }

        private void ShowLosePanel()
        {
            losePanel.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }

        private void HideLosePanel()
        {
            losePanel.SetActive(false);
            restartButton.gameObject.SetActive(false);
        }
    }
}