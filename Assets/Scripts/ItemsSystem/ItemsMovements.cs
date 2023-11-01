using UnityEngine;
using Random = UnityEngine.Random;

namespace ItemsSystem
{
    public class ItemsMovements : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Transform[] movePoints;

        private int randomPoint;
        private float minimalDistanceToPoint = 0.2f;

        private void Awake()
        {
            randomPoint = Random.Range(0, movePoints.Length);
        }
        
        private void FixedUpdate()
        {
            MoveToPoints();
        }

        private void MoveToPoints()
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                movePoints[randomPoint].position,
                speed * Time.deltaTime);
            
            if (Vector2.Distance(transform.position, movePoints[randomPoint].position)
                < minimalDistanceToPoint)
            {
                randomPoint = Random.Range(0, movePoints.Length);
            }
        }
    }
}
