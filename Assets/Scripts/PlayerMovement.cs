using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Vector2 moveInput;
    private Rigidbody2D rb;
    private PlayerInput playerInput;
    private InputAction moveAction;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        moveAction = playerInput.actions["Move"];
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    private void FixedUpdate()
    {
        moveInput = moveAction.ReadValue<Vector2>();

        Vector2 movement = moveInput.normalized * moveSpeed;
        rb.velocity = movement;

        // Update Animator
        animator.SetFloat("MoveX", moveInput.x);
        animator.SetFloat("MoveY", moveInput.y);
    }
}
