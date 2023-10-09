using System;
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


        public void OnGameStateChange(GameStateChange changeEvent)
        {
            Debug.Log("Change event callback");
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

        private void OnDestroy()
        {
            GameManager.GameStateChanged -= OnGameStateChange;
        }

        protected abstract void OnStart();

        protected abstract void OnGameOver();
        protected abstract void OnGameRestart();
    }
}