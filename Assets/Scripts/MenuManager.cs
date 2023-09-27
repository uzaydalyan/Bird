using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private Button _playButton;
    [SerializeField] private Button _highScoreBButton;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _playButton.onClick.AddListener(() =>
        {
            Debug.Log("dhasdhsjadsa");
            SceneManager.LoadScene("Scenes/GamePlayScene");
        });
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
