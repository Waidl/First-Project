using System;
using System.Collections.Generic;
using Common;
using ContainersSystem;
using ItemsSystem;
using ItemsSystem.Items;
using LevelsSystem.Levels;
using TMPro;
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
        //[SerializeField] public List<LevelView> completedLevels;
        private LevelView currentLevelView;
        public LevelView CurrentLevelView => currentLevelView;

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
            currentLevelView.OnStartLevel();
            currentLevelNumber.text = currentLevelView.LevelNumber.ToString();
        }

    }
}