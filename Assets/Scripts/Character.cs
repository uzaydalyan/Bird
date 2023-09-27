using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using DefaultNamespace;
using DG.Tweening;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Character : MonoBehaviour
{
    private CharacterState _state = CharacterState.Idle;
    [SerializeField] private Sprite _batFly;
    [SerializeField] private Sprite _batIdle;

    private Dictionary<CharacterState, Sprite> _sprites;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidBody;
    [SerializeField] private float flyForce;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _sprites = new Dictionary<CharacterState, Sprite>()
        {
            { CharacterState.Idle, _batIdle},
            { CharacterState.Fly , _batFly}
        };
    }
    
    // Update is called once per frame
    void Update()
    {
        if (_rigidBody.velocity.y <= 0 && _state != CharacterState.Dead)
            _state = CharacterState.Idle;
        else
            _state = CharacterState.Fly;

        setSprite();
        if (_state == CharacterState.Dead)
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
        _rigidBody.velocity = new Vector2(0, flyForce);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Die();
    }

    private void OnCollisionStay2D(Collision2D collisionInfo)
    {
        transform.DOKill();
    }

    private void Die()
    {
        _rigidBody.velocity = Vector2.zero;
        _state = CharacterState.Dead;
        GameManager.Instance.FinishGame();
    }
}
