using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int health = 100;
    private Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool insideObject = false;
    private bool otroInsideObjet = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TriggerObject"))
        {
            insideObject = true;
            StartCoroutine(ExecuteRepeatedly());
        }
        else if(other.gameObject.CompareTag("vidamasmas")){
            otroInsideObjet = true;
            StartCoroutine(ExecuteRepeatedly());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TriggerObject"))
        {
            insideObject = false;
            StartCoroutine(ExecuteRepeatedly());
        }
        else if(other.gameObject.CompareTag("vidamasmas")){
            otroInsideObjet = false;
            StartCoroutine(ExecuteRepeatedly());
        }
    }

    IEnumerator ExecuteRepeatedly()
    {
        while (insideObject)
        {
            health += 10;
            yield return new WaitForSeconds(2f);
        }
        while(otroInsideObjet){
            health -=10;
            yield return new WaitForSeconds(2f);
        }
    }
}
