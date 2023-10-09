using Helpers;
using Managers;
using UnityEngine;

namespace Obstacles
{
    public abstract class Obstacle : GameElement
    {
        public Rigidbody2D rigidbody;
        public float characterPositionX;
        public ObstacleType type;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            characterPositionX = GameManager.Instance.characterPositionX;
            SetType();
        }

        private void OnEnable()
        {
            rigidbody.velocity = new Vector2(-2f, 0);
        }

        protected override void OnStart()
        {
            rigidbody.velocity = new Vector2(-2f, 0);
            ObstacleOnStart();
        }

        protected abstract void ObstacleOnStart();

        public abstract void SetType();

        protected override void OnGameOver()
        {
            rigidbody.velocity = new Vector2(0, 0);
        }

        protected override void OnGameRestart()
        {
            RemoveSelf();
        }

        public void IncreaseScore(int point)
        {
            ScoreManager.Instance.IncreaseScore(point);
        }

        public void RemoveSelf()
        {
            ObstacleFactory.Instance.LeaveToPool(gameObject, type);
        }
    }
}