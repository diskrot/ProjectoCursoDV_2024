using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject scoreMenu;
    public TMP_Text scoreText;
    public string firstLevel;
    private string savePath;
    public AudioSource backgroundMusic;
    public AudioSource buttonClick;
    // Start is called before the first frame update
    void Start()
    {
        savePath = System.IO.Path.Combine(Application.persistentDataPath, "score.json");
        backgroundMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Main menu button functions
    public void PlayGame()
    {
        buttonClick.Play();
        backgroundMusic.Stop();
        UnityEngine.SceneManagement.SceneManager.LoadScene("firstLevel");
    }

    public void QuitGame()
    {
        buttonClick.Play();
        Application.Quit();
    }

    public void ViewScores()
    {
        buttonClick.Play();
        mainMenu.SetActive(false);
        scoreMenu.SetActive(true);
        LoadScores();
    }

    // Score menu button functions

    public void BackToMainMenu()
    {
        buttonClick.Play();
        mainMenu.SetActive(true);
        scoreMenu.SetActive(false);
    }

    public void ClearScores()
    {
        buttonClick.Play();
        System.IO.File.Delete(savePath);
        scoreText.text = "No scores saved";
    }

    public void LoadScores()
    {
        buttonClick.Play();
        if (System.IO.File.Exists(savePath))
        {
            string json = System.IO.File.ReadAllText(savePath);
            GameController.ScoreBoard scoreBoard = JsonUtility.FromJson<GameController.ScoreBoard>(json);
            foreach (GameController.Score score in scoreBoard.scores)
            {
                scoreText.text += score.name + ": " + score.points + "\n";
            }
        }
        else
        {
            scoreText.text = "No scores saved";
        }
    }
}
