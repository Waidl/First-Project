using System;
using LevelsSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    public class Tutorial : MonoBehaviour
    {
        [SerializeField] private GameObject firstTutorialTextPanel;
        [SerializeField] private GameObject monk;
        [SerializeField] private Button pauseButton;
        
        public void OnTutorial()
        {
            if (LevelsManager.Instance.CompletedLevelsNumbers > 0)
            {
                pauseButton.enabled = false;
                monk.SetActive(true);
                firstTutorialTextPanel.SetActive(true);
                PauseManager.Instance.OnPause();
            }
            else
            {
                return;
            }
        }

        public void OffTutorial()
        {
            pauseButton.enabled = true;
            PauseManager.Instance.ExitOnPause();
            monk.SetActive(false);
        }
    }
}
