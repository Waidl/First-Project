using System;
using LevelsSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    public class Tutorial : MonoBehaviour
    {
        [SerializeField] private Animator tutorial;
        [SerializeField] private Animator gameplayWindow;
        [SerializeField] private Animator enemy;
        
        public void OnTutorial()
        {
            if (LevelsManager.Instance.CompletedLevelsNumbers < 2)
            {
                PauseManager.Instance.OnPause();
                tutorial.SetTrigger("OnTutorial");
            }
            else
            {
                gameplayWindow.SetTrigger("GameWindowOn");
                enemy.SetTrigger("EnemyOn");
                LevelsManager.Instance.StartGame();
            }
        }

        public void OffTutorial()
        {
            PauseManager.Instance.ExitOnPause();
            tutorial.SetTrigger("OffTutorial");
        }
    }
}
