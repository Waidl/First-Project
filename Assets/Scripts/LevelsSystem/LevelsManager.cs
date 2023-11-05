using System.Collections.Generic;
using ItemsSystem.Items;
using LevelsSystem.Levels;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LevelsSystem
{
    public class LevelsManager : Singletone<LevelsManager>
    {
        [Header("DataListsProperties")]
        [SerializeField] private List<ItemDataSO> allItemsDataSOForGame = new List<ItemDataSO>();
        public List<ItemDataSO> AllItemsDataSOForGame => allItemsDataSOForGame;
        
        [SerializeField] public List<LevelView> levelDataList = new List<LevelView>();
        public List<LevelView> LevelDataList => levelDataList;
        
        private List<GameObject> allLevelDataList = new List<GameObject>();
        public List<GameObject> AllLevelDataList => allLevelDataList;
        
        [Header("GameWindowSettings")]
        [SerializeField] private GameObject gameplayWindow;
        public GameObject GameplayWindow => gameplayWindow;
        
        [SerializeField] private GameObject levelManager;
        public GameObject LevelManager => levelManager;

        [SerializeField] private Animator menuWindow;
        
        [SerializeField] private TextMeshProUGUI currentLevelNumber;
        
        [Header("LevelsProperties")]
        [SerializeField] private LevelView currentLevelView;
        public LevelView CurrentLevelView => currentLevelView;
        
        [SerializeField] private int completedLevelsNumbers;
        public int CompletedLevelsNumbers => completedLevelsNumbers;
        
        [SerializeField] private GameObject levelsWindow;
        public GameObject LevelsWindow => levelsWindow;
        
        [SerializeField] private Sprite[] backgrounds;
        
        [SerializeField] private Image gameplayBackground;

        
        
        
        
        private void Start()
        {
            completedLevelsNumbers = PlayerPrefs.GetInt("completedLevels");
        }

        public override void OnAwake()
        {
            Instance = this;
        }
        
        private void Update()
        {
            currentLevelView = levelDataList[LevelCompletingManager.Instance.LevelCounter-1];
            //LevelBackground();
        }
        
        public void StartGame()
        {
            currentLevelNumber.text = currentLevelView.LevelNumber.ToString();
            
            currentLevelView.OnStartLevel();

            AddLevelInCompletedLevelsCounter();
        }

        public void AddLevelInCompletedLevelsCounter()
        {
            completedLevelsNumbers++;
        }

        private void LevelBackground()
        {
            if (currentLevelView.LevelDataSO.LevelNumber / 2 == 0)
            {
                gameplayBackground.sprite = backgrounds[1];
            }
        }
    }
}