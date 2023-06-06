using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushingWalls : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void WallMovingBackward()
    {
        anim.SetBool("WallMovingForward", false);
        anim.SetBool("WallMovingBackward", true);
    }
    void WallMovingForward()
    {
        anim.SetBool("WallMovingBackward", false);
        anim.SetBool("WallMovingForward", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        Invoke("WallMovingBackward", 2f);
    }
    private void OnTriggerExit(Collider other)
    {
        Invoke("WallMovingForward", Random.Range(0.5f, 1.5f));
    }

}
