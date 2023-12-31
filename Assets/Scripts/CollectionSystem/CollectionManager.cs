﻿using System.Collections.Generic;
using Common;
using ContainersSystem;
using ItemsSystem;
using ItemsSystem.Items;
using UnityEngine;

namespace CollectionSystem
{
    public class CollectionManager : Singletone<CollectionManager>
    {
        [Header("CollectionProperties")]
        [SerializeField] private List<GameObject> items;
        
        [SerializeField] private float moveSpeed = 1f;
        
        [SerializeField] private int itemCounterForCollection;
        public int ItemCounterForCollection => itemCounterForCollection;
        
        public List<GameObject> Items => items;
        
 

        public override void OnAwake()
        {
            Instance = this;
        }

        private void Update()
        {
            if (items.Count < 2) return;

            if (items.Count > 2)
            {
                items.Clear();
            }

            if (items[1].GetComponent<ItemsMovements>() != null)
            {
                items[0] = items[1];
                items.Remove(items[1]);
            }

            if (items.Count == 2 && items[1].GetComponent<ContainerMoveToWaitPoint>() != null)
            {
                if (items[0].GetComponent<ItemView>().ItemName == items[1].GetComponent<ItemView>().ItemName)
                {
                    Сollecting();
                }
                else
                {
                    Items.Clear();
                }
            }
        }

        public void RestartCollectionCounter()
        {
            itemCounterForCollection = 0;
        }
    
        private void Сollecting()
        {
            items[0].GetComponent<ItemsMovements>().enabled = false;
        
            Vector2 newPosition = Vector2.MoveTowards(
                items[0].transform.position,
                items[1].transform.position,
                moveSpeed *Time.deltaTime);
        
            items[0].transform.position = newPosition;

            if (items[0].transform.position == items[1].transform.position)
            {
                AudioManager.AudioManager.Instance.Play(GameConfig.CollectedSound);
                items[1].GetComponent<ContainerMoveToWaitPoint>().OnAttack();

                Destroy(items[0]);
                
                ItemsSpawner.Instance.ItemsDataList.Remove(items[0].GetComponent<ItemView>());
                
                items.Clear();
                
                itemCounterForCollection++;
            }
        }
    }
}