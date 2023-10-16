using AudioManager;
using UnityEngine;

namespace LevelsSystem.Levels
{
    [CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level", order = 1)]
    public class LevelDataSO : ScriptableObject
    {
        [SerializeField] private Sprite levelAvatarImage;
        [SerializeField] private string levelNumber;
        [SerializeField] private int maxItemsToSpawn;
        [SerializeField] private string soundOnLevel;
        [SerializeField] private int numberOfStarsToUnlockLevel;
        
        public Sprite LevelAvatarImage => levelAvatarImage;
        public string LevelNumber => levelNumber;
        
        public int MaxItemsToSpawn => maxItemsToSpawn;

        public string SoundOnLevel => soundOnLevel;
        public int NumberOfStarsToUnlockLevel => numberOfStarsToUnlockLevel;
    }
}