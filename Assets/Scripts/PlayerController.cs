using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputActionReference movementInput;
    public Vector2 movement2d;
    private Rigidbody2D rigidbody2d;
    public Animator playerAnim;
    public Animator weaponAnim;
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = this.gameObject.GetComponent<Rigidbody2D>();
        movement2d = new Vector2();
    }

    // Update is called once per frame
    void Update()
    {
        movement2d = movementInput.action.ReadValue<Vector2>();
        playerAnim.SetFloat("xspeed",movement2d.x);
        playerAnim.SetFloat("yspeed",movement2d.y);
    }
    void FixedUpdate()
    {
        rigidbody2d.AddForce(movement2d * speed);
        if (Input.GetMouseButton(0))
        {
            weaponAnim.SetFloat("Blend", 1f); // Agrandar mientras se mantiene presionado
        }
        else
        {
            weaponAnim.SetFloat("Blend", 0f); // Volver al tamaño original cuando se suelta
        }
    }
}
