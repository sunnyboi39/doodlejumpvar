using UnityEngine;

public class doodlemove : MonoBehaviour
{
    public float moveSpeed;
    public GameObject doodle;
    public Rigidbody2D doodle_rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { //Begin start function 
        Debug.Log("start");
       

    }// end start function

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {

            //Debug.Log("leftarrow key pressed");
            doodle_rb.AddForce(Vector2.left * moveSpeed, ForceMode2D.Impulse);

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {

            //Debug.Log("right arrow key pressed");
            doodle_rb.AddForce(Vector2.right * moveSpeed, ForceMode2D.Impulse);

        }


    }
    
}
