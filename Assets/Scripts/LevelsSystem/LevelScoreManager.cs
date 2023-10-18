using CollectionSystem;
using ContainersSystem;
using ItemsSystem;
using UnityEngine;

namespace LevelsSystem
{
    public class LevelScoreManager : Singletone<LevelScoreManager>
    {
        [Header("ScoreLevelProperties")]
        [SerializeField] private GameObject levelCompletedWindow;
        [SerializeField] private GameObject gameplayWindow;
        


        public void OnCompletingTheLevel()
        {
            ItemsSpawner.Instance.CleanUp();
            ContainerSpawner.Instance.CleanUp();
            
            CollectionManager.Instance.Items.Clear();
            
            gameplayWindow.SetActive(false);
            levelCompletedWindow.SetActive(true);

            CounterStarsOnLevels.Instance.StarsCounter();
        }
        public override void OnAwake()
        {
            Instance = this;
        }

    }
}