using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int highscore=0;
    Text highscoretext;
    int score;
    public AudioClip music;
    AudioSource source;
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);


    }
    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.clip = music;
        source.loop = true;
        source.playOnAwake = true;
        source.Play();
    }
    void Update()
    {
        score = Mathf.CeilToInt(platform_Instantiator.doodleScore);
        if (score >= highscore)
        {
            highscore = score;
        }
        GameObject highscorefind = GameObject.Find("highscore");//looks for text object with this name 
        if (highscorefind != null)// if it exists
        {
            highscoretext = highscorefind.GetComponent<Text>();//get text component of object
            highscoretext.text = "High Score: " + highscore;
        }

        
    }

    
}
