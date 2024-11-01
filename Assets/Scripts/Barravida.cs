using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Barravida : MonoBehaviour
{
    public HealthSystem playerHealthSystem; // Referencia al script del sistema de salud
    public TMP_Text VidaTexto;

    void Update()
    {
        UpdateHealthText();
    }

    void UpdateHealthText()
    {
        VidaTexto.text =playerHealthSystem.health.ToString("F0"); // "F0" muestra la vida sin decimales
    }
}
