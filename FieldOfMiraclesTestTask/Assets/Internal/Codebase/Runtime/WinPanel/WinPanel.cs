using UnityEngine;

namespace Unity_one_love.FieldsOfMiraclesTestTask
{
    public class WinPanel : MonoBehaviour
    {
        [SerializeField] private GameObject winPanel;
        [SerializeField] private LevelController levelController;
        [SerializeField] private RestartButton restartButton;
        
        private void OnEnable()
        {
            levelController.OnWon += ShowWinPanel;
        }

        private void OnDisable()
        {
            levelController.OnWon -= ShowWinPanel;
        }

        public void Init()
        {
            HideWinPanel();
        }

        private void ShowWinPanel()
        {
            winPanel.SetActive(true);
            restartButton.gameObject.SetActive(true);
            Debug.Log("ShowPanel");
        }

        private void HideWinPanel()
        {
            winPanel.SetActive(false);
            restartButton.gameObject.SetActive(false);
            Debug.Log("HilePanel");
        }
    }
}