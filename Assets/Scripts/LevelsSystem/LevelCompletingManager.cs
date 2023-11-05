using CoinsSystem;
using CollectionSystem;
using Common;
using ContainersSystem;
using ItemsSystem;
using SaveSystem;
using TMPro;
using UnityEngine;

namespace LevelsSystem
{
    public class LevelCompletingManager : Singletone<LevelCompletingManager>
    {
        [Header("ScoreLevelProperties")]
        [SerializeField] private GameObject levelCompletedWindow;

        [SerializeField] private ContainerSpawner containerSpawner;
        [SerializeField] private ItemsSpawner itemsSpawner;
        [SerializeField] private CollectionManager collectionManager;
        [SerializeField] private HealthManager healthManager;
        [SerializeField] private SaveManager saveManager;
        [SerializeField] private PlayerCoins playerCoins;

        [SerializeField] private GameObject coinsPanelOnCompletingLevel;
        
        [SerializeField] private TextMeshProUGUI completedLevel;
        private string completedLevelText;
        
        private int levelCounter = 1;
        public int LevelCounter => levelCounter;
        
        private TimerInLevel timerInLevel;
        
        public override void OnAwake()
        {
            Instance = this;
        }

        private void Start()
        {
            levelCounter = PlayerPrefs.GetInt("currentLevel",levelCounter);
            
            timerInLevel = GetComponent<TimerInLevel>();

            completedLevel.text = completedLevelText;
        }

        private void Update()
        {
            if(timerInLevel.TimerActivation && timerInLevel.CurrentSeconds <= 0f ||
               containerSpawner.ContainersToSpawn.Count == 
               containerSpawner.ContainerCounter &&
               containerSpawner.ContainersToSpawn.Count != 0)
            {
                if (LevelsManager.Instance.CurrentLevelView.MaxItemsToSpawn ==
                    collectionManager.ItemCounterForCollection)
                {
                    levelCounter++;
                    healthManager.AddHealthPerLevel();
                    playerCoins.AddCoins();
                    coinsPanelOnCompletingLevel.SetActive(true);
                    
                    completedLevelText = "Level Completed !";
                }
                
                else
                {
                    coinsPanelOnCompletingLevel.SetActive(false);
                    healthManager.RemoveHealthPerLevel();
                    completedLevelText = "Level Lose !";
                }
                
                completedLevel.text = completedLevelText;
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

            LevelsManager.Instance.LevelCompletedWindow.SetTrigger("CompletedLevelWindowOn");
            LevelsManager.Instance.GameplayWindow.SetTrigger("GameWindowOff");
        }
    }
}