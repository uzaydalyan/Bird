using System;
using DefaultNamespace.Helpers;
using Obstacles;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [SerializeField] private GameObject _characterObject;
        [SerializeField] private GameObject _menuButtons;
        [SerializeField] private Button _playAgainButton;
        [SerializeField] private Button _homeButton;

        public float characterPositionX;
        private Character.Character _character;

        private void Awake()
        {
            Instance = this;
            _character = _characterObject.GetComponent<Character.Character>();
            characterPositionX = _characterObject.transform.position.x;
        }

        // Start is called before the first frame update
        private void Start()
        {
            ObstacleFactory.Instance.CreateObstacles();
            _playAgainButton.onClick.AddListener(RestartGame);
            _homeButton.onClick.AddListener(OpenHome);
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetMouseButtonDown(0)) _character.Fly();
        }

        public static event Action<GameStateChange> GameStateChanged;

        private void OpenHome()
        {
            SceneManager.LoadScene("Scenes/MenuScene");
        }

        private void RestartGame()
        {
            GameStateChanged?.Invoke(GameStateChange.GameRestart);
            _menuButtons.SetActive(false);
        }

        public void FinishGame()
        {
            GameStateChanged?.Invoke(GameStateChange.GameOver);
            _menuButtons.SetActive(true);
        }
    }
}