using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject _characterObject;
    public static GameManager Instance;
    private Character _character;


    private void Awake()
    {
        Instance = this;
        _character = _characterObject.GetComponent<Character>();
    }

    // Start is called before the first frame update
    void Start()
    {
        ObstacleFactory.Instance.CreateObstacles();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _character.Fly();
        }
    }

    public void FinishGame()
    {
        ObstacleFactory.Instance.StopCreatingObstacles();
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("obstacle");
        foreach (GameObject obstacle in obstacles)
        {
            obstacle.GetComponent<Obstacle>().GameOver();
        }
    }
}
