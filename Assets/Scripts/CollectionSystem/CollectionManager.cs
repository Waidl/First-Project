using System.Collections.Generic;
using ContainersSystem;
using Items;
using ItemsSystem;
using LevelsSystem;
using Unity.VisualScripting;
using UnityEngine;

namespace CollectionSystem
{
    public class CollectionManager : Singletone<CollectionManager>
    {
        
        [Header("CollectionProperties")]
        [SerializeField] private List<GameObject> items = new List<GameObject>(); 
        public List<GameObject> Items => items;

        [SerializeField] private float moveSpeed = 10f;
        [SerializeField] public int itemCounterForCollection;
        


        public override void OnAwake()
        {
            Instance = this;
        }
        
        private void Update()
        {
            if (items.Count < 2 ) return;
            
            if (items.Count > 2)
            {
                items.Clear();
            }

            if (items[1].GetComponent<ItemsMovements>() != null)
            {
                items[0] = items[1];
                items.Remove(items[1]);
                //Debug.Log("2  итема");
            }

            if (items.Count == 2 && items[1].GetComponent<ContainerMovements>() != null)
            {
                if (items[0].GetComponent<ItemView>().ItemName == items[1].GetComponent<ItemView>().ItemName)
                {
                    Collectioner();
                }
                else
                {
                    Items.Clear();
                }
            }
        }
    
        private void Collectioner()
        {
            items[0].GetComponent<ItemsMovements>().enabled = false;
        
            Vector2 newPosition = Vector2.MoveTowards(
                items[0].transform.position,
                items[1].transform.position,
                moveSpeed *Time.deltaTime);
        
            items[0].transform.position = newPosition;

            if (items[0].transform.position == items[1].transform.position)
            {
                items[1].GetComponent<Animator>().SetTrigger("OnContainerAnimation");
                Destroy(items[0]);
                ItemsSpawner.Instance.itemDataList.Remove(items[0].GetComponent<ItemView>());
                items.Clear();
                itemCounterForCollection++;
            }
        }
    }
}