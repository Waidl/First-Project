using System.Collections;
using System.Collections.Generic;
using ItemsSystem.Items;
using UnityEngine;

namespace ContainersSystem
{
    public class ContainerSpawner : Singletone<ContainerSpawner>
    {
        [Header("ContainerSpawnerProperties")]
        [SerializeField] private ItemView containerPrefab;
        [SerializeField] private Transform spawnPoint;
        
        [SerializeField] private List<ItemDataSO> containersToSpawn = new List<ItemDataSO>();
        public List<ItemDataSO> ContainersToSpawn => containersToSpawn;
        
        private List<ItemView> containersDataList = new List<ItemView>();
        public List<ItemView> ContainersDataList => containersDataList;
        
        private int containerCounter;
        public int ContainerCounter => containerCounter;
        
        public override void OnAwake()
        {
            Instance = this;
        }

        private void Start()
        {
            StartSpawnContainers();
        }

        public void IncreaseCounter()
        {
            containerCounter++;
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

        private IEnumerator SpawnerCoroutine(List<ItemDataSO> itemsData)
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
    }
}