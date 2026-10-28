using UnityEngine;

public class doodlemove : MonoBehaviour
{
    public float moveSpeed;
    public GameObject doodle;
    public Rigidbody2D doodle_rb;
    public Transform cameraConstraint; // if doodle hits a boundry it will appear at the opposit boundry
    public int incNum;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { //Begin start function 
        Debug.Log("start");
        float cameraHeight = Camera.main.orthographicSize * 2f;
        float cameraWidth = cameraHeight * Camera.main.aspect;
        Vector3 currentPosition = transform.position;
        currentPosition.x = 0;
        currentPosition.z = -1;
        transform.position = currentPosition;
        Debug.Log("start transform position: " + transform.position);


    }// end start function

    // Update is called once per frame
    void Update()
    {

        float cameraHeight = Camera.main.orthographicSize * 2f;
        float cameraWidth = cameraHeight * Camera.main.aspect;
        Vector3 currentPosition = transform.position;
        float cameraLeftBoundry = (Mathf.CeilToInt(cameraConstraint.position.x)) - .5f * (Mathf.CeilToInt(cameraWidth));
        Debug.Log("left bound: " + cameraLeftBoundry);


        float cameraRightBoundry = (Mathf.CeilToInt(cameraConstraint.position.x)) + .5f * (Mathf.CeilToInt(cameraWidth));
        Debug.Log("right bound: " + cameraRightBoundry);

        currentPosition.z = -1;
        transform.position = currentPosition;
        Debug.Log("update doodle move transform position: " + transform.position);

        if (Input.GetKey(KeyCode.LeftArrow))
        {

            Debug.Log("leftarrow key pressed");
            currentPosition.x = currentPosition.x - moveSpeed;
            
            if (currentPosition.x <= cameraLeftBoundry) // if hits left bound-appear at right bound
            {
                Debug.Log("hit left bound");
                currentPosition.x = cameraRightBoundry - 5;

            }

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {

            Debug.Log("right arrow key pressed");
            currentPosition.x = currentPosition.x + moveSpeed;
            if (currentPosition.x >= cameraRightBoundry) // if hits right bound-appear at left bound
            {
                Debug.Log("hit right bound");
                currentPosition.x = cameraLeftBoundry + 5;

            }

        }

        transform.position = currentPosition;

    }
    
}
