using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D physic;

    public Transform player;

    public float speed;
    public float agroDistance;
    [SerializeField]
    float radius = 0.1f;
    [SerializeField]
    LayerMask playerMask;
        

    void Start()
    {
        physic = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < agroDistance)
        {
            if (distToPlayer > 1.5f)
            {
                StartHunting();
            } else
            {
                physic.velocity = new Vector2(0, 0);
            }
            PlayerHit();
        }
        else
        {
            StopHunting();
        }
    }

    void StartHunting()
    {
       
        if (player.position.x < transform.position.x)
        {
            physic.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector2(6, 6);
        }
        else if (player.position.x > transform.position.x)
        {
            physic.velocity = new Vector2(speed, 0);
            transform.localScale = new Vector2(-6, 6);
        }
    }

    void StopHunting()
    {
        physic.velocity = new Vector2(0, 0);
    }
    void PlayerHit()
    {
        Collider2D coll = Physics2D.OverlapCircle(transform.position, radius, playerMask);
        if (coll != null)
        {
            coll.GetComponent<PlayerController>().TakeDamage(1);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
