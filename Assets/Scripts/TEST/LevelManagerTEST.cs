using System.Collections.Generic;
using ContainersSystem;
using Items;
using ItemsSystem;
using LevelsSystem;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace TEST
{
    public class LevelManagerTest : MonoBehaviour
    {
        [SerializeField] private List<ItemDataSO> allDataSOForGame = new List<ItemDataSO>();
        [SerializeField] private GameObject[] allLevels;
        [SerializeField] private int levelScore;
        
       /*private GameObject starsPanel;
        
        
        
        
        private void MixingList()
        {
            for (int i = 0; i < allDataSOForGame.Count; i++)
            {
                ItemDataSO temp = allDataSOForGame[i];
                int randomIndex = Random.Range(0, allDataSOForGame.Count);
                allDataSOForGame[i] = allDataSOForGame[randomIndex];
                allDataSOForGame[randomIndex] = temp;
            }
        }
        
        public void FirstLevels()
        {
            MixingList();
            
            for (int i = 0; i < 3; i++)
            {
                ItemsSpawner.itemsToSpawn.Add(allDataSOForGame[i]);
                ContainerSpawner.Instance.containersToSpawn.Add(allDataSOForGame[i]);
            }
            ItemsSpawner.Instance.Initialize(ItemsSpawner.itemsToSpawn);
            ContainerSpawner.Instance.StartSpawnContainers();
            
            starsPanel = allLevels[0].GetComponentInChildren<LayoutElement>().gameObject;
            //LevelScoreManager.Instance.CurrentLevel = starsPanel;
            
            //Debug.Log("первый" +allLevels[0].GetComponent<LevelScoreManager>().LevelScoreCount);
        }
        
        public void SecondLevel()
        {
            MixingList();
            
            for (int i = 0; i < 4; i++)
            {
                ItemsSpawner.itemsToSpawn.Add(allDataSOForGame[i]);
                ContainerSpawner.Instance.containersToSpawn.Add(allDataSOForGame[i]);
            }
            ItemsSpawner.Instance.Initialize(ItemsSpawner.itemsToSpawn);
            ContainerSpawner.Instance.StartSpawnContainers();
            
            starsPanel = allLevels[1].GetComponentInChildren<LayoutElement>().gameObject;
            //LevelScoreManager.Instance.CurrentLevel = starsPanel;
            //Debug.Log("пр" + allLevels[0].GetComponent<LevelScoreManager>().CurrentStarsInLevel);
        }
        public void ThirdLevel()
        {
            MixingList();
            
            for (int i = 0; i < 4; i++)
            {
                ItemsSpawner.itemsToSpawn.Add(allDataSOForGame[i]);
                ContainerSpawner.Instance.containersToSpawn.Add(allDataSOForGame[i]);
            }
            ItemsSpawner.Instance.Initialize(ItemsSpawner.itemsToSpawn);
            ContainerSpawner.Instance.StartSpawnContainers();
            
            starsPanel = allLevels[2].GetComponentInChildren<LayoutElement>().gameObject;
            //LevelScoreManager.Instance.CurrentLevel = starsPanel;
            //Debug.Log("вт" +allLevels[1].GetComponent<LevelScoreManager>().CurrentStarsInLevel);
        }
        public void FourthLevel()
        {
            MixingList();
            
            for (int i = 0; i < 4; i++)
            {
                ItemsSpawner.itemsToSpawn.Add(allDataSOForGame[i]);
                //ContainerSpawner.ContainersToSpawn.Add(allDataSOForGame[i]);
            }
            ItemsSpawner.Instance.Initialize(ItemsSpawner.itemsToSpawn);
            ContainerSpawner.Instance.StartSpawnContainers();
            
            starsPanel = allLevels[3].GetComponentInChildren<LayoutElement>().gameObject;
            //LevelScoreManager.Instance.CurrentLevel = starsPanel;
            //Debug.Log("тр" +allLevels[2].GetComponent<LevelScoreManager>().CurrentStarsInLevel);
        }
        public void FifthLevel()
        {
            MixingList();
            
            for (int i = 0; i < 4; i++)
            {
                //ItemsSpawner.itemsToSpawn.Add(allDataSOForGame[i]);
                //ContainerSpawner.ContainersToSpawn.Add(allDataSOForGame[i]);
            }
            ItemsSpawner.Instance.Initialize(ItemsSpawner.itemsToSpawn);
            ContainerSpawner.Instance.StartSpawnContainers();
            
            starsPanel = allLevels[4].GetComponentInChildren<LayoutElement>().gameObject;
            //LevelScoreManager.Instance.CurrentLevel = starsPanel;
            //Debug.Log("чт" +allLevels[3].GetComponent<LevelScoreManager>().CurrentStarsInLevel);
        }*/

    }
}
