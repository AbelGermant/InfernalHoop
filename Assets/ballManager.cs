using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballManager : MonoBehaviour
{
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if ball y is less than -10, move it to 0.573 0.2445 0
        if (ball.transform.position.y < -10)
        {
            ball.transform.position = new Vector3(0.573f, 0.2445f, 0);
            //reinitialize the velocity of the ball
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            SpawnHoop.current.SetZ(Random.Range(2, 10));
        }
        
    }
}
