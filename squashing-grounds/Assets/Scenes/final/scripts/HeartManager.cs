using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class HeartManager : MonoBehaviour
{
    public int maxHearts = 5;
    public int currentHearts;
    //public Color currentColor;

    public GameObject[] heartImgs;

    public TextMeshProUGUI timerText;
    private float surviveTime;

    public Animator gameOverAnim;

    public GameObject playModeCanvas;
    public GameObject scoreboardCanvas;

    private bool timerRunning = true;

    public BugManager bugManager;

    public TextMeshProUGUI scoreText;
    public GameObject replayButton;

    private AudioSource deathSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHearts = maxHearts;
        UpdateHeartBarUI();
        surviveTime = 0f;

        playModeCanvas.SetActive(true);
        scoreboardCanvas.SetActive(false);
        replayButton.SetActive(false);

        deathSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHearts > 0 && timerRunning) // if there are more than zero hearts / if player is alive, run timer
        {
            surviveTime += Time.deltaTime;
            UpdateTimerUI(); // show timer running in canvas
        }
    }

    public void LoseHeart(int damage)
    {
        currentHearts -= damage; // decrease current amount of hearts by 1 each time

        if (currentHearts < 0)
            currentHearts = 0; // clamps value to zero when value enters the negatives

        UpdateHeartBarUI(); // call everytime currentHearts value changes

        if (currentHearts == 0)
        {
            Debug.Log("game over!!"); // game over logic
            deathSound.Play();
            bugManager.StopSpawning();
            GameOverAnim(); // blocks player input and pauses NPCs
        }
    }

    public void UpdateHeartBarUI()
    {
        for (int i = 0; i < heartImgs.Length; i++)
        {
            heartImgs[i].SetActive(i < currentHearts); // removes heart icons one by one by cycling through array
        }
    }

    public void GameOverAnim()
    {
        gameOverAnim.SetBool("playGameOver", true);
        StartCoroutine(DisplayScoreboard());
        timerRunning = false;
        //bugManager.spawnInterval = 0f;
    }

    public void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(surviveTime / 60);
        int seconds = Mathf.FloorToInt(surviveTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private IEnumerator DisplayScoreboard()
    {
        Debug.Log("running");
        yield return new WaitForSeconds(5f);
        playModeCanvas.SetActive(false);
        scoreboardCanvas.SetActive(true);

        int minutes = Mathf.FloorToInt(surviveTime / 60);
        int seconds = Mathf.FloorToInt(surviveTime % 60);
        scoreText.text = string.Format("time survived: {0:00}:{1:00}", minutes, seconds);

        yield return new WaitForSeconds(3f);
        replayButton.SetActive(true);
    }
}
