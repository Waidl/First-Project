using UnityEngine;

namespace LevelsSystem.Levels
{
    [CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level", order = 1)]
    public class LevelDataSO : ScriptableObject
    {
        [SerializeField] private Sprite levelAvatarImage;
        [SerializeField] private string levelNumber;
        [SerializeField] private int maxItemsToSpawn;


        public Sprite LevelAvatarImage => levelAvatarImage;
        public string LevelNumber => levelNumber;
        
        public int MaxItemsToSpawn => maxItemsToSpawn;
    }
}