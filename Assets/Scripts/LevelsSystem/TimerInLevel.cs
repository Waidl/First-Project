using System;
using ContainersSystem;
using TMPro;
using UnityEngine;

namespace LevelsSystem
{
    public class TimerInLevel : Singletone<TimerInLevel>
    {
        
        [SerializeField] private TextMeshProUGUI timerText;
        
        public float currentSeconds;
        
        public bool timerActivation;

        private void Start()
        {
            timerActivation = false;
            currentSeconds = 5f;
            timerText.text = currentSeconds.ToString();
        }

        private void Update()
        {
            if (timerActivation == true)
            {
                Timer();
            }

            if (timerActivation == false)
            {
                currentSeconds = 5;
            }
        }

        private void Timer()
        {
            currentSeconds -= Time.deltaTime;
            timerText.text = Mathf.Round(currentSeconds).ToString();
        }

        public override void OnAwake()
        {
            Instance = this;
        }
    }
}