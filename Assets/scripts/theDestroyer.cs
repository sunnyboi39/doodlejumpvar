using UnityEngine;

public class theDestroyer : MonoBehaviour
{
    public Rigidbody2D destroyingBlock;
    float cameraHeight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraHeight = Camera.main.orthographicSize * 2f;
        float cameraPos = Camera.main.transform.position.y;
        float belowScreen = cameraPos -(cameraHeight * .7f);
        Vector3 newPos = new Vector3(0, belowScreen, 0);
        destroyingBlock.MovePosition(newPos);


    }

    
}
