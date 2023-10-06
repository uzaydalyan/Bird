using DefaultNamespace;
using Obstacles;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Vector2 = System.Numerics.Vector2;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {

        [SerializeField] private GameObject _characterObject;
        public static GameManager Instance;
        private Character.Character _character;
        [SerializeField] private GameObject _menuButtons;
        [SerializeField] private Button _playAgainButton;
        [SerializeField] private Button _homeButton;

        public float characterPositionX;

        private void Awake()
        {
            Instance = this;
            _character = _characterObject.GetComponent<Character.Character>();
            characterPositionX = _characterObject.transform.position.x;
        }

        // Start is called before the first frame update
        void Start()
        {
            ObstacleFactory.Instance.CreateObstacles();
            _playAgainButton.onClick.AddListener(RestartGame);
            _homeButton.onClick.AddListener(OpenHome);
        }

        private void OpenHome()
        {
            SceneManager.LoadScene("Scenes/MenuScene");
        }

        private void RestartGame()
        {
            ObstacleFactory.Instance.OnGameRestart();
            ScoreManager.Instance.OnGameRestart();
            _character.OnGameRestart();
            _menuButtons.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _character.Fly();
            }
        }

        public void FinishGame()
        {
            ScoreManager.Instance.OnGameOver();
            ObstacleFactory.Instance.OnGameOver();
            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("obstacle");
            foreach (GameObject obstacle in obstacles)
            {
                obstacle.GetComponent<Obstacle>().OnGameOver();
            }
            _menuButtons.SetActive(true);
        }
    }
}