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
        
        public override void OnAwake()
        {
            Instance = this;
        }

        private void Start()
        {
            maxHealth = 1;
            
            currentHealth = maxHealth;
            
            maxHealth = PlayerPrefs.GetInt("maxHealth",maxHealth);
            currentHealth = PlayerPrefs.GetInt("currentHealth", currentHealth);
            
            for (int i = 0; i < maxHealth; i++)
            {
                completedLevelHealth[i].GetComponent<Image>().sprite = fullHealth;
            }
        }

        public void AddMaxHealth()
        {
            maxHealth++;
        }
        
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

            for (int i = maxHealth; i < completedLevelHealth.Length; i++)
            {
                completedLevelHealth[i].SetActive(false);
            }

            for (int i = 0; i < maxHealth; i++)
            {
                completedLevelHealth[i].SetActive(true);
            }
        }

        public void ResetHealth()
        {
            currentHealth = maxHealth;
        }
    }
}