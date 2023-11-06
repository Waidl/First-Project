using System;
using Common;
using LevelsSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Enemy
{
    public class Enemy : Singletone<Enemy>
    {
        [SerializeField] private Image enemyAvatar;
        [SerializeField] private Sprite[] allEnemies;

        public override void OnAwake()
        {
            Instance = this;
        }

        public void OnEnemy()
        {
            enemyAvatar.sprite = allEnemies[LevelsManager.Instance.CurrentLevelView.LevelNumber -1];
        }
    }
}