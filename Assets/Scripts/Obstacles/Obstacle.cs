using System;
using Managers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Obstacles
{
    public abstract class Obstacle : MonoBehaviour
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

        private void Start()
        {
            rigidbody.velocity = new Vector2(-2f, 0);
        }

        public abstract void SetType();

        public void OnGameOver()
        {
            rigidbody.velocity = new Vector2(0, 0);
        }

        public void IncreaseScore(int point)
        {
            ScoreManager.Instance.IncreaseScore(point);
        }

        public void RemoveSelf()
        {
            ObstacleFactory.Instance.LeaveToPool(gameObject, type);
        }

        private void OnEnable()
        {
            rigidbody.velocity = new Vector2(-2f, 0);
        }
    }
}