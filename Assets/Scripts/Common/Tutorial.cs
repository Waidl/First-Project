using System;
using LevelsSystem;
using UnityEngine;

namespace Common
{
    public class Tutorial : MonoBehaviour
    {
        [SerializeField] private GameObject firstTutorialTextPanel;
        
        public void OnTutorial()
        {
            if (LevelsManager.Instance.CurrentLevelView.LevelNumber == 1)
            {
                firstTutorialTextPanel.SetActive(true);
                PauseManager.Instance.OnPause();
            }
            else
            {
                return;
            }
        }
    }
}
