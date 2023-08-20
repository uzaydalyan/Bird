using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using DefaultNamespace;
using DG.Tweening;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Character : MonoBehaviour
{
    private CharacterState _state = CharacterState.Idle;
    [SerializeField] private Sprite _batFly;
    [SerializeField] private Sprite _batIdle;

    private Dictionary<CharacterState, Sprite> _sprites;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private PolygonCollider2D _collider;

    private void Awake()
    {
        _sprites = new Dictionary<CharacterState, Sprite>()
        {
            { CharacterState.Idle, _batIdle},
            { CharacterState.Fly , _batFly}
        };
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        setSprite();
        
        if (_state == CharacterState.Dead)
        {
            
        }
        else
        {
            transform.position += Vector3.right / 1250;
            if (_state == CharacterState.Idle)
            {
                transform.position += Vector3.down / 300;
            } else if (_state == CharacterState.Fly)
            {
                _spriteRenderer.sprite = _sprites[CharacterState.Fly];
            }
        }
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
        transform.DOMove(transform.position + new Vector3(0.5f, 1.8f, 0), 0.5f)
            .OnComplete(() =>
            {
                _state = CharacterState.Idle;
            })
            .OnKill(() =>
            {
                _state = CharacterState.Idle;
            });
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        transform.DOKill();
        Die();
    }

    private void OnCollisionStay2D(Collision2D collisionInfo)
    {
        transform.DOKill();
    }

    private void Die()
    {
        _state = CharacterState.Dead;
    }
}
