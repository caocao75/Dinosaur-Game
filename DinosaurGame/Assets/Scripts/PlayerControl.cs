using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    bool Grounded;
    BoxCollider2D[] boxes;
    public Animator animator;
    public float Score;
    public int highScore;
    public Text text;
    float offset = 20;
    public static float speedup = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxes = GetComponents<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get Jump input with arrow up
        if (Input.GetKeyDown(KeyCode.UpArrow) && Grounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        //Get Crouch input with arrow down
        if (Input.GetKeyDown(KeyCode.DownArrow) && Grounded == true)
        {
            boxes[0].enabled = false;
            boxes[1].enabled = true;
            animator.SetBool("Ducking",true);
        }
        if(Input.GetKeyUp(KeyCode.DownArrow) && Grounded == true)
        {
            boxes[0].enabled = true;
            boxes[1].enabled = false;
            animator.SetBool("Ducking", false);
        }
    }
    private void FixedUpdate()
    {
        //Constantly move right direction
        running();
        CountScore();
        if(offset <= Score)
        {
            //Debug.Log("Speeded up");
            speedMulti();
            offset += 20;
        }
        
       
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            Grounded = true;
        else
        {
            Grounded = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            Grounded = false;
    }

    void running()
    {
        rb.velocity = new Vector2(moveSpeed * speedup, rb.velocity.y);
 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
    void CountScore()
    {
        //PlayerPrefs.SetInt("HighScore", highScore);
        Score += 3  * Time.deltaTime ;
        if(Score>= PlayerPrefs.GetInt("HighScore"))
        {
            highScore = Mathf.RoundToInt(Score);
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        text.text = ("  Distance = " + Mathf.RoundToInt(Score));

    }
    public void speedMulti()
    {
        speedup += 0.2f;
    }
}
