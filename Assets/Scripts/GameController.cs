using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text scoreText;
    public Text gameOverText;
    public Text restartText;
    public Text quitText;
    private bool gameOver;
    private bool restart;
    public int score;
    public GameObject hazard;
    public int spawnCount;
    public float spawnWait;
    public float startSpawn;
    public float waitWave;

    private void Update()
    {
        if (restart == true)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
            }
        }
    }
    void Start()
    {
        gameOver = false;
        restart = false;
        gameOverText.text = "";
        restartText.text = "";
        quitText.text = "";
        StartCoroutine(spawnValues());
    }
    IEnumerator spawnValues()
    {
        yield return new WaitForSeconds(startSpawn);
        while (true)
        {        
            for (int i = 0; i < spawnCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-3, 3), 0, 10);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                // Coroutine
                //IEnumarator döndğrmek zorundadır.
                //en az 1 adet yield ifadesi bulunmak zorundadır.
                //coroutinler mutlaka StartCoroutine metoduyla çağrılmalıdır.
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waitWave);
            if (gameOver == true)
            {
                restartText.text = "Press 'R' for Restart";
                quitText.text = "Press Q for Quit";
                restart = true;
                break;
            }
        }
        

    }
    public void GameOver()
    {
        gameOverText.text = "Game Over !";
        gameOver = true;
    }

    public void UpdateScore()
    {
        score += 10;
        scoreText.text = "Score: " + score;
    }

}
