using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Ctrl : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    public int Player_Speed;
    public int Jump_Power;
    public int Jump_cnt;

    public GameObject ATKObj;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Attack();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * Player_Speed * Time.deltaTime);
            spriteRenderer.flipX = false;
            animator.SetBool("isWalk", true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * Player_Speed * Time.deltaTime);
            spriteRenderer.flipX = true;
            animator.SetBool("isWalk", true);
        }
        else
        {
            animator.SetBool("isWalk", false);
        }

    }

    private void Jump()
    {
        //isGround = Physics2D.OverlapCircle(Feet.position, 0.2f, LayerMask.GetMask("Ground")).CompareTag("Ground");

        if (Input.GetKeyDown(KeyCode.Space) && Jump_cnt > 0)
        {
            rb.AddForce(Vector2.up * Jump_Power, ForceMode2D.Impulse);
            Jump_cnt--;
        }

    }

    private void Attack()
    {
        Vector2 Pos = new Vector2(0, 0);

        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.Play("Player_ATK");

            if (spriteRenderer.flipX)
            {
                Pos = new Vector2(transform.position.x + 1, transform.position.y - 1);
                var ATK = Instantiate(ATKObj, Pos, Quaternion.identity);
                Destroy(ATK, 0.1f);
            }
            else if (!spriteRenderer.flipX)
            {
                Pos = new Vector2(transform.position.x - 1, transform.position.y - 1);
                var ATK = Instantiate(ATKObj, Pos, Quaternion.identity);
                Destroy(ATK, 0.1f);
            }

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            Jump_cnt = 1;
    }
}
