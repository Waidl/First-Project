using System;
using Common;
using ContainersSystem;
using TMPro;
using UnityEngine;

namespace LevelsSystem
{
    public class TimerInLevel : Singletone<TimerInLevel>
    {
        
        [SerializeField] private TextMeshProUGUI timerText;
        
        private float currentSeconds;
        public float CurrentSeconds
        {
            get => currentSeconds;
            set => currentSeconds = value;
        }

        private bool timerActivation;

        public bool TimerActivation
        {
            get => timerActivation;
            set => timerActivation = value;
        }

        private void Start()
        {
            timerActivation = false;
        }

        private void Update()
        {
            if (timerActivation)
            {
                StartTimer();
            }
        }

        private void StartTimer()
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