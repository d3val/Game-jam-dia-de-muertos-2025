using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10.0f;
    Vector2 playerInput;
    [SerializeField] InputActionAsset actionAsset;
    private InputAction moveAction;

    private void Awake()
    {
        moveAction = actionAsset.FindActionMap("Player").FindAction("Move");
    }

    private void OnEnable()
    {
        moveAction.performed += ReadMove;
        moveAction.canceled += ReadMove;
    }

    private void OnDisable()
    {
        moveAction.performed -= ReadMove;
        moveAction.canceled -= ReadMove;
    }

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 playerDirection = new Vector3(playerInput.x, 0, playerInput.y);
        rb.AddForce(playerDirection * speed, ForceMode.Force);
    }

    private void ReadMove(InputAction.CallbackContext ctx)
    {
        playerInput = ctx.ReadValue<Vector2>();
    }
}
