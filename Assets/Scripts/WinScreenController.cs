using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinScreenController : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text scoreText;
    public GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = gameController.GetComponent<GameController>().score.points.ToString();
    }

    public void SaveButtonClick()
    {
        gameController.GetComponent<GameController>().SaveScore(inputField.text);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
