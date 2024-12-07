using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject player;
    public TMP_Text healthText;

    void Update()
    {
        UpdateHealthText();
    }

    void UpdateHealthText()
    {
        //healthText.text = player.GetComponent<HealthSystem>().health.ToString("F0"); // "F0" muestra la vida sin decimales
        healthText.text = new string('|', player.GetComponent<HealthSystem>().health);
    }
}
