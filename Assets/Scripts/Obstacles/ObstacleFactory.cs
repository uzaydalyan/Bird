using System.Collections;
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
            Instantiate(_pipePrefab, position, Quaternion.identity, transform);
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