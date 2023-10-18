using System;
using TMPro;
using UnityEngine;

namespace LevelsSystem
{
    public class TimerInLevel : MonoBehaviour
    {
        [SerializeField] private int timer;
        [SerializeField] private TextMeshProUGUI timerText;

        private void Start()
        {
            
        }

        private void Update()
        {
            timerText.text = timer.ToString();
            timer = (int) +Time.deltaTime;
        }
    }
}