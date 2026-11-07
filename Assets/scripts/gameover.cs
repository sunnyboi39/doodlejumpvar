using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class replaybutton : MonoBehaviour
{
    Text score;
    int newScore;
    
    // Update is called once per frame
    void Update()
    {
        newScore = Mathf.CeilToInt(platform_Instantiator.doodleScore);
        
        GameObject scorefind = GameObject.Find("score");//looks for text object with this name 
        if (scorefind != null)// if it exists
        {
            score = scorefind.GetComponent<Text>();//get text component of object
            score.text = "Score: " + newScore;
        }


    }
}
