using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;

    public bool isTimeOver = false;
    public bool isPlayerFinished = false;
    public bool isPlayerHitObstacles = false;

    [SerializeField]
    private GameObject gameResultPanel;

    [SerializeField]
    private Text resultText;
    void Awake()
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
    public void puzzleMatched()
    {
        Debug.Log("Puzzle Solved");
    }
    public void collisionWithObstacles()
    {
        Debug.Log("Collision With Obstacles");
        isPlayerHitObstacles = true;
        resultText.text = Enums.GameResult.LOSE.ToString();
        Invoke("showGameResult", 3f);
        Invoke("restartLevel", 6f);
    }
    public void carFell()
    {
        Debug.Log("Car Fell");
        resultText.text = Enums.GameResult.LOSE.ToString();
        Invoke("showGameResult", 3f);
        Invoke("restartLevel", 6f);
    }
    public void enteredFinishLine()
    {
        Debug.Log("Player Entered Finish Line");
        isPlayerFinished = true;
        resultText.text = Enums.GameResult.WIN.ToString();
        Invoke("showGameResult", 1f);
        Invoke("restartLevel", 3f);
    }
    public void timeOver()
    {
        Debug.Log("Time Over");
        isTimeOver = true;
        resultText.text = Enums.GameResult.LOSE.ToString();
        Invoke("showGameResult", 3f);
        Invoke("restartLevel", 6f);
    }
    private void showGameResult()
    {
        gameResultPanel.SetActive(true);
        
    }

    void restartLevel()
    {
        SceneManager.LoadScene(0);
    }

}
