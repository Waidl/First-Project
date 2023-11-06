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
        [SerializeField] private Image levelAvatarImage;
        [SerializeField] private TextMeshProUGUI levelNumberText;
        [SerializeField] private int maxItemsToSpawn;
        [SerializeField] private float timeOnLevel;
        [SerializeField] private int levelNumber;
        [SerializeField] private int coinsForLevel;

        public LevelDataSO LevelDataSO { get; private set; }
        public Image LevelAvatarImage => levelAvatarImage;
        public int MaxItemsToSpawn => maxItemsToSpawn;
        public float TimeOnLevel => timeOnLevel;
        public int LevelNumber => levelNumber;
        public int CoinsForLevel => coinsForLevel;

        private GameObject levelsWindow;
        private GameObject gameplayWindow;
        
        public void Initialize(LevelDataSO levelDataSO)
        {
            levelAvatarImage.sprite = levelDataSO.LevelAvatarImage;
            levelNumberText.text = levelDataSO.LevelNumber.ToString();
            maxItemsToSpawn = levelDataSO.MaxItemsToSpawn;
            timeOnLevel = levelDataSO.TimeOnLevel;
            levelNumber = levelDataSO.LevelNumber;
            coinsForLevel = levelDataSO.CoinsForLevel;
        }
        
        public void OnStartLevel()
        {
            TimerInLevel.Instance.CurrentSeconds = TimeOnLevel;
            TimerInLevel.Instance.TimerActivation = true;

            MixingList();
            
            for (int i = 0; i < MaxItemsToSpawn ; i++)
            {
                ItemsSpawner.Instance.ItemsToSpawn.Add(LevelsManager.Instance.AllItemsDataSOForGame[i]);
                ContainerSpawner.Instance.ContainersToSpawn.Add(LevelsManager.Instance.AllItemsDataSOForGame[i]);
            }
            
            ItemsSpawner.Instance.Initialize(ItemsSpawner.Instance.ItemsToSpawn);
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