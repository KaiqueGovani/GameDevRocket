using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public int health;
    public int coins;

    float nextScoreTime;

    public TMP_Text scoreText;
    public TMP_Text healthText;
    public TMP_Text HSText;
    public TMP_Text coinText;


    public GameObject loseScreen;
    public TMP_Text scoreLoseScreenText;
    public TMP_Text HSLoseScreenText;

    bool gameEnded;

    Spawn spawnScript;
    Player playerScript;

    public AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        spawnScript = FindObjectOfType<Spawn>();
        playerScript = FindObjectOfType<Player>();
        PlayerPrefs.GetInt("Highscore", 0);
        coins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        healthText.text = health.ToString();
        coinText.text = coins.ToString();
        HSText.text = PlayerPrefs.GetInt("Highscore").ToString();
        score = (int) Time.timeSinceLevelLoad;
        if (score > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", score);
        }

        if (gameEnded)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Game");
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }

        updateMusicPitch();
    }

    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            Destroy(playerScript.gameObject);
            loseScreen.SetActive(true);
            scoreLoseScreenText.text = "Score: " + score.ToString();
            HSLoseScreenText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore");
            gameEnded = true;
            Time.timeScale = 0;
            music.Stop();
        }
    }

    public void CollectCoin()
    {
        coins++;
    }

    void ScoreUp()
    {
        if (Time.time > nextScoreTime)
        {
            score += 1;
            nextScoreTime = Time.time + 1;
        }
    }

    public float GetDifficultyPercent()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / spawnScript.timeUntilMaxDifficulty);
    }

    void updateMusicPitch()
    {
        music.pitch = Mathf.Lerp(0.8f, 1.2f, GetDifficultyPercent()*GetDifficultyPercent());
    }
}
