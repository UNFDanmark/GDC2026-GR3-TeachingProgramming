using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    [SerializeField] int speed;

    [SerializeField] int gunCooldown;

    [SerializeField] InputAction moveAction;

    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Im player");
        rb = GetComponent<Rigidbody>();
        moveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDir = moveAction.ReadValue<Vector2>();

        Vector3 newVel = rb.linearVelocity;
        newVel.x = moveDir.x * speed;
        newVel.z = moveDir.y * speed;

        rb.linearVelocity = newVel;

    }
}
