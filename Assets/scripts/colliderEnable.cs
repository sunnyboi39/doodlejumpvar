using UnityEngine;

public class colliderEnable : MonoBehaviour//if doodle gets higher than platform enable collider; for avoiding bouncing inbetween platforms
{
    public GameObject doodle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;
    }
}
