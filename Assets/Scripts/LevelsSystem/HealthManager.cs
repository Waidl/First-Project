using UnityEngine;
using UnityEngine.UI;

namespace LevelsSystem
{
    public class HealthManager : Singletone<HealthManager>
    {
        [Header("Health Properties")]
        [SerializeField] private GameObject[] completedLevelHealth;

        [SerializeField] private Sprite fullHealth;
        [SerializeField] private Sprite emptyHealth;

        [SerializeField] private int maxHealth;
        public int MaxHealth => maxHealth;

        [SerializeField] private int currentHealth;
        public int CurrentHealth => currentHealth;

        //private LevelView currentLevelCount;
        
        //private int currentHealthCount;
        //private int allLevelsCount;
        

        public override void OnAwake()
        {
            Instance = this;
        }

        private void Start()
        {
            maxHealth = 3;
            
            currentHealth = maxHealth;
            
            currentHealth = PlayerPrefs.GetInt("currentHealth", currentHealth);
            
            for (int i = 0; i < maxHealth; i++)
            {
                completedLevelHealth[i].GetComponent<Image>().sprite = fullHealth;
            }
        }
        
        /*private void Update()
        {
            if (currentLevelCount == null) return;
            
            currentLevelCount = LevelsManager.Instance.currentLevelView;
        }*/
        
        public void AddHealthPerLevel()//добавление хп
        {
            if (currentHealth < maxHealth && currentHealth != 0)
            {
                currentHealth++;
            }
            
            HealthAdjustment();
        }

        public void RemoveHealthPerLevel()
        {
            if (currentHealth > 0)
            {
                currentHealth--;
            }
            
            HealthAdjustment();
        }

        public void HealthAdjustment()// текущие здоровье
        {
            for (int i = 0; i < currentHealth; i++)
            {
                completedLevelHealth[i].GetComponent<Image>().sprite = fullHealth;
            }

            for (int i = currentHealth; i < maxHealth; i++)
            {
                completedLevelHealth[i].GetComponent<Image>().sprite = emptyHealth;
            }
        }

        public void ResetHealth()
        {
            currentHealth = maxHealth;
        }
    }
}