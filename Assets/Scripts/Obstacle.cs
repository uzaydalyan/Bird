using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _collider;
    [SerializeField] private Rigidbody2D _rigidbody;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody.velocity = new Vector2(-2f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -3f)
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        _rigidbody.velocity = new Vector2(0, 0);
    }
}
