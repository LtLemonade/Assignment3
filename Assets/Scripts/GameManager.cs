using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public LevelGenerator LevelGenerator;
    public int speedIncrease;
    [SerializeField]
    private float timeDuration = 5f * 60;
    [SerializeField]
    private float timer;

    private void Start()
    {
        ResetTimer();
        LevelGenerator.difficulty = 0;
    }
    public void startOver()
    {
        ScoreManager.instance.isDead = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ResetTimer();
        LevelGenerator.difficulty = 0;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            IncreaseDifficulty();
            ResetTimer();
        }
        
    }

    private void ResetTimer()
    {
        timer = timeDuration;
    }

    private void IncreaseDifficulty()
    {
        if (LevelGenerator.difficulty < 2)
        {
            LevelGenerator.tileSpeed += speedIncrease;
            LevelGenerator.difficulty++;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
