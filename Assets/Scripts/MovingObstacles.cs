using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacles : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Vector3 movePositionA;
    [SerializeField]
    private Vector3 movePositionB;

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private bool isMovingUpAndDown;
    [SerializeField]
    private bool isMovingRightAndLeft;
    [SerializeField]
    private bool isMovingForwardAndBackward;

    private bool reachedUpLimit = false;
    private bool reachedRightLimit = false;
    private bool reachingForwardLimit = false;


    // Update is called once per frame
    void Update()
    {
        movingUpAndDown();
        movingRightAndLeft();
        movingForwardAndBackward();
    }
    void movingUpAndDown()
    {
        if (isMovingUpAndDown)
        {
            if (transform.position.y >= movePositionA.y)
            {
                reachedUpLimit = true;
            }
            if (transform.position.y <= movePositionB.y)
            {
                reachedUpLimit = false;
            }

            if (!reachedUpLimit)
            {
                transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(-Vector3.up * moveSpeed * Time.deltaTime);
            }
        }
    }
    void movingRightAndLeft()
    {
        if (isMovingRightAndLeft)
        {
            if (transform.position.x >= movePositionA.x)
            {
                reachedRightLimit = true;
            }
            if (transform.position.x <= movePositionB.x)
            {
                reachedRightLimit = false;
            }

            if (!reachedRightLimit)
            {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(-Vector3.right * moveSpeed * Time.deltaTime);
            }
        }
    }
    void movingForwardAndBackward()
    {
        if (isMovingForwardAndBackward)
        {
            if (transform.position.z >= movePositionA.z)
            {
                reachingForwardLimit = true;
            }
            if (transform.position.z <= movePositionB.z)
            {
                reachingForwardLimit = false;
            }

            if (!reachingForwardLimit)
            {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
            }
        }
    }
}
