using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameController : MonoBehaviour
{
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

    public int totalEnemies;
    public GameObject player;
    public bool IsPlayerDead = false;
    public Score score;
    private ScoreBoard scoreBoard;
    private string savePath;
    
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
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void Win()
    {
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
