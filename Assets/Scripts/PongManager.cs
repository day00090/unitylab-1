using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PongManager : MonoBehaviour
{
    [SerializeField] private PongGoal p1Goal;
    [SerializeField] private PongGoal p2Goal;
    [SerializeField] private PongBall pongBall;
    [SerializeField] private int p1Score = 0;
    [SerializeField] private int p2Score = 0;
    [SerializeField] private TMP_Text p1ScoreText;
    [SerializeField] private TMP_Text p2ScoreText;

    private static readonly WaitForSeconds wait = new WaitForSeconds(3);
    private void Awake()
    {
        p1Goal.onScore += HandleP2Score;
        p2Goal.onScore += HandleP1Score;
    }

    private void HandleP1Score()
    {
        p1Score++;
        pongBall.Restart();
        p1ScoreText.text = "" + p1Score;
        if(p1Score == 3) {
            p1ScoreText.text = "3 - Win!";
            StartCoroutine(Sleep());
        }
    }

    private void HandleP2Score()
    {
        p2Score++;
        pongBall.Restart();
        p2ScoreText.text = "" + p2Score;
        if(p2Score == 3) {
            p2ScoreText.text = "3 - Win!";
            StartCoroutine(Sleep());
        }
    }

    private IEnumerator Sleep()
    {
        pongBall.Stop();
        yield return wait;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
