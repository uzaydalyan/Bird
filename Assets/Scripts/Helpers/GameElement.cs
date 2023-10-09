using DefaultNamespace.Helpers;
using Managers;
using UnityEngine;

namespace Helpers
{
    public abstract class GameElement : MonoBehaviour
    {
        protected void Start()
        {
            GameManager.GameStateChanged += OnGameStateChange;
            OnStart();
        }

        private void OnDestroy()
        {
            GameManager.GameStateChanged -= OnGameStateChange;
        }


        public void OnGameStateChange(GameStateChange changeEvent)
        {
            switch (changeEvent)
            {
                case GameStateChange.GameRestart:
                    OnGameRestart();
                    break;
                case GameStateChange.GameOver:
                    OnGameOver();
                    break;
            }
        }

        protected abstract void OnStart();

        protected abstract void OnGameOver();
        protected abstract void OnGameRestart();
    }
}