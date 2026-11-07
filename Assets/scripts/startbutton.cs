using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class startbutton : MonoBehaviour
{


    public void NextScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);//go to start screen
    }

     

  
}
