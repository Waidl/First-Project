using System.Collections.Generic;
using LevelsSystem.Levels;
using Unity.VisualScripting;
using UnityEngine;

namespace LevelsSystem
{
    public class LevelSpawner : Singletone<LevelSpawner>
    {
        [SerializeField] private LevelView levelViewPrefab;
        [SerializeField] private Transform spawnPoint;
        
        [SerializeField] public List<LevelDataSO> levelsToSpawn;


        private void Start()
        {
            Initialize(levelsToSpawn);
        }
        
        public void Initialize(List<LevelDataSO> levelsData) 
        {
            foreach (var levelData in levelsData)
            {
                SpawnLevels(levelData);
            }
        }

        private void SpawnLevels( LevelDataSO levelDataSO)
        {
            LevelView levelView = Instantiate(levelViewPrefab, spawnPoint);
            
            levelView.Initialize(levelDataSO);
            
            LevelsManager.Instance.LevelDataList.Add(levelView);
            LevelsManager.Instance.AllLevelDataList.Add(gameObject);
        }

        public void CleanUp()
        {
            foreach (var itemView in LevelsManager.Instance.LevelDataList)
            {
                if(itemView == null)return;
                
                Destroy(itemView.gameObject);
            }
            LevelsManager.Instance.LevelDataList.Clear();
            levelsToSpawn.Clear();
        }

        public override void OnAwake()
        {
            Instance = this;
        }
    }
}