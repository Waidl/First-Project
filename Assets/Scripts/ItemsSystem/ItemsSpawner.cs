using System.Collections.Generic;
using ItemsSystem.Items;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ItemsSystem
{
    public class ItemsSpawner : Singletone<ItemsSpawner>
    {
        [SerializeField] private ItemView itemViewPrefab;
        
        [SerializeField] private Transform[] spawnPoints;
        
        [SerializeField] private  List<ItemDataSO> itemsToSpawn = new List<ItemDataSO>();
        public List<ItemDataSO> ItemsToSpawn => itemsToSpawn;

        private  List<ItemView> itemsDataList  = new List<ItemView>();
        public List<ItemView> ItemsDataList => itemsDataList;

        private void Start()
        {
            Initialize(itemsToSpawn);
        }
        
        public void Initialize(List<ItemDataSO> itemsData) 
        {
            foreach (var itemData in itemsData)
            {
                SpawnItems(itemData);
            }
        }

        private void SpawnItems(ItemDataSO itemDataSO)
        {
            ItemView itemView = Instantiate(itemViewPrefab,
                spawnPoints[Random.Range(0,spawnPoints.Length)].position,
                Quaternion.identity);
            
            itemView.Initialize(itemDataSO);
            
            itemsDataList.Add(itemView);
        }

        public void CleanUp()
        {
            foreach (var itemView in itemsDataList)
            {
                if(itemView == null)return;
                
                Destroy(itemView.gameObject);
            }
            itemsDataList.Clear();
            itemsToSpawn.Clear();
        }

        public override void OnAwake()
        {
            Instance = this;
        }
    }
}
