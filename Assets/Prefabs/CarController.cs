using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CarController : MonoBehaviour
{


    private Vector3 moveForce;
    [SerializeField]
    public static float moveSpeed = 150f;


    [SerializeField]
    private float maxSpeed;

    [SerializeField]
    private float dragValue;

    [SerializeField]
    private float steerAngle;

    [SerializeField]
    private float torqueTurningSpeed;

    [SerializeField]
    private Transform groundDetection;

    private bool isGrounded = false;
    private bool isFalling;
    public static bool isRotateLock = false;



    [SerializeField]
    private GameObject originalCar;
    [SerializeField]
    private GameObject replacementCar;
    private static bool isSpacePressed;
    // Update is called once per frame
    [SerializeField]
    private Rigidbody rb;

    private bool isReplacementCarSpawned = false;


    public static float  rotateSpeedValue = 0;

    void LateUpdate()
    {
        carMovement();
        checkCarIsFalling();
        checkGroundDetection();
        UImanager.instance.isRotateLock();

    }

    void carMovement()
    {

        //Keyboard Input..............
        if (!isFalling && isGrounded && !GameManager.instance.isTimeOver && !GameManager.instance.isPlayerHitObstacles)
        {
            float vInput = Input.GetAxis("Vertical");
            moveForce += transform.forward * moveSpeed * vInput * Time.deltaTime;
            transform.position += moveForce * Time.deltaTime;

            moveForce *= dragValue;
            moveForce = Vector3.ClampMagnitude(moveForce, maxSpeed);

            float steerInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up * steerInput * steerAngle * moveForce.magnitude * Time.deltaTime);
            rb.AddTorque(transform.forward * steerInput * torqueTurningSpeed * Time.deltaTime);
        }

        //Mobile Inputs.............

        if (UImanager.instance.upButton.pressed)
        {
            moveForce += transform.forward * moveSpeed * 1 * Time.deltaTime;
            transform.position += moveForce * Time.deltaTime;
            moveForce *= dragValue;
            moveForce = Vector3.ClampMagnitude(moveForce, maxSpeed);
        }
        if (UImanager.instance.downButton.pressed)
        {
            moveForce += -transform.forward * moveSpeed * 1 * Time.deltaTime;
            transform.position += moveForce * Time.deltaTime;
            moveForce *= dragValue;
            moveForce = Vector3.ClampMagnitude(moveForce, maxSpeed);
        }
        /*        if (UImanager.instance.rightButton.pressed)
                {
                    transform.Rotate(Vector3.up * -UImanager.instance.sliderBar.value * steerAngle * moveForce.magnitude * Time.deltaTime);
                    rb.AddTorque(transform.forward * 1 * torqueTurningSpeed * Time.deltaTime);
                }
                if (UImanager.instance.leftButton.pressed)
                {
                    transform.Rotate(Vector3.up * UImanager.instance.sliderBar.value * steerAngle * moveForce.magnitude * Time.deltaTime);
                    rb.AddTorque(transform.forward * 1 * torqueTurningSpeed * Time.deltaTime);
                }*/
        if (!isRotateLock)
        {
            float steerMobileInput = Input.acceleration.x;
            transform.Rotate(Vector3.up * steerMobileInput * rotateSpeedValue * moveForce.magnitude * Time.deltaTime);
            rb.AddTorque(transform.forward * steerMobileInput * torqueTurningSpeed * Time.deltaTime);
        }
    }

    void checkCarIsFalling()
    {
        if (this.gameObject.transform.position.y <= -5)
        {
            isFalling = true;
            GameManager.instance.carFell();
        }
        else
        {
            isFalling = false;
        }
    }
    void checkGroundDetection()
    {
        RaycastHit hitInfo;
        if( Physics.Raycast(groundDetection.transform.position, -transform.up, out hitInfo, 2f))
        {
            if (hitInfo.collider.gameObject.CompareTag("Ground")) isGrounded = true;
        }
        else
        {          
            isGrounded = false;
          /*  if (!isGrounded)
            {
                if (!isFalling) isGrounded = true;
            }*/
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            GameManager.instance.collisionWithObstacles();
            originalCar.SetActive(false);
            if (!isReplacementCarSpawned)
            {
                Instantiate(replacementCar, originalCar.transform.position + new Vector3(0,2,0), originalCar.transform.rotation);
            }
            isReplacementCarSpawned = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Finish"))
        {
            GameManager.instance.enteredFinishLine();
        }
    }

    public  static float  SetMoveSpeed()
    {
        
        return moveSpeed;
    }
}
