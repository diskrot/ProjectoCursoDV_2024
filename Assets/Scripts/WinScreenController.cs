using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinScreenController : MonoBehaviour
{
    public TMP_InputField inputField;
    public GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveButtonClick()
    {
        gameController.GetComponent<GameController>().SaveScore(inputField.text);
        //gameController.GetComponent<GameController>().LoadScene("MainMenu");
    }
}
