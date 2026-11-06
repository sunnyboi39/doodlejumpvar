using UnityEngine;

public class platformDestroy : MonoBehaviour
{
   
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("COLLISION CALLED");
        
        if (other.gameObject.CompareTag("platform"))
        {
    
            Debug.Log("PLATFORM DESTROYED");
            Destroy(other.gameObject);//platform will destroy itself if it touches the destroyer
              
           
        }

    }
}
