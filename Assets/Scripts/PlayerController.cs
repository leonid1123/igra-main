using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.1f;
    public Rigidbody2D physic;

    [SerializeField]
    public float jumpForce = 400;

    public bool isLeft = false;

    private bool isGrounded;
    private float groundRadius = 0.3f;

    public Transform groundCheck;
    public LayerMask groundMask;
    [SerializeField]
    int HP = 100;

    private void Update()
    {
        transform.position += new Vector3(speed, 0, 0) * Input.GetAxis("Horizontal");

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundMask);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            physic.AddForce(new Vector2(0, jumpForce));
        }

        if(Input.GetAxis("Horizontal") < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            isLeft= true;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            isLeft= false;
        }
    }
    public void TakeDamage(int _dmg)
    {
        HP -= _dmg;
        //сюда смерт и перезапуск если HP<0
    }
}
