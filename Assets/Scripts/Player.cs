using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private GameObject groundDetection;
    private bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        checkGroundDetection();
        moveForward();
    }
    void moveForward()
    {
        if (isGrounded)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
    void checkGroundDetection()
    {
         RaycastHit hitinfo;
        if (Physics.Raycast(groundDetection.transform.position, Vector3.down,out hitinfo, 0.5f))
        {
            Debug.Log(hitinfo.collider.gameObject.name);
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
