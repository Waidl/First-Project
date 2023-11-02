using System;
using LevelsSystem;
using TMPro;
using UnityEngine;

namespace CoinsSystem
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private int prise;
        [SerializeField] private TextMeshProUGUI priseText;
        
        private void Update()
        {
            priseText.text = prise.ToString();
            
            CurrenPriseOnHealth();
        }

        private void CurrenPriseOnHealth()
        {
            if (HealthManager.Instance.MaxHealth == 1)
            {
                prise = 100;
            }
            if (HealthManager.Instance.MaxHealth == 2)
            {
                prise = 200;
            }
            if (HealthManager.Instance.MaxHealth == 3)
            {
                prise = 300;
            }
            if (HealthManager.Instance.MaxHealth == 4)
            {
                prise = 400;
            }
        }

        public void BuyItem()
        {
            if (prise <= PlayerCoins.Instance.CurrentPlayerCoins)
            {
                HealthManager.Instance.AddMaxHealth();
                HealthManager.Instance.ResetHealth();
                PlayerCoins.Instance.CurrentPlayerCoins -= prise;
            }
            else
            {
                return;
            }
        }
    }
}