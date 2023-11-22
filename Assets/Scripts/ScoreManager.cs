using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TMP_Text scoreText;
    public TMP_Text highscoreText;

    public bool isDead;

    int score = 0;
    int highscore = 0;

    public int multiplyer = 1;

    private void Awake()
    {
        instance = this;
        isDead = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        multiplyer = 1;
        scoreText.text = "Score: " + score.ToString() + " x" + multiplyer;
        highscoreText.text = "Highscore: " + highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints(int points)
    {
        score += points * multiplyer;
        if (score < 0) score = 0;
        scoreText.text = "Score: " + score.ToString() + " x" + multiplyer;
        if(highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);    
        }
    }
}
