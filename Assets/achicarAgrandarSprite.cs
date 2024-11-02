using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class achicarAgrandarSprite : MonoBehaviour
{
    ///////////////////////////////////////////
    
    #region Parameters
    public Animator animator;
    public float scaleVelocidad = 2.0f;
    #endregion
	
    ///////////////////////////////////////////

    #region Callbacks
	
    void Start()
    {
        animator.SetFloat("floatXY", 0f); 
        
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {   
            float nuevaEscala = Mathf.Lerp(animator.GetFloat("floatXY"), 1f, Time.deltaTime * scaleVelocidad);
            animator.SetFloat("floatXY", nuevaEscala); // Agrandar mientras se mantiene presionado
        }
        else
        {   
            float nuevaEscalaCero = Mathf.Lerp(animator.GetFloat("floatXY"), 0f, Time.deltaTime * scaleVelocidad);
             animator.SetFloat("floatXY", nuevaEscalaCero); // Volver al tamaño original cuando se suelta
        }
    }
	
    #endregion

    ///////////////////////////////////////////

    #region Methods

    #endregion

    ///////////////////////////////////////////

    #region Utils

    public void Log(string message)
    {
        Debug.Log(message);
    }

    public void ErrorLog(string message)
    {
        Debug.LogError(message);
    }

    public void OrderLog(int i)
    {
        Debug.Log("ORDEN: " + i + " || " + this.GetType().ToString());
    }

    public void ColorLog(string message, Color color)
    {
        Debug.Log(string.Format("<color=#{0:X2}{1:X2}{2:X2}>{3}</color>", (byte)(color.r * 255f), (byte)(color.g * 255f), (byte)(color.b * 255f), message));
    }

    #endregion

    ///////////////////////////////////////////
	
    #region Coroutines
	
    #endregion
	
    ///////////////////////////////////////////

    #region Events
    
    #endregion
    
    ///////////////////////////////////////////
    
    #region Data Definitions
    
    #endregion
    
    ///////////////////////////////////////////
}