using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Obstacles
{
    public class ObstacleFactory : MonoBehaviour
    {
        [SerializeField] private float[] _yPositions;
        [SerializeField] private GameObject _pipePrefab;
        public static ObstacleFactory Instance;
        private IEnumerator _createRoutine;
        
        private Stack<GameObject> _pipePool = new();

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
                CreatePipe();
                yield return new WaitForSeconds(1.2f);
            }
        }

        private void CreatePipe()
        {
            Vector2 position = new Vector2(transform.position.x, _yPositions[Random.Range(0, _yPositions.Length)]);
            
            if (_pipePool.Count > 0)
            {
                GameObject pipe = _pipePool.Pop();
                pipe.transform.position = position;
                pipe.SetActive(true);
            } else
            {
                Instantiate(_pipePrefab, position, Quaternion.identity, transform);
            }
        }

        public void PushPipeToPool(GameObject pipe)
        {
            pipe.SetActive(false);
            _pipePool.Push(pipe);
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