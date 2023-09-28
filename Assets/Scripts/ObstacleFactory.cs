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
        public static ObstacleFactory Instance;
        private IEnumerator _createRoutine;

        private void Awake()
        {
            Instance = this;
            _createRoutine = CreateObstacle();
        }
        
        public void CreateObstacles()
        {
            StartCoroutine(_createRoutine);
        }
        

        public IEnumerator CreateObstacle()
        {
            while(true){
                Vector2 position = new Vector2(transform.position.x, _yPositions[Random.Range(0, _yPositions.Length)]);
                Instantiate(_obstaclePrefab, position, Quaternion.identity, transform);
                yield return new WaitForSeconds(1.2f);
            }
        }

        public void StopCreatingObstacles()
        {
            StopCoroutine(_createRoutine);
        }

        public void ResetFactory()
        {
            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("obstacle");
            foreach (GameObject obstacle in obstacles)
            {
                Destroy(obstacle);
            }
        }
    }
}