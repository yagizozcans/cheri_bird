using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    public float maxTime = 1;
    private float timer = 0;
    public GameObject pipe;
    public Vector2 height;

    public static int score = 0;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI panelScoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI titleText;

    public Image medalImage;

    public Sprite[] medals;

    public GameObject inGameCanvas;
    public GameObject mainCanvas;
    public GameObject scorePanel;

    public static GameObject inGameManager;

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > maxTime)
        {
            GameObject newPipe = Instantiate(pipe, new Vector3(5, Random.Range(height.x, height.y), 0), Quaternion.identity);
            timer = 0;
        }

        scoreText.text = score.ToString();
    }

    private void Start()
    {
        score = 0;
        inGameCanvas.SetActive(false);
        mainCanvas.SetActive(true);

        Time.timeScale = 0;
        if(inGameManager != this.gameObject && inGameManager != null)
        {
            Destroy(this.gameObject);
            return;
        }
        inGameManager = this.gameObject;
    }

    public void EndGame()
    {
        mainCanvas.SetActive(false);
        inGameCanvas.SetActive(true);
        scorePanel.SetActive(true);
        ScorePanelUptade();
        Time.timeScale = 0;
    }

    public void StartTheGame()
    {
        mainCanvas.SetActive(false);
        inGameCanvas.SetActive(true);
        scorePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ScorePanelUptade()
    {
        highScoreText.text = PlayerPrefs.GetInt("highscore", 0).ToString();
        panelScoreText.text = score.ToString();
        if (score == 0)
        {
            medalImage.sprite = medals[4];
        }

        if (score >= 25 && score < 50)
        {
            medalImage.sprite = medals[0];
        }

        if (score >= 50 && score < 100)
        {
            medalImage.sprite = medals[1];
        }

        if (score >= 100 && score < 200)
        {
            medalImage.sprite = medals[2];
        }

        if (score >= 200)
        {
            medalImage.sprite = medals[3];
        }
    }
}
