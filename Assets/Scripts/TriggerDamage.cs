using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    public int damage = 10;
    public float damageRate = 2.0f;

    // Start is called before the first frame update
    private bool insideObject = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            insideObject = true;
            StartCoroutine(Harm(other.gameObject));
            Debug.Log("Player entered");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            insideObject = false;
            StartCoroutine(Harm(other.gameObject));
        }
    }

    IEnumerator Harm(GameObject other)
    {
        while (insideObject)
        {
            other.GetComponent<HealthSystem>().harm += damage;
            yield return new WaitForSeconds(damageRate);
        }
    }
}
