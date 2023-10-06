using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Helpers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Obstacles
{
    public class ObstacleFactory : MonoBehaviour
    {
        [SerializeField] private float[] _yPositions;
        [SerializeField] private GameObject _pipePrefab;
        public static ObstacleFactory Instance;
        private IEnumerator _createRoutine;

        private Pool _pipePool;

        private void Awake()
        {
            Instance = this;
            _createRoutine = CreateObstacle();
            _pipePool = new Pool(_pipePrefab);
        }
        
        public void CreateObstacles()
        {
            StartCoroutine(_createRoutine);
        }

        public IEnumerator CreateObstacle()
        {
            while(true){
                CreatePipe();
                yield return new WaitForSeconds(1.2f);
            }
        }

        private void CreatePipe()
        {
            Vector2 position = new Vector2(transform.position.x, _yPositions[Random.Range(0, _yPositions.Length)]);
            _pipePool.GetFromPool(position, transform);
        }

        public void LeaveToPool(GameObject obj, ObstacleType type)
        {
            switch (type)
            {
                case ObstacleType.Pipe:
                    _pipePool.LeaveToPool(obj);
                    break;
            }
        }

        public void OnGameOver()
        {
            StopCoroutine(_createRoutine);
        }

        public void OnGameRestart()
        {
            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("obstacle");
            foreach (GameObject obstacle in obstacles)
            {
                Destroy(obstacle);
            }
            CreateObstacles();
        }
    }
}