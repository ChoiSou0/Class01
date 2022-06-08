using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Ctrl : MonoBehaviour
{
    Rigidbody2D rb;
    public int Player_Speed;
    public int Jump_Power;
    public int Jump_cnt;
    bool isGround;
    [SerializeField] Transform Feet;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float xSpeed = Input.GetAxis("Horizontal");
        Vector2 Ver = transform.position;

        Ver.x += xSpeed * Player_Speed * Time.deltaTime;

        transform.position = Ver;
    }

    private void Jump()
    {
        isGround = Physics2D.OverlapCircle(Feet.position, 0.2f, LayerMask.GetMask("Ground")).CompareTag("Ground");

        if (Input.GetKeyDown(KeyCode.Space) && Jump_cnt > 0 && isGround)
        {
            rb.AddForce(Vector2.up * Jump_Power, ForceMode2D.Impulse);
            Jump_cnt--;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            Jump_cnt = 1;
    }
}
