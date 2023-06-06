using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodContainer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject[] woodsToSpawn;
    [SerializeField]
    private int woodCollected = -1;

    public static WoodContainer instance;
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

    public void formWoodBridge()
    {
        switch (woodCollected)
        {
            case 0:
                woodsToSpawn[0].SetActive(true);
                break;
            case 1:
                woodsToSpawn[0].SetActive(true);
                woodsToSpawn[1].SetActive(true);
                break;
            case 2:
                woodsToSpawn[0].SetActive(true);
                woodsToSpawn[1].SetActive(true);
                woodsToSpawn[2].SetActive(true);
                break;
            case 3:
                woodsToSpawn[0].SetActive(true);
                woodsToSpawn[1].SetActive(true);
                woodsToSpawn[2].SetActive(true);
                woodsToSpawn[3].SetActive(true);
                break;
            case 4:
                woodsToSpawn[0].SetActive(true);
                woodsToSpawn[1].SetActive(true);
                woodsToSpawn[2].SetActive(true);
                woodsToSpawn[3].SetActive(true);
                woodsToSpawn[4].SetActive(true);
                break;
            default:
                break;
        }
    }
   public void getCollectableWoods(RaycastHit hitInfo)
    {
        if (hitInfo.collider.gameObject.CompareTag("CollectableWood"))
        {
            woodCollected++;
            hitInfo.collider.gameObject.SetActive(false);
        }
        if (hitInfo.collider.gameObject.CompareTag("WoodContainer"))
        {
            formWoodBridge();
        }
    }
}
