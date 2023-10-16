using System;
using AudioManager;
using Common;
using ContainersSystem;
using ItemsSystem;
using ItemsSystem.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace LevelsSystem.Levels
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField] private GameObject starsPanel;
        [SerializeField] private Image levelAvatarImage;
        [SerializeField] private TextMeshProUGUI levelNumber;
        [SerializeField] private int maxItemsToSpawn;
        [SerializeField] private int starsCount;
        [SerializeField] private Sound soundOnLevel;
        [SerializeField] private int numberOfStarsToUnlockLevel;

        private GameObject levelsWindow;
        private GameObject gameplayWindow;
        
        
        public LevelDataSO LevelDataSO { get; private set; }
        public Image LevelAvatarImage => levelAvatarImage;
        public TextMeshProUGUI LevelNumber => levelNumber;
        public int MaxItemsToSpawn => maxItemsToSpawn;
        public int StarsCount { get; set; }
        public int NumberOfStarsToUnlockLevel => numberOfStarsToUnlockLevel;

        private void Start()
        {
            levelsWindow = LevelsManager.Instance.LevelsWindow;
            gameplayWindow = LevelsManager.Instance.GameplayWindow;
        }

        public void Initialize(LevelDataSO levelDataSO)
        {
            levelAvatarImage.sprite = levelDataSO.LevelAvatarImage;
            levelNumber.text = levelDataSO.LevelNumber;
            maxItemsToSpawn = levelDataSO.MaxItemsToSpawn;
            soundOnLevel.name = levelDataSO.SoundOnLevel;
            numberOfStarsToUnlockLevel = levelDataSO.NumberOfStarsToUnlockLevel;
        }

        public void OnButtonClick()
        {
            levelsWindow.SetActive(false);
            gameplayWindow.SetActive(true);
            AudioManager.AudioManager.Instance.Play(GameConfig.ButtonSound);
            OnStartLevel();
            
        }
        
        public void OnStartLevel()
        {
            AudioManager.AudioManager.Instance.Play(soundOnLevel.name);
            LevelScoreManager.CurrentLevelStarsPanel = starsPanel;
            MixingList();
            
            for (int i = 0; i < MaxItemsToSpawn ; i++)
            {
                ItemsSpawner.Instance.itemsToSpawn.Add(LevelsManager.Instance.AllItemsDataSOForGame[i]);
                ContainerSpawner.Instance.containersToSpawn.Add(LevelsManager.Instance.AllItemsDataSOForGame[i]);
            }
            
            
            ItemsSpawner.Instance.Initialize(ItemsSpawner.Instance.itemsToSpawn);
            ContainerSpawner.Instance.StartSpawnContainers();
        }
                
        private void MixingList()
        {
            for (int i = 0; i < LevelsManager.Instance.AllItemsDataSOForGame.Count; i++)
            {
                ItemDataSO temp = LevelsManager.Instance.AllItemsDataSOForGame[i];
                int randomIndex = Random.Range(0, LevelsManager.Instance.AllItemsDataSOForGame.Count);
                LevelsManager.Instance.AllItemsDataSOForGame[i] = 
                    LevelsManager.Instance.AllItemsDataSOForGame[randomIndex];
                LevelsManager.Instance.AllItemsDataSOForGame[randomIndex] = temp;
            }
        }
    }
}