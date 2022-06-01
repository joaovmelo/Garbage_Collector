using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public int totalScore;
    public int score;
    public Text scoreText;
    public GameObject gameOver;

    public static GameController instance;

    void Start()
    {
        instance = this; 
        totalScore = PlayerPrefs.GetInt("score");
        scoreText.text = totalScore.ToString();
    }

    public void UpdateScore()
    {
        score++;
        totalScore++;
        scoreText.text = totalScore.ToString();

        PlayerPrefs.SetInt("score", totalScore);
    }

    public void RestartScore(){
        score = 0;
        totalScore = 0;
        scoreText.text = totalScore.ToString();

        PlayerPrefs.SetInt("score", totalScore);
    }

    public void ShowGameOver(){
        gameOver.SetActive(true);
    }

    public void RestartGame(string lvlName){
        SceneManager.LoadScene(lvlName);
        RestartScore();
    }

    public void Exit(){
        Application.Quit();
    }
}
