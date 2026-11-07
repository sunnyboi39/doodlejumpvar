
using System;
using UnityEngine.UI;
using UnityEngine;

public class platform_Instantiator : MonoBehaviour
{
    public GameObject regular;

    public GameObject hover;
    public GameObject moon;
    public GameObject star;
    public GameObject jupiter;
    public GameObject neptune;
    public GameObject uranus;
    public GameObject space;

    GameObject clone;
    public int spaceDivider; //For randomizing x for platform
    public int spacing; // for spacing y coordinates of each platform
    private GameObject doodle;
    float doodleStart;
    float storeDoodleY;
    public static float doodleScore;
    float instantiateInc; // every certain amount up doodle goes, instantiate group of platforms
    int groupCounter=1;
    public int groupNum;//number of platforms in an instantiated group
    public Text score;


  


    string[] platform_prob = { "reg", "reg", "reg","reg","reg","hover", "hover" };//  array for skewing the chances of a specific platorm being spawned
    string[] planet_prob = { "jupiter", "star", "star", "star", "star", "moon", "star","moon","star", "star", "star", "star", "neptune","star", "uranus","star","star","star","star","star","star"};
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        doodle = GameObject.FindWithTag("Player");
        doodleStart = doodle.transform.position.y;
        storeDoodleY = doodle.transform.position.y;
        foreach (string plat in platform_prob){
            Debug.Log("PLATFORMS IN PLATFORMPROB: "+ plat);

        }
        SpawnGroup("middle");
        SpawnGroup("bottom");
    }

    // Update is called once per frame
    void Update()
     
    {
        float cameraHeight = Camera.main.orthographicSize * 2f;
        float cameraWidth = cameraHeight * Camera.main.aspect;
        float cameraPos = Camera.main.transform.position.y;
        float topOfScreen = cameraPos + (cameraHeight*.5f);
        RectTransform scoreRect = score.GetComponent<RectTransform>();//so the text position is relative to the camera
        scoreRect.anchoredPosition = new Vector3(-150, 150, 0);
        Debug.Log("is transform " + doodle.transform.position.y + " more than storedoodle"+ storeDoodleY + "?: " + storeDoodleY);
        if (doodle.transform.position.y > storeDoodleY)
        {
            storeDoodleY = doodle.transform.position.y;// so score will be the highest doodle gets
            doodleScore = doodle.transform.position.y - doodleStart;// score will always start at zero no matter where doodle starts
        }
        
        score.text = ""+ Mathf.CeilToInt(doodleScore);

        Debug.Log("doodle score: "+ doodleScore);
        instantiateInc = .5f * cameraHeight;
        if (doodleScore>((instantiateInc)*groupCounter))
        {
            SpawnGroup("top");
            clone = Instantiate(space, new Vector3(0,topOfScreen,0), Quaternion.identity);
            Debug.Log("hover instantiated");
            groupCounter++;
        }




    }
    void SpawnPlatform(float x, float y )
    {
        int randint = UnityEngine.Random.Range(0, platform_prob.Length);
        string platform = platform_prob[randint];
        Debug.Log("platform picked: "+platform);
        Vector3 SpawnPosition = new Vector3(x, y, 0);

        if (platform=="reg")
        {
            clone = Instantiate(regular, SpawnPosition, Quaternion.identity);
            Debug.Log("reg instantiated");
        }
        else if (platform == "hover")
        {
            clone = Instantiate(hover, SpawnPosition, Quaternion.identity);
            Debug.Log("hover instantiated");
        }

    }

    void SpawnPlanets(float x, float y)
    {
        int randint = UnityEngine.Random.Range(0, planet_prob.Length);
        string planet = planet_prob[randint];
        Debug.Log("planet picked: " + planet);
        Vector3 SpawnPosition = new Vector3(x, y, 0);

        if (planet == "moon")
        {
            clone = Instantiate(moon, SpawnPosition, Quaternion.identity);
            Debug.Log("moon instantiated");
        }
        else if (planet== "jupiter")
        {
            clone = Instantiate(jupiter, SpawnPosition, Quaternion.identity);
            Debug.Log("jupiter instantiated");
        }
        else if (planet == "uranus")
        {
            clone = Instantiate(uranus, SpawnPosition, Quaternion.identity);
            Debug.Log("uranus instantiated");
        }
        else if (planet == "neptune")
        {
            clone = Instantiate(neptune, SpawnPosition, Quaternion.identity);
            Debug.Log("neptune instantiated");
        }
        else if (planet == "star")
        {
            clone = Instantiate(star, SpawnPosition, Quaternion.identity);
            Debug.Log("star instantiated");
        }

    }


    void SpawnGroup(string screenPlacement)//top bottom or middle
    {

        int platformCounter = 0;
        while (platformCounter<groupNum)
        {
            if (screenPlacement == "top")
            {
                SpawnPlatform(XRandomizer(), YRandomizer("top"));
                SpawnPlanets(XRandomizer(), YRandomizer("top"));
            }
            else if (screenPlacement == "bottom")
            {
                SpawnPlatform(XRandomizer(), YRandomizer("bottom"));
                SpawnPlanets(XRandomizer(), YRandomizer("top"));
            }
            else
            {
                SpawnPlatform(XRandomizer(), YRandomizer("middle"));
                SpawnPlanets(XRandomizer(), YRandomizer("top"));
            }
            
            platformCounter++;
        }
    }

    float XRandomizer()
    {
        float cameraPos = Camera.main.transform.position.x;
        float cameraHeight = Camera.main.orthographicSize * 2f;
        float cameraWidth = cameraHeight * Camera.main.aspect;
        float leftOfScreen = cameraPos - (cameraWidth/2);
        int randint =UnityEngine.Random.Range(0, spaceDivider + 1);
        float xSection =leftOfScreen+ ((cameraWidth / spaceDivider) * randint); // splitin the screen into (spacedivider) equal columns. multiplying by randint puts platform one of those columns
        Debug.Log("x section: " + xSection);
        return xSection;
    }

    float YRandomizer(string screenPlacement)//choose where to place platform group top(above the screen) bottom(lower half of screen) or middle(top half of screen)
    {
        float ySection;
        float cameraPos = Camera.main.transform.position.y;
        float cameraHeightHalf = Camera.main.orthographicSize; //half camera height
        float bottomOfScreen = cameraPos - cameraHeightHalf;
        float topOfScreen= cameraPos + cameraHeightHalf;
        int randint = UnityEngine.Random.Range(0, spacing + 1);
        if (screenPlacement == "top")
        {
            ySection = (topOfScreen-20) + (((2 * cameraHeightHalf) / spacing) * randint);
        } else if (screenPlacement == "bottom")
        {
            ySection = bottomOfScreen + (((2 * cameraHeightHalf) / spacing) * randint);
        }
        else
        {
            ySection = cameraPos + (((2 * cameraHeightHalf) / spacing) * randint);
        }
        return ySection;


    }
}



/*
 using UnityEngine;

public class spawncube : MonoBehaviour
{
    public GameObject myPrefab;
    public GameObject clone;

    // Update is called once per frame
    void Update()
    {
     if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector2 SpawnPosition = new Vector2(0f, 0f);
            clone = Instantiate(myPrefab, SpawnPosition, Quaternion.identity);//makes face forward
        }
    }
}
 */