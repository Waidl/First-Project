using LevelsSystem;
using TMPro;
using UnityEngine;

namespace CoinsSystem
{
    public class PlayerCoins : Singletone<PlayerCoins>
    {
        [SerializeField] public TextMeshProUGUI levelCompletedCoinsText;
        
        [SerializeField] private TextMeshProUGUI currentPlayerCoinsText;
        
        [SerializeField] private TextMeshProUGUI currentPlayerCoinsInShopText;
        
        [SerializeField] private int currentPlayerCoins;
        
        public int CurrentPlayerCoins
        {
            get => currentPlayerCoins;
            set => currentPlayerCoins = value;
        }

        public override void OnAwake()
        {
            Instance = this;
        }

        private void Start()
        {
            currentPlayerCoins = 0;
            currentPlayerCoins = PlayerPrefs.GetInt("playerCoins",currentPlayerCoins);
        }

        private void Update()
        {
            currentPlayerCoinsText.text = currentPlayerCoins.ToString();
            currentPlayerCoinsInShopText.text = currentPlayerCoins.ToString();
        }

        public void AddCoins()
        {
            levelCompletedCoinsText.text = LevelsManager.Instance.CurrentLevelView.CoinsForLevel.ToString();
            currentPlayerCoins += LevelsManager.Instance.CurrentLevelView.CoinsForLevel;
        }
    }
}
