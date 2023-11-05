using System;
using LevelsSystem;
using UnityEngine;

namespace Common
{
    public class Tutorial : MonoBehaviour
    {
        [SerializeField] private GameObject firstTutorialTextPanel;
        [SerializeField] private GameObject monk;
        
        public void OnTutorial()
        {
            if (LevelsManager.Instance.CurrentLevelView.LevelNumber == 1)
            {
                monk.SetActive(true);
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
