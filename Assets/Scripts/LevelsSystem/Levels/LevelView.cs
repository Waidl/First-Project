using System;
using ContainersSystem;
using Items;
using ItemsSystem;
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
        [SerializeField] public  int maxItemsToSpawn;
        [SerializeField] private int starsCount;

        private GameObject levelsWindow;
        private GameObject gameplayWindow;
        
        
        public LevelDataSO LevelDataSO { get; private set; }
        public Image LevelAvatarImage => levelAvatarImage;
        public TextMeshProUGUI LevelNumber => levelNumber;
        public int MaxItemsToSpawn => maxItemsToSpawn;
        public int StarsCount => starsCount;
        public GameObject StarsPanel => starsPanel;

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

        }

        public void OnButtonClick()
        {
            levelsWindow.SetActive(false);
            gameplayWindow.SetActive(true);
            FindObjectOfType<AudioManager.AudioManager>().Play("Click");
            OnStartLevel();
            
        }
        
        public void OnStartLevel()
        {
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