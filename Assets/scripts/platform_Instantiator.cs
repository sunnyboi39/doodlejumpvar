
using UnityEngine;

public class platform_Instantiator : MonoBehaviour
{
    public GameObject regular;
    public GameObject hover;
    GameObject clone;
    public int spaceDivider; //For randomizing x for platform
    public float spacing; // for spacing y coordinates of each platform
   

    // for hover x is defined


    string[] platform_prob = { "reg","reg","hover"};//  array for skewing the chances of a specific platorm being spawned
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
       foreach(string plat in platform_prob){
            Debug.Log("PLATFORMS IN PLATFORMPROB: "+ plat);

        }
        SpawnPlatform(xRandomizer(), 0);
    }

    // Update is called once per frame
    void Update()
    {
        float cameraHeight = Camera.main.orthographicSize * 2f;
        float cameraWidth = cameraHeight * Camera.main.aspect;



    }
    void SpawnPlatform(float x, float y )
    {
        int randint = UnityEngine.Random.Range(0, 2);
        string platform = platform_prob[randint];
        Debug.Log("platform picked: "+platform);
        Vector2 SpawnPosition = new Vector2(x, y);

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

    float xRandomizer()
    {
        float cameraHeight = Camera.main.orthographicSize * 2f;
        float cameraWidth = cameraHeight * Camera.main.aspect;
        int randint = Random.Range(0, spaceDivider + 1);
        float xSection = (cameraWidth / spaceDivider) * randint; // splitin the screen into (spacedivider) equal columns. multiplying by randint puts platform one of those columns
        Debug.Log("x section: " + xSection);
        return xSection;
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