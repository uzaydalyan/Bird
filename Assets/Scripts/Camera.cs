using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    private GameObject character;

    private void Awake()
    {
        character = GameObject.Find("Character");
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        transform.position = new Vector3(character.transform.position.x + 1.5f, transform.position.y, transform.position.z);
    }
}
