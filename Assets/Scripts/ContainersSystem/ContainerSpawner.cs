using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Items;
using ItemsSystem;
using LevelsSystem;
using UnityEngine;

namespace ContainersSystem
{
    public class ContainerSpawner : Singletone<ContainerSpawner>
    {
        [SerializeField] public ItemView containerPrefab;
        [SerializeField] private Transform spawnPoint;
        
        [SerializeField] public List<ItemDataSO> containersToSpawn = new List<ItemDataSO>();
        
        [SerializeField] public List<ItemView> containersDataList = new List<ItemView>();

        public int containerCounter;

        private void Start()
        {
            StartSpawnContainers();
        }

        public void StartSpawnContainers()
        {
            StartCoroutine(SpawnerCoroutine(containersToSpawn));
        }
        private void SpawnContainers(ItemDataSO itemDataSO)
        {
            ItemView itemView = Instantiate(containerPrefab, spawnPoint);
            
            itemView.Initialize(itemDataSO);
            
            containersDataList.Add(itemView);
        }

        public IEnumerator SpawnerCoroutine(List<ItemDataSO> itemsData)
        {
            foreach (var itemData in itemsData)
            {
                while (containersDataList.Count != 0)
                {
                    yield return null;
                }
                SpawnContainers(itemData);
            }
        }
        public void CleanUp()
        {
            foreach (var itemView in containersDataList)
            {
                if(itemView==null)return;
                Destroy(itemView.gameObject);
            }
            containersDataList.Clear();
            containersToSpawn.Clear();
            containerCounter = 0;
        }
        
        public override void OnAwake()
        {
            Instance = this;
        }
    }
}