using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PuzzleManager : MonoBehaviour
{

    public static PuzzleManager instance;

    [SerializeField]
    private GameObject[] puzzleImages;

    [SerializeField]
    private bool isMatched = false;

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

    public void rotateImage(GameObject image, RaycastHit2D hitInfo2D)
    {
        if (hitInfo2D.collider.gameObject.CompareTag("Puzzle"))
        {
            image.transform.Rotate(0, 0, 90);
            IsArrayBalanced();
        }
    }

    bool IsArrayBalanced()
    {
        foreach (GameObject puzzleImage in puzzleImages)
        {
            if (puzzleImage.transform.localEulerAngles.z  != 0)
            {
                return false;
            }
        }
        GameManager.instance.puzzleMatched();
        return true;
    }
}
