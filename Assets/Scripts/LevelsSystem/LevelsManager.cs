using System;
using System.Collections.Generic;
using Common;
using ContainersSystem;
using ItemsSystem;
using ItemsSystem.Items;
using LevelsSystem.Levels;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LevelsSystem
{
    public class LevelsManager : Singletone<LevelsManager>
    {
        [Header("DataProperties")]
        [SerializeField] private List<ItemDataSO> allItemsDataSOForGame = new List<ItemDataSO>();
        public List<ItemDataSO> AllItemsDataSOForGame => allItemsDataSOForGame;
        
        [SerializeField] public List<LevelView> levelDataList  = new List<LevelView>();
        public List<LevelView> LevelDataList => levelDataList;
        
        private List<GameObject> allLevelDataList  = new List<GameObject>();
        public List<GameObject> AllLevelDataList => allLevelDataList;
        
        [Header("GameWindow")]
        [SerializeField] private GameObject levelsWindow;
        public GameObject LevelsWindow => levelsWindow;
        
        [SerializeField] private GameObject gameplayWindow;
        public GameObject GameplayWindow => gameplayWindow;
        
        [SerializeField] private GameObject levelManager;
        public GameObject LevelManager=>levelManager;
        
        [Header("LevelsProperties")]
        [SerializeField] public List<LevelView> completedLevels;
        
        public LevelView currentLevelView;

        public override void OnAwake()
        {
            Instance = this;
        }
        
        public void StartGame()
        {
            currentLevelView.OnStartLevel();
        }

        private void Update()
        {
            currentLevelView = levelDataList[LevelCompletingManager.Instance.LevelCounter-1];
            
        }
    }
}