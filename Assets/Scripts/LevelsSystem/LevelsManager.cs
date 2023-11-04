using System;
using System.Collections.Generic;
using Common;
using ContainersSystem;
using ItemsSystem;
using ItemsSystem.Items;
using LevelsSystem.Levels;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

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
        
        [SerializeField] private int completedLevelsNumbers;
        
        [SerializeField] private GameObject levelsWindow;

        public GameObject LevelsWindow => levelsWindow;
        public int CompletedLevelsNumbers => completedLevelsNumbers;
        public LevelView CurrentLevelView => currentLevelView;
        
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

            AddLevelInCompletedLevelsCounter();
        }

        public void AddLevelInCompletedLevelsCounter()
        {
            completedLevelsNumbers++;
        }
    }
}