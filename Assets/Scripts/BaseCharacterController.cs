using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.InputAction;

public class BaseCharacterController : MonoBehaviour
{
    private Vector2 movementInput;
    [Range(0.5f, 10f)][SerializeField] private float movementSpeed;
    [Range(0, 10f)][SerializeField] float movementAccelaration;
    [Range(0,1f)][SerializeField] private float slowFactor;
    [Range(0, 1f)][SerializeField] private float enemyEncounter;
    private Rigidbody2D rb;
    private bool isSlowed;
    private bool enemyEncounterEnabled;

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
        transform.Translate(new Vector2(movementInput.x, movementInput.y) * Time.deltaTime * actualMovementSpeed);
        // Will add Force because Physics to smooth out movement
        rb.AddForce(new Vector2(movementInput.x, movementInput.y) * Time.deltaTime * actualMovementSpeed * movementAccelaration, ForceMode2D.Force);

        //RandomEncounter Check
        if (enemyEncounterEnabled)
        {
            float randomValue = Random.Range(0f, 1f);
            if (randomValue < enemyEncounter * Time.deltaTime)
            {
                // Trigger enemy encounter
                Debug.Log("Enemy Encounter Triggered!");
                enemyEncounterEnabled = false; // Disable further encounters until re-enabled
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("TallGrass"))
        {
            enemyEncounterEnabled = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Swamp"))
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
    private void CheckforEncounter()
    {
        FightManager.Instance.CheckForEncounter();
    }
}
