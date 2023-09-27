using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class ObstacleFactory : MonoBehaviour
    {
        [SerializeField] private float[] _yPositions;

        [SerializeField] private GameObject _obstaclePrefab;
        [SerializeField] private float spawnTime;		// The amount of time between each spawn.
        [SerializeField] private float spawnDelay;		// The amount of time before spawning starts.
        public static ObstacleFactory Instance;
        private Boolean active = true;

        private void Awake()
        {
            Instance = this;
        }
        
        public void CreateObstacles()
        {
            active = true;
            StartCoroutine(CreateObstacle());
        }
        

        public IEnumerator CreateObstacle()
        {
            while (active)
            {
                Vector2 position = new Vector2(transform.position.x, _yPositions[Random.Range(0, _yPositions.Length)]);
                Instantiate(_obstaclePrefab, position, Quaternion.identity, transform);
                yield return new WaitForSeconds(1.2f);
            }
        }

        public void StopCreatingObstacles()
        {
            active = false;
        }
    }
}