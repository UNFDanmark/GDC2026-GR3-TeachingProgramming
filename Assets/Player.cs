using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] int bulletSpeed = 20;
    [SerializeField] float bulletLifeTime = 5;
    [SerializeField] float gunCooldown;
    float cooldownLeft;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform shootPoint;
    [SerializeField] InputAction moveAction;
    [SerializeField] InputAction shootAction;
    [SerializeField] Animator animator;

    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Im player");
        rb = GetComponent<Rigidbody>();
        moveAction.Enable();
        shootAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownLeft = cooldownLeft - Time.deltaTime;
        Vector2 moveDir = moveAction.ReadValue<Vector2>();

        Vector3 newVel = rb.linearVelocity;
        newVel.x = moveDir.x * speed;
        newVel.z = moveDir.y * speed;

        rb.linearVelocity = newVel;
        animator.SetFloat("Speed",newVel.magnitude);
        if (shootAction.WasPressedThisFrame() && cooldownLeft <= 0) 
        {
            animator.SetTrigger("Shoot");
            var clone = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            Vector3 bulletVel = shootPoint.rotation * new Vector3(bulletSpeed, 0, 0);
            clone.GetComponent<Rigidbody>().linearVelocity = bulletVel;
            clone.GetComponent<Bullet>().BulletLifeTime = bulletLifeTime;
            cooldownLeft = gunCooldown;
        }

    }
}
