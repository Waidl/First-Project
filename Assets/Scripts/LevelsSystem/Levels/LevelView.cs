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
        [SerializeField] private GameObject[] starsOnLevel;
        [SerializeField] private Image levelAvatarImage;
        [SerializeField] private TextMeshProUGUI levelNumber;
        [SerializeField] private int maxItemsToSpawn;
        [SerializeField] private int starsCount;
        [SerializeField] private Sound soundOnLevel;
        [SerializeField] private int numberOfStarsToUnlockLevel;

        private GameObject levelsWindow;
        private GameObject gameplayWindow;
        
        
        public LevelDataSO LevelDataSO { get; private set; }
        public int StarsCount
        {
            get => starsCount;
            set => starsCount = value;
        }

        public Image LevelAvatarImage => levelAvatarImage;
        public TextMeshProUGUI LevelNumber
        {
            get => levelNumber;
            set => levelNumber = value;
        }

        public int MaxItemsToSpawn => maxItemsToSpawn;
        public int NumberOfStarsToUnlockLevel => numberOfStarsToUnlockLevel;
        public Sound SoundOnLevel => soundOnLevel;

        public GameObject[] StarsOnLevel => starsOnLevel;

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
            CounterStarsOnLevels.Instance.currentLevelStars = CounterStarsOnLevels.Instance.starsOnLevel;
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