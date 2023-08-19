using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Character : MonoBehaviour
{
    private CharacterState _state = CharacterState.Idle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_state == CharacterState.Idle)
        {
            transform.position += Vector3.down / 500;
        }
        
    }

    public void Fly()
    {
        transform.position += Vector3.up * (float) 1.5;
    }
}
