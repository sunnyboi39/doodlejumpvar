using UnityEngine;

public class colliderEnable : MonoBehaviour 
    /* if doodle gets higher than platform enable collider; 
    for avoiding bouncing inbetween platforms*/
{
    private GameObject doodle;
    private Collider2D platform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doodle = GameObject.FindWithTag("Player");
        /* i was getting a type mismatch when trying to put the doodle in the scene 
        as doodle in here in the inspector because unity doesn't let scene objects 
        be referenced in prefabs in the case that they are detroyed*/
        platform = GetComponent<Collider2D>();
        platform.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float currentY= transform.position.y;// y coordinate of the object the script is attached to
        float doodlePos = doodle.transform.position.y;
        Debug.Log( platform + "is doodle y("+ doodlePos+") more that platform y("+currentY +")? " + (doodlePos > currentY));



        if (doodlePos>currentY)
        {
            platform.enabled = true;
        }
        else
        {
            platform.enabled = false;
        }
    }
}
