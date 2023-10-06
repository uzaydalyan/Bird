using Managers;
using UnityEngine;

namespace Obstacles
{
    public abstract class Obstacle : MonoBehaviour
    {
        public Rigidbody2D rigidbody;
        public float characterPositionX;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            characterPositionX = GameManager.Instance.characterPositionX;
        }

        private void Start()
        {
            rigidbody.velocity = new Vector2(-2f, 0);
        }

        public void OnGameOver()
        {
            rigidbody.velocity = new Vector2(0, 0);
        }

        public void IncreaseScore(int point)
        {
            ScoreManager.Instance.IncreaseScore(point);
        }
    }
}