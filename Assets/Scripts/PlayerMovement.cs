using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10.0f;
    Vector2 playerInput;
    [Header("Player inputs")]
    [SerializeField] InputActionAsset actionAsset;
    private InputAction moveAction;
    [Header("Player animations")]
    [SerializeField] Animator animator;

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

    private void Update()
    {
        UpdateRenderer();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 playerDirection = new Vector3(playerInput.x, 0, playerInput.y);
        rb.AddForce(playerDirection * speed, ForceMode.Force);
        animator.SetFloat("speed", rb.linearVelocity.magnitude);
    }

    private void UpdateRenderer()
    {
        float currentXScale = transform.localScale.x;
        if (playerInput.x < 0)
        {
            currentXScale = Mathf.Abs(currentXScale);
        }
        else if (playerInput.x > 0)
        {
            currentXScale = -Mathf.Abs(currentXScale);
        }

        transform.localScale = new Vector3(currentXScale, transform.localScale.y, transform.localScale.z);
    }

    private void ReadMove(InputAction.CallbackContext ctx)
    {
        playerInput = ctx.ReadValue<Vector2>();
    }
}
