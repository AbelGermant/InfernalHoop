using System;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    // ballin'
    [SerializeField] GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if ball y is less than -10, move it to 0.573 0.2445 0 (aka respawn the ball)
        if (ball.transform.position.y < -10)
        {
            ResetBallTransform();
            SpawnHoop.current.SetZ(UnityEngine.Random.Range(2, 10));
        }
    }

    void ResetBallTransform()
    {
        //reinitialize the transform of the ball
        ball.transform.position = new Vector3(0.573f, 0.2445f, 0);
        ball.transform.rotation = Quaternion.identity;

        //reinitialize the velocity of the ball
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
