using UnityEngine;
using UnityEngine.SceneManagement;

public class debuggingkeys : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void FixedUpdate()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if (Input.GetKey(KeyCode.N))
        {
            SceneManager.LoadScene(getNextScene(currentScene));
        }
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

    }
    int getNextScene(int scene)
    {
        int nextscene = (scene + 1) % 3;
        return nextscene;
            
    }
}
