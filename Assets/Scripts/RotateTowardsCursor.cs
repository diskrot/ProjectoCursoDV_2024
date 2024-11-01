using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsCursor : MonoBehaviour
{

    public Transform objTransform;
    public Vector2 mousePos;
    public float angleToMouse;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        angleToMouse = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.AngleAxis(angleToMouse-90f, Vector3.forward);
    }
}
