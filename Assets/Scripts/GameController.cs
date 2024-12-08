using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Score
{
    public string name;
    public int points;
}

[System.Serializable]
public struct ScoreBoard
{
    public List<Score> scores;
}

public class GameController : MonoBehaviour
{
    public int totalEnemies;
    public GameObject player;
    public bool IsPlayerDead = false;
    public Score score;
    private ScoreBoard scoreBoard;
    public string savePath;
    
    public GameObject winScreen;
    // Music
    //public AudioSource musicSource;
    // Start is called before the first frame update
    void Start()
    {
        score.points = 0;
        scoreBoard.scores = new List<Score>();
        savePath = System.IO.Path.Combine(Application.persistentDataPath, "score.json");
    }

    // Update is called once per frame
    void Update()
    {
        IsPlayerDead = player == null;
        if (IsPlayerDead)
        {
            Lose();
        }
        if (totalEnemies == 0)
        {
            Win();
        }
    }

    public void Lose()
    {
        Debug.Log("You lose!");
        //musicSource.Stop();
        // Play lose music
        //musicSource.PlayOneShot(loseMusic);
        // Show lose screen
        //SceneManager.LoadScene("Lose");
    }

    public void Win()
    {
        //musicSource.Stop();
        // Play win music
        //musicSource.PlayOneShot(winMusic);
        // Show win screen ui gameobject
        winScreen.SetActive(true);
    }
    public void SaveScore(string name)
    {
        score.name = name;
        scoreBoard.scores.Add(score);
        string json = JsonUtility.ToJson(scoreBoard);
        System.IO.File.WriteAllText(savePath, json);
        Debug.Log(json);
    }
    public void LoadScore()
    {
        if (System.IO.File.Exists(savePath))
        {
            string json = System.IO.File.ReadAllText(savePath);
            scoreBoard = JsonUtility.FromJson<ScoreBoard>(json);
            Debug.Log(json);
        }
    }
}
