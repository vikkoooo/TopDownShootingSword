using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyFollowPlayer : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    private Transform target;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        Vector3 moveDirection = target.position - transform.position;
        float magnitude = moveDirection.magnitude;
        moveDirection.Normalize();

        Vector3 velocity = moveDirection * moveSpeed;
        rb.velocity = new Vector3 (velocity.x, velocity.y, velocity.z);

        /*transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);*/
        
    }
}
