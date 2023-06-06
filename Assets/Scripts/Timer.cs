using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float timer;
    [SerializeField]
    private Text timerText;
    void Update()
    {
        if (!GameManager.instance.isPlayerFinished) 
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                GameManager.instance.timeOver();
            }
        }
        else
        {
            return;
        }
        timerText.text = Mathf.Round(timer).ToString();       
    }
}
