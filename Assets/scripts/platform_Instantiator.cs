
using System;
using UnityEngine;

public class platform_Instantiator : MonoBehaviour
{
    public GameObject regular;

    public GameObject hover;
    GameObject clone;
    public int spaceDivider; //For randomizing x for platform
    public int spacing; // for spacing y coordinates of each platform
    private GameObject doodle;
    float doodleStart;
    float storeDoodleY;
    float doodleScore;
    public int instantiateInc; //prob 500; every certain amount up, instantiate group of platforms
    int groupCounter=1;
    public int groupNum;//number of platforms in an instantiated group


  


    string[] platform_prob = { "reg", "reg", "reg","reg","reg","hover", "hover" };//  array for skewing the chances of a specific platorm being spawned
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        doodle = GameObject.FindWithTag("Player");
        doodleStart = doodle.transform.position.y;
        storeDoodleY = doodle.transform.position.y;
        foreach (string plat in platform_prob){
            Debug.Log("PLATFORMS IN PLATFORMPROB: "+ plat);

        }
        SpawnGroup();
    }

    // Update is called once per frame
    void Update()
    {
        float cameraHeight = Camera.main.orthographicSize * 2f;
        float cameraWidth = cameraHeight * Camera.main.aspect;
        if (doodle.transform.position.y > storeDoodleY)
        {
            storeDoodleY = doodle.transform.position.y;// so score will be the highest doodle gets
        }
        doodleScore= doodle.transform.position.y-doodleStart;// score will always start at zero no matter where doodle starts

        Debug.Log("doodle score: "+ doodleScore);
        if (doodleScore>(instantiateInc*groupCounter))
        {
            SpawnGroup();
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
    void SpawnGroup()
    {

        int platformCounter = 0;
        while (platformCounter<groupNum)
        {
            SpawnPlatform(XRandomizer(), YRandomizer());
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

    float YRandomizer()
    {
        float cameraPos = Camera.main.transform.position.y;
        float cameraHeightHalf = Camera.main.orthographicSize; //half camera height
        float bottomOfScreen = cameraPos - cameraHeightHalf;
        int randint = UnityEngine.Random.Range(0, spacing + 1);
        float ySection =cameraPos+(((cameraHeightHalf) / spacing)*randint);
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