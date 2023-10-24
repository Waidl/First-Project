using System;
using CollectionSystem;
using ContainersSystem;
using ItemsSystem;
using LevelsSystem.Levels;
using UnityEngine;

namespace LevelsSystem
{
    public class LevelCompletingManager : Singletone<LevelCompletingManager>
    {
        [Header("ScoreLevelProperties")]
        [SerializeField] private GameObject levelCompletedWindow;
        [SerializeField] private GameObject gameplayWindow;
        
        [SerializeField] private ContainerSpawner containerSpawner;
        
        [SerializeField] private LevelView nextLevel;
        
        private TimerInLevel timerInLevel;
        
        private int levelCounter = 1;

        public int LevelCounter => levelCounter;

        public override void OnAwake()
        {
            Instance = this;
        }

        private void Start()
        {
            timerInLevel = GetComponent<TimerInLevel>();
        }

        private void Update()
        {
            nextLevel = LevelsManager.Instance.LevelDataList[levelCounter];
            
            if(timerInLevel.currentSeconds <= 0f ||
               containerSpawner.ContainersToSpawn.Count == 
               containerSpawner.containerCounter &&
               containerSpawner.ContainersToSpawn.Count != 0)
            {
                CounterStarsOnLevels.Instance.StarsCounter();

                if (LevelsManager.Instance.currentLevelView.LevelNumber == levelCounter &&
                    LevelsManager.Instance.currentLevelView.StarsCount > nextLevel.NumberOfStarsToUnlockLevel)
                {
                    levelCounter++;
                }

                timerInLevel.timerActivation = false;
                containerSpawner.StopAllCoroutines();
                containerSpawner.CleanUp();
                
                OnCompletingTheLevel();
                
                LevelUnlocking.Instance.UnlockLevel();
            }
        }
        
        private void OnCompletingTheLevel()
        {
            ItemsSpawner.Instance.CleanUp();
            ContainerSpawner.Instance.CleanUp();
            
            CollectionManager.Instance.Items.Clear();
            
            gameplayWindow.SetActive(false);
            levelCompletedWindow.SetActive(true);
        }
    }
}