using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PMove : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 13f; 
    private bool  isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public TMP_Text scoreText;
    public TMP_Text timeText;

    Vector4 startPOS;

    public float timeLeft = 10;
    int score = 0;

    AudioSource src;
    public AudioClip jumpSound;
    public AudioClip pointSound; 
    
    private void Start()
    {
        startPOS = transform.position;
        src = GetComponent<AudioSource>();
    }
    
    
    void Update ()
    {
        timeLeft -= Time.deltaTime;
        timeText.text = "Time: " + timeLeft.ToString("0.0");
        
        if (timeLeft <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("TheEndFail");
        }
       
        if (transform.position.y < -8)
        {
            transform.position = startPOS; 
        }
       
        
        horizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            src.PlayOneShot(jumpSound);
        }
        if (Input.GetButtonDown("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y  * 0.5f);
            src.PlayOneShot(jumpSound);
        }

        Flip();

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }


    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    
    
    private void Flip() {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale; 
        }         
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Banana"))
        {
            score++;
            scoreText.text = "Score: " + score.ToString();
            src.PlayOneShot(pointSound);
            Destroy(collision.gameObject);

        }
    }
 
}
