using UnityEngine;

namespace LevelsSystem.Levels
{
    [CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level", order = 1)]
    public class LevelDataSO : ScriptableObject
    {
        [SerializeField] private Sprite levelAvatarImage;
        [SerializeField] private int levelNumber;
        [SerializeField] private int maxItemsToSpawn;
        [SerializeField] private float timeOnLevel;
        [SerializeField] private int coinsForLevel;
        
        public Sprite LevelAvatarImage => levelAvatarImage;
        public int LevelNumber => levelNumber;
        
        public int MaxItemsToSpawn => maxItemsToSpawn;

        public float TimeOnLevel => timeOnLevel;

        public int CoinsForLevel => coinsForLevel;
    }
}