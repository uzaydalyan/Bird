using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Managers
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _highScoreBButton;


        // Start is called before the first frame update
        private void Start()
        {
            _playButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("Scenes/GamePlayScene");
            });
        }
    }
}