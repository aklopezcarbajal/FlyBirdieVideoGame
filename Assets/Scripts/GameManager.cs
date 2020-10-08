using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // UI elements
    public GameObject startUI;
    public GameObject countdownUI;
    public GameObject gameOverUI;
    public Text scoreText;

    public bool gameOn = false;
    public int score;

    //public TextMeshProUGUI scoreText;
    //public TextMeshProUGUI gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {

        gameOn = true;
        //spawnRate /= difficulty;
        //StartCoroutine(SpawnTarget());
        score = 0;
        //titleScreen.gameObject.SetActive(false);
        //something happens whrn start button is hit
    }

    public void UpdateScore()
    {
        //scoreText.text = "Score: " + score;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
