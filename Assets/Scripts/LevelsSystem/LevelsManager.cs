using System.Collections.Generic;
using ItemsSystem.Items;
using LevelsSystem.Levels;
using TMPro;
using UnityEngine;

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
        [SerializeField] private Animator gameplayWindow;
        public Animator GameplayWindow => gameplayWindow;
        
        [SerializeField] private Animator levelCompletedWindow;
        public Animator LevelCompletedWindow => levelCompletedWindow;

        [SerializeField] private TextMeshProUGUI currentLevelNumber;
        
        [Header("LevelsProperties")]
        [SerializeField] private LevelView currentLevelView;
        public LevelView CurrentLevelView => currentLevelView;
        
        [SerializeField] private int completedLevelsNumbers;
        public int CompletedLevelsNumbers => completedLevelsNumbers;

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
        }
        
        public void StartGame()
        {
            currentLevelNumber.text = currentLevelView.LevelNumber.ToString();
            
            currentLevelView.OnStartLevel();
            
            gameplayWindow.SetTrigger("GameWindowOn");

            AddLevelInCompletedLevelsCounter();
        }

        public void AddLevelInCompletedLevelsCounter()
        {
            completedLevelsNumbers++;
        }
    }
}