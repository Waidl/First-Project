using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ItemsSystem
{
    public class ItemsMovements : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Transform[] movePoints;
        
        private int randomPoint;
        private float _minimalDistanceToPoint = 0.2f;


        private void Start()
        {
            randomPoint = Random.Range(0, movePoints.Length);
        }


        private void FixedUpdate()
        {
            //speed = Random.Range(1, speed);
            Move();
        }

        private void Move()
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                movePoints[randomPoint].position,
                speed * Time.deltaTime);
            
            if (Vector2.Distance(transform.position, movePoints[randomPoint].position)
                < _minimalDistanceToPoint)
            {
                randomPoint = Random.Range(0, movePoints.Length);
            }
        }
    }
}
