using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed = 40;
    [SerializeField] float bulletLifeTime = 2;
    [SerializeField] Transform shootPoint;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform eyes;
    [SerializeField] float sightDistance = 10;
    RaycastHit hitInfo;
    [SerializeField] float shootCooldown = 4;
    float cooldown;

    [SerializeField] Animator animator;

    bool hit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Im enemy");
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        cooldown = cooldown - Time.deltaTime;
        if (player == null || agent == null)
            return;
        agent.SetDestination(player.transform.position);
        animator.SetFloat("Speed", agent.hasPath ? agent.speed : 0);
        hit = Physics.Raycast(eyes.position, eyes.transform.forward, out hitInfo, sightDistance);
        if (hit)
        {
            if (hitInfo.transform.CompareTag("Player"))
            {
                print("Enemy has spotted player");
                if (cooldown <= 0)
                {
                    animator.SetTrigger("Shoot");
                    var clone = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
                    Vector3 bulletVel =  bulletSpeed * shootPoint.forward;
                    clone.GetComponent<Rigidbody>().linearVelocity = bulletVel;
                    clone.GetComponent<Bullet>().BulletLifeTime = bulletLifeTime;
                    cooldown = shootCooldown;
                }
            }
        }
    }
    void OnDrawGizmos()
    {
        if (hit && hitInfo.transform.CompareTag("Player"))
        {
            Gizmos.color = Color.green;

        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawRay(eyes.position, eyes.transform.forward * sightDistance);
    }
}
