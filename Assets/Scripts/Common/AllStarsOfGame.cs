using System;
using TMPro;
using UnityEngine;

namespace Common
{
    public class AllStarsOfGame : Singletone<AllStarsOfGame>
    {
        [SerializeField] private TextMeshProUGUI starsCounter;

        public int allStarsInGame;
        public override void OnAwake()
        {
            Instance = this;
        }

        private void Update()
        {
            starsCounter.text = allStarsInGame.ToString();
        }
    }
}