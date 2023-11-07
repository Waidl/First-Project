using Common;
using ItemsSystem.Items;
using LevelsSystem;
using UnityEngine;

namespace ContainersSystem
{
    public class ContainerMoveToWaitPoint : MonoBehaviour
    {
        [SerializeField] private float speed = 4f;
        
        [SerializeField] private Transform waitPoint;
        [SerializeField] private Transform attackPoint;
        [SerializeField] private bool attack;

        [SerializeField] private Animator container;
        [SerializeField] private ParticleSystem spawnEffect;
        [SerializeField] private ParticleSystem attackEffect;

        private void Start()
        {
            attack = false;
        }

        private void Update()
        {
            if (attack==false)
            {
                MoveToItem();
            }
            if (transform.position == waitPoint.position)
            {
                container.SetTrigger("ItemOn");
            }

            if (attack)
            {
                MoveToAttack();
            }
            
            if (transform.position == attackPoint.position)
            {
                Destroy(gameObject);
                
                AudioManager.AudioManager.Instance.Play(GameConfig.DamageSound);
                ContainerSpawner.Instance.ContainersDataList.Remove(gameObject.GetComponent<ItemView>());
                ContainerSpawner.Instance.IncreaseCounter();
                LevelsManager.Instance.EnemyAnimator.SetTrigger("EnemyDamage");
            }
        }
        
        public void OnAttack()
        {
            container.SetTrigger("ItemOff");
            attack = true;
        }
        
        private void MoveToItem()
        {
            spawnEffect.Play();
            
            Vector2 newPosition = Vector2.MoveTowards(
                transform.position,
                waitPoint.position,
                speed * Time.deltaTime);
            transform.position = newPosition;
        }

        private void MoveToAttack()
        {
            attackEffect.Play();
            
            Vector2 newPosition = Vector2.MoveTowards(
                transform.position,
                attackPoint.position,
                speed * Time.deltaTime);
            transform.position = newPosition;
        }
    }
}
