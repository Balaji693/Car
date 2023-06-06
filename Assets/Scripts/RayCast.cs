using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{

    private static RayCast instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            //Raycast for 3D Gameobjects
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
       /*        WoodContainer.instance.getCollectableWoods(hitInfo);*/
                Debug.Log(hitInfo.collider.gameObject.name);
            }


            //Canvas Raycasting For 2D Gameobjects
            Vector2 ray2D = Input.mousePosition;
            RaycastHit2D hitInfo2D = Physics2D.Raycast(ray2D, transform.forward, 100f);

            if (hitInfo2D)
            {
                PuzzleManager.instance.rotateImage(hitInfo2D.collider.gameObject,hitInfo2D);
            }

            
        }
    }


}
