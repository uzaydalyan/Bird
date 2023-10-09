using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject character;

    private void Awake()
    {
        character = GameObject.Find("Character");
    }

    private void Start()
    {
    }

    private void Update()
    {
        transform.position =
            new Vector3(character.transform.position.x + 1.5f, transform.position.y, transform.position.z);
    }
}