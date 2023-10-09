using System.Collections.Generic;
using DefaultNamespace.Helpers;
using Helpers;
using Managers;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace Character
{
    public class Character : GameElement
    {
        private float _initialHeight = 2.30f;
        [SerializeField] private Sprite _batFly;
        [SerializeField] private Sprite _batIdle;

        private Dictionary<CharacterState, Sprite> _sprites;

        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Rigidbody2D _rigidBody;
        [SerializeField] private float flyForce;
    
        private CharacterState _state = CharacterState.Idle;
        public CharacterState state{
            get{return _state;}
            set{
                _state = value; 
                setSprite();
            }
        }

        private void Awake()
        {
            resetCharacter();
            _sprites = new Dictionary<CharacterState, Sprite>()
            {
                { CharacterState.Idle, _batIdle},
                { CharacterState.Fly , _batFly}
            };
        }

        protected override void OnStart(){}

        protected override void OnGameOver(){}

        protected override void OnGameRestart()
        {
            resetCharacter();
        }

        public void resetCharacter()
        {
            _rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            transform.position =  new Vector2(transform.position.x, _initialHeight);
        }
    
        // Update is called once per frame
        void Update()
        {
            if (state == CharacterState.Fly)
            {
                if (_rigidBody.velocity.y <= 0)
                    state = CharacterState.Idle;
                else
                    state = CharacterState.Fly;
            }
        
            if (state == CharacterState.Dead)
                _rigidBody.velocity = Vector2.zero;
        }

        private void setSprite()
        {
            var sprite = _sprites.ContainsKey(_state) ? _sprites[_state] : _sprites[CharacterState.Idle];
            if (_spriteRenderer.sprite != sprite)
            {
                _spriteRenderer.sprite = sprite;
            }
        }

        public void Fly()
        {
            _state = CharacterState.Fly;
            _rigidBody.velocity = new Vector2(0, flyForce);
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            Die();
        }

        private void Die()
        {
            _rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
            _state = CharacterState.Dead;
            GameManager.Instance.FinishGame();
        }
    }
}
