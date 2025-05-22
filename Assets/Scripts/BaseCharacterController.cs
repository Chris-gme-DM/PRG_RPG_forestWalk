using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using static UnityEngine.InputSystem.InputAction;

public class BaseCharacterController : MonoBehaviour
{
    private Vector2 movementInput;
    [Range(0.5f, 10f)][SerializeField] private float movementSpeed;
    [Range(0, 10f)][SerializeField] float movementAccelaration;
    [Range(0,1f)][SerializeField] private float slowFactor;
    private Rigidbody2D rb;
    public bool isSlowed ; 
    public bool isPlayerPaused;
    private bool isFightActive;
    private Vector3Int currentPosition, lastEncounterPosition;
    private CharacterAnimationManage cam;
    public Tilemap Tilemap
    {
        get
        {
            if (m_tilemap == null) m_tilemap = FindObjectOfType<Tilemap>();
            return m_tilemap;
        }
    }
    private Tilemap m_tilemap;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isSlowed = false;
        isFightActive = false;
        isPlayerPaused = false;
        cam = GetComponent<CharacterAnimationManage>();
    }
    public void Movement(CallbackContext ctx) 
    {
        movementInput = ctx.ReadValue<Vector2>();
        if (!isPlayerPaused)
            cam.SetAnimatorValues(movementInput.x, movementInput.y); //Set animator values to the input values
        else
            cam.SetAnimatorValues(0, 0); //Set animator values to 0 if the player is paused
    }
    private void FixedUpdate()
    {  
        if(isFightActive) return;
        
        var actualMovementSpeed = isSlowed ? movementSpeed * slowFactor : movementSpeed;
        // Transform to move the player
        transform.Translate(new Vector2(movementInput.x, movementInput.y) * Time.deltaTime * actualMovementSpeed);
        currentPosition = Tilemap.WorldToCell(transform.position);
        // Will add Force because Physics to smooth out movement
        rb.AddForce(new Vector2(movementInput.x, movementInput.y) * Time.deltaTime * actualMovementSpeed * movementAccelaration, ForceMode2D.Force);

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Swamp"))
        {
            isSlowed = true;
        }
        else if(collision.gameObject.CompareTag("TallGrass"))
        {
            if (currentPosition != lastEncounterPosition)
            {
                lastEncounterPosition = currentPosition;
                PausePlayer(FightManager.Instance.CheckForEncounter());
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Swamp"))
        {
            isSlowed = false;
        }
    }
    public void PausePlayer(bool isPaused)
    {
        isPlayerPaused = true;
    }
}
