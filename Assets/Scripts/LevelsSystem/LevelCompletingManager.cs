using CollectionSystem;
using Common;
using ContainersSystem;
using ItemsSystem;
using LevelsSystem.Levels;
using SaveSystem;
using UnityEngine;

namespace LevelsSystem
{
    public class LevelCompletingManager : Singletone<LevelCompletingManager>
    {
        [Header("ScoreLevelProperties")]
        [SerializeField] private GameObject levelCompletedWindow;
        [SerializeField] private GameObject gameplayWindow;
        
        [SerializeField] private ContainerSpawner containerSpawner;
        [SerializeField] private ItemsSpawner itemsSpawner;
        [SerializeField] private CollectionManager collectionManager;
        [SerializeField] private HealthManager healthManager;
        [SerializeField] private SaveManager saveManager;
        
        private int levelCounter = 1;
        public int LevelCounter => levelCounter;
        
        private TimerInLevel timerInLevel;

        //[SerializeField] private LevelView nextLevel;
        public override void OnAwake()
        {
            Instance = this;
        }

        private void Start()
        {
            levelCounter = PlayerPrefs.GetInt("currentLevel",levelCounter);
            
            timerInLevel = GetComponent<TimerInLevel>();
        }

        private void Update()
        {
            //nextLevel = LevelsManager.Instance.LevelDataList[levelCounter];
            
            if(timerInLevel.TimerActivation && timerInLevel.CurrentSeconds <= 0f ||
               containerSpawner.ContainersToSpawn.Count == 
               containerSpawner.ContainerCounter &&
               containerSpawner.ContainersToSpawn.Count != 0)
            {
                /*if(LevelsManager.Instance.currentLevelView.MaxItemsToSpawn > collectionManager.ItemCounterForCollection)
                {
                    healthManager.RemoveHealthPerLevel();
                }*/
                
                if (LevelsManager.Instance.CurrentLevelView.MaxItemsToSpawn ==
                    collectionManager.ItemCounterForCollection)
                {
                    levelCounter++;
                    healthManager.AddHealthPerLevel();
                }
                else
                {
                    healthManager.RemoveHealthPerLevel();
                }
                
                OnCompletingTheLevel();
            }

            if (healthManager.CurrentHealth == 0)
            {
                levelCounter = 1;
                healthManager.ResetHealth();
            }
        }
        
        private void OnCompletingTheLevel()
        {
            saveManager.Save();
            
            timerInLevel.TimerActivation = false;
            
            AudioManager.AudioManager.Instance.Play(GameConfig.EndLevelSound);
            
            LevelUnlocking.Instance.UnlockingLevel();
            
            itemsSpawner.CleanUp();
            
            containerSpawner.StopAllCoroutines();
            containerSpawner.CleanUp();
            
            collectionManager.Items.Clear();
            collectionManager.RestartCollectionCounter();
            
            gameplayWindow.SetActive(false);
            levelCompletedWindow.SetActive(true);
        }
    }
}