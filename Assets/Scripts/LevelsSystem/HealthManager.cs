using UnityEngine;
using UnityEngine.UI;

namespace LevelsSystem
{
    public class HealthManager : Singletone<HealthManager>
    {
        [Header("Health Properties")]
        [SerializeField] private GameObject[] completedLevelHealth;

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
            maxHealth = 2;
            
            currentHealth = maxHealth;
            
            maxHealth = PlayerPrefs.GetInt("maxHealth",maxHealth);
            currentHealth = PlayerPrefs.GetInt("currentHealth", currentHealth);
            
            for (int i = 0; i < maxHealth; i++)
            {
                completedLevelHealth[i].SetActive(true);
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
                completedLevelHealth[i].SetActive(true);
                completedLevelHealth[i].GetComponent<Image>().color = Color.white;
            }

            for (int i = currentHealth; i < maxHealth; i++)
            {
                completedLevelHealth[i].GetComponent<Image>().color = Color.gray;
            }
            
                // закрыть спрайты меньше макс хп
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
            for (int i = 0; i < maxHealth; i++)
            {
                completedLevelHealth[i].GetComponent<Image>().color = Color.white;
            }
            currentHealth = maxHealth;
        }
    }
}