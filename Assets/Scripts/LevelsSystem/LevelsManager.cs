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
        [SerializeField] private List<ItemDataSO> allItemsDataSOForGame = new List<ItemDataSO>();
        public List<ItemDataSO> AllItemsDataSOForGame => allItemsDataSOForGame;
        
        [SerializeField] public List<LevelView> levelDataList  = new List<LevelView>();
        public List<LevelView> LevelDataList => levelDataList;
        
        private List<GameObject> allLevelDataList  = new List<GameObject>();
        public List<GameObject> AllLevelDataList => allLevelDataList;
        
        [SerializeField] private GameObject levelsWindow;
        public GameObject LevelsWindow => levelsWindow;
        
        [SerializeField] private GameObject gameplayWindow;
        public GameObject GameplayWindow => gameplayWindow;

        public override void OnAwake()
        {
            Instance = this;
        }
        
        public void StartGame()
        {
             levelDataList[LevelUnlocking.Instance.level-1].OnStartLevel();
        }
    }
}