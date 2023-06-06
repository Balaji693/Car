using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UImanager : MonoBehaviour
{

    public static UImanager instance;

    [SerializeField]
    private Text moveSpeedvalue;
    [SerializeField]
    private Text rotateSpeedValue;

    [SerializeField]
    public float setMoveSpeed;
    [SerializeField]
    public float setRotateSpeed;

    public button upButton;
    public button downButton;

    public button rotateLock;


    //Setting Buttons
    [SerializeField]
    private button increaseButton;
    [SerializeField]
    private button decreaseButton;

    private float increaseSpeedvalue =  5;
    private float decreaseSpeedValue = 5;

    private float increaseRotateValue = 1;
    private float decreaseRotateValue = 1;

    [SerializeField]
    private GameObject controlPanel;



    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            return;
        }
    }
    private void Start()
    {

        moveSpeedvalue.text = CarController.moveSpeed.ToString();
        setMoveSpeed = CarController.moveSpeed;
        setRotateSpeed = CarController.rotateSpeedValue;
    }

    public void IncreaseSpeedValue()
    {
        setMoveSpeed += increaseSpeedvalue;
        moveSpeedvalue.text = setMoveSpeed.ToString();

    }
    public void DecreaseSpeedValue()
    {
        setMoveSpeed -= decreaseSpeedValue;
        moveSpeedvalue.text = setMoveSpeed.ToString();
    }

    public void increaseRotateSpeed()
    {
        setRotateSpeed += increaseRotateValue;
        rotateSpeedValue.text = setRotateSpeed.ToString();
    }
    public void decreaseRotateSped()
    {
        setRotateSpeed -= decreaseRotateValue;
        rotateSpeedValue.text = setRotateSpeed.ToString();
    }
    public void onExit()
    {
        
        CarController.moveSpeed = setMoveSpeed;
        CarController.rotateSpeedValue = setRotateSpeed;
       
        if (controlPanel.activeSelf)
        {
            controlPanel.SetActive(false);
        }
        else
        {
            controlPanel.SetActive(true);
        }
    }

    public void isRotateLock()
    {
        if (rotateLock.pressed)
        {
            CarController.isRotateLock = true;
        }
        else
        {
            CarController.isRotateLock = false;
        }
    }
}
