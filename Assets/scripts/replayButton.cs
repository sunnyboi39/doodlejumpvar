using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class replaybutton : MonoBehaviour
{
    public Button replayButton;
    void Start()
    {
        replayButton.onClick.AddListener(() => {
            SceneManager.LoadScene(0);//go to start screen

        });
    }

    // Update is called once per frame
    void Update()
    {
        replayButton.onClick.AddListener(() => {
            SceneManager.LoadScene(0);//go to start screen

        });
    }
}
