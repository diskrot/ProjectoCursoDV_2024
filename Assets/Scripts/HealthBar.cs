using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject player;
    public TMP_Text healthText;
    public int barMaxLenght = 10;

    void Update()
    {
        if (player != null)
        {
            UpdateHealthText();
        }
    }

    void UpdateHealthText()
    {
        //healthText.text = player.GetComponent<HealthSystem>().health.ToString("F0"); // "F0" muestra la vida sin decimales
        int bars = player.GetComponent<HealthSystem>().health * barMaxLenght / player.GetComponent<HealthSystem>().maxHealth;
        if (bars <= barMaxLenght)
        {
            healthText.text = new string('|', bars);
        }
        else
        {
            healthText.text = new string('|', barMaxLenght);
        }
    }
}
