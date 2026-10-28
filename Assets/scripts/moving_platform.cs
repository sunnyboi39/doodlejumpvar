using UnityEngine;

public class moving_platform : MonoBehaviour
{
    public Transform cameraConstraint; // i want the platform to start at x= right edge of camera an move to the left edge all while staying at the y it was instaniated at
    public int incNum;// a number to divide the screen width so that the platform moves an equal amount each frame might also use time later on  if it doesnt feel smooth enough
    bool movingRight = true;
    
    void Start()
    {
        float cameraHeight = Camera.main.orthographicSize * 2f;
        float cameraWidth = cameraHeight * Camera.main.aspect;
        Vector3 currentPosition = transform.position;
        currentPosition.x = Mathf.CeilToInt(cameraConstraint.position.x) -.5f*(Mathf.CeilToInt(cameraWidth));
        currentPosition.z = -1;
        transform.position = currentPosition;
        Debug.Log("start transform position: " + transform.position);


    }


    private void FixedUpdate() // Debug.Log("camera position: " + cameraWidth + " moving to: " +(Mathf.CeilToInt(cameraWidth)) + .5f * (Mathf.CeilToInt(cameraWidth)));
    {
        float cameraHeight = Camera.main.orthographicSize * 2f;
        float cameraWidth = cameraHeight * Camera.main.aspect;
        Vector3 currentPosition = transform.position;
       
        float cameraLeftBoundry =(Mathf.CeilToInt(cameraConstraint.position.x)) - .5f * (Mathf.CeilToInt(cameraWidth));
        Debug.Log("left bound: " + cameraLeftBoundry);


        float cameraRightBoundry =(Mathf.CeilToInt(cameraConstraint.position.x)) + .5f * (Mathf.CeilToInt(cameraWidth));
        Debug.Log("right bound: " + cameraRightBoundry);


        // currentPosition.x = Mathf.Lerp(currentPosition.x, (Mathf.CeilToInt(cameraConstraint.position.x)) + .5f * (Mathf.CeilToInt(cameraWidth)), .02f);// dont like the texture of the movement


        if (movingRight == true)
        {
            moveRight();
            if(currentPosition.x>= cameraRightBoundry) // if hits right bound-move left
            {
                Debug.Log("hit right bound");
                movingRight = false;
            }

        }

        if (movingRight==false)
        {
            moveLeft();
            if (currentPosition.x<= cameraLeftBoundry)//if hits left bound- move left
            {
                Debug.Log("hit left bound");

                movingRight = true;
            }

        }

        currentPosition.z = -1;
        transform.position = currentPosition;
       
        Debug.Log("transform position: "+ transform.position.x);



        void moveRight()
        {
            currentPosition.x =currentPosition.x+ (Mathf.CeilToInt(cameraWidth)/incNum);
            Debug.Log("movin right: "+ currentPosition.x);
        }
        void moveLeft()
        {
            currentPosition.x = currentPosition.x -(Mathf.CeilToInt(cameraWidth) / incNum);
            Debug.Log("movin right: " +currentPosition.x);
        }
    }
    

}
