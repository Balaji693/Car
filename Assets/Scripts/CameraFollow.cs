using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform Player;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private float smoothTransition;

    // Update is called once per frame

    private void Start()
    {
    }
    void LateUpdate()
    {
        Vector3 desiredPosition = Player.position + offset;
        Vector3 smoothDamped = Vector3.Lerp(transform.position, desiredPosition, smoothTransition * Time.deltaTime);
        transform.position = desiredPosition;
       
    }
}
