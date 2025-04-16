using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class BaseCharacterController : MonoBehaviour
{
    private Vector2 movementInput;
    [Range(0.5f, 4f)][SerializeField] private float movementSpeed;
    [Range(0, 10f)][SerializeField] float movementAccelaration;
    [Range(0,1f)][SerializeField] private float slowFactor;
    private Rigidbody2D rb;
    private bool isSlowed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isSlowed = false;
    }
    public void Movement(CallbackContext ctx) 
    {
        movementInput = ctx.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {  
        var actualMovementSpeed = isSlowed ? movementSpeed * slowFactor : movementSpeed;
        // Transform to move the player
        transform.Translate(new Vector3(movementInput.x, movementInput.y, 0) * Time.deltaTime * actualMovementSpeed);
        // Will add Force because Physics to smooth out movement
        rb.AddForce(new Vector3(movementInput.x, movementInput.y, 0) * Time.deltaTime * actualMovementSpeed * movementAccelaration, ForceMode2D.Force);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Swamp"))
        {
            isSlowed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Swamp"))
        {
            isSlowed = false;
        }
    }
}
