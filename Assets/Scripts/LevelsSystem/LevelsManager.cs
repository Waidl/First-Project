using System;
using System.Collections.Generic;
using Items;
using LevelsSystem.Levels;
using UnityEngine;

namespace LevelsSystem
{
    public class LevelsManager : Singletone<LevelsManager>
    {
        [SerializeField] private List<ItemDataSO> allItemsDataSOForGame = new List<ItemDataSO>();
        public List<ItemDataSO> AllItemsDataSOForGame => allItemsDataSOForGame;
        
        [SerializeField] private List<LevelView> levelDataList  = new List<LevelView>();
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

        private void Start()
        {
            FindObjectOfType<AudioManager.AudioManager>().Play("MenuSound");
        }
        public void StartGame()
        {
            FindObjectOfType<AudioManager.AudioManager>().Play("MenuSound");
            
            levelDataList[LevelScoreManager.Instance.level-1].OnStartLevel();
        }

        
    }
}