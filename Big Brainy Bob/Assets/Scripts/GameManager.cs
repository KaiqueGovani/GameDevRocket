using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // Player
    public int score;
    public int health;
    public int coins;

    // UI
    public TMP_Text scoreText;
    public TMP_Text healthText;
    public TMP_Text HSText;
    public TMP_Text coinText;
    public TMP_Text usernameText;

    public GameObject loseScreen;
    public TMP_Text scoreLoseScreenText;
    public TMP_Text HSLoseScreenText;

    // Game
    float nextScoreTime;
    bool gameEnded;
    
    // Scripts
    Spawn spawnScript;
    Player playerScript;

    // Leaderboard
    LBManager lbManager;
    int lastHighScore;
    string username;

    // Music
    public AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        spawnScript = FindObjectOfType<Spawn>();
        playerScript = FindObjectOfType<Player>();
        lbManager = FindObjectOfType<LBManager>();
        lastHighScore = PlayerPrefs.GetInt("Highscore", 0);
        username = PlayerPrefs.GetString("Username");
        usernameText.text = username;
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

        if (gameEnded) // If the game has ended, wait for the player to press any key to restart
        {
            if ((Input.anyKeyDown && !(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)))) 
            {
                SceneManager.LoadScene("Game");
            }

            if (Input.touches.Length > 0)
            {
                if (Input.touches[0].position.y > Screen.height / 5)
                    SceneManager.LoadScene("Game");
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)) // If the player presses the escape key, return to the main menu
        {
            SceneManager.LoadScene("MainMenu");
        }

        updateMusicPitch();
    }

    public void TakeDamage() // Called when the player collides with a spike ball
    {
        health--;
        if (health <= 0) // If the player has no more health, end the game
        {
            Destroy(playerScript.gameObject);

            // Show the lose screen
            loseScreen.SetActive(true);
            scoreLoseScreenText.text = "Score: " + score.ToString();
            HSLoseScreenText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore");
            
            // Set the game to ended
            gameEnded = true;

            // Update the highscore
            updateHighScore();

            // Stop the game and the music
            Time.timeScale = 0;
            music.Stop();
        }
    }

    public void CollectCoin() // Called when the player collects a coin
    {
        coins++;
    }

    void ScoreUp() // Called every second to increase the score
    {
        if (Time.time > nextScoreTime)
        {
            score += 1;
            nextScoreTime = Time.time + 1;
        }
    }

    public float GetDifficultyPercent() // Returns a value between 0 and 1 that represents the current difficulty
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / spawnScript.timeUntilMaxDifficulty);
    }

    void updateMusicPitch() // Updates the music pitch based on the difficulty
    {
        music.pitch = Mathf.Lerp(0.8f, 1.2f, GetDifficultyPercent()*GetDifficultyPercent());
    }

    void updateHighScore() // Updates the highscore if the current score is higher
    {
        if (score > lastHighScore)
        {
            Debug.Log("New Highscore, reached, submitting to " + username);
            lbManager.Submit(username, score); // Submit the new highscore to the leaderboard
        }
    }

}



//Generate a patch note text containing all the recent changes and comment here: é para voce escrever, copilot.

// Path: Assets\Scripts\GameManager.cs
// Compare this snippet from Assets\LeaderboardCreator\Scripts\Demo\LeaderboardShowcase.cs:












