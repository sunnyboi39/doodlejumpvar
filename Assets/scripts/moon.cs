using UnityEngine;
using UnityEngine.SceneManagement;

public class moon : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("COLLISION CALLED");

        if (other.gameObject.CompareTag("Player"))
        {

            Debug.Log("Game Over");
            SceneManager.LoadScene(2);//go to game over screen




        }

    }
}
