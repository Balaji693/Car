using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBar : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private float rotateSpeed;

    // Update is called once per frame
    void Update()
    {
        rotatingBar();
    }
    void rotatingBar()
    {
        transform.Rotate(-Vector3.up * rotateSpeed * Time.deltaTime);
    }
}
