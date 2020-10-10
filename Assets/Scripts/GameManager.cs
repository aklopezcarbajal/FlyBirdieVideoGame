using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.CoreModule;

public class GameManager : MonoBehaviour
{
    // UI elements
    public GameObject startUI;
    public GameObject getReadyUI;
    public GameObject gameOverUI;
    public Text scoreText;

    public bool gameOn = false;
    public int score;

    private Vector2 zeroGravity = new Vector2(0f, 0f);
    private Vector2 gravity = new Vector2(0, -9.81f);

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.gravity = zeroGravity;
        startUI.SetActive(true);
        getReadyUI.SetActive(false);
        gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartGame()
    {
        startUI.SetActive(false);
        GetReady();

        //spawnRate /= difficulty;
        //StartCoroutine(SpawnTarget());
    }

    IEnumerator getReadyDelay()
    {
        //Wait for 3 seconds
        yield return new WaitForSeconds(3);

        //Fade away sprites
        float fadeTime = 2.0f;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / fadeTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(1.0f, 0.0f, t));
            for(int i = 0; i < getReadyUI.transform.childCount; i++) //fade every sprite of Get Ready
            {
                Transform childSprite = getReadyUI.transform.GetChild(i);
                childSprite.gameObject.GetComponent<SpriteRenderer>().material.color = newColor;
            }
            yield return null;
        }
        
        getReadyUI.SetActive(false);
        //return sprites to their original color
        GameOn();
    }

    public void GetReady()
    {
        //Display tutorial and text
        getReadyUI.SetActive(true);
        //Delay a couple of seconds
        StartCoroutine(getReadyDelay() );
    }

    public void GameOn()
    {
        //Start game
        gameOn = true;
        //un-freeze player
        Physics2D.gravity = gravity;
        //Set score
        score = 0;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        gameOn = false;
        gameOverUI.SetActive(true);
        int savedHighscore = PlayerPrefs.GetInt("highscore");
        if(score > savedHighscore)
        {
            PlayerPrefs.SetInt("highscore", score);
        }

    }

    public void RestartGame()
    {
        ///reset score text
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverUI.SetActive(false);
    }

}
