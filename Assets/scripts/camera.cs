using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform followObj; // follow star 
    private void FixedUpdate()
    {
        Vector3 currentPosition = transform.position;
        // a transform position
        currentPosition.x = 0;
        currentPosition.y = Mathf.Lerp(currentPosition.y, followObj.position.y, 2f);
        currentPosition.z = -1;
        transform.position = currentPosition;
        //Debug.Log("transform position: "+ transform.position);
    }
}