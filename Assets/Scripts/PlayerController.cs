using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    [SerializeField] public LayerMask groundMask;
    public int deathMaskNumber;
    public float speed = 10f;
    public float jumpSpeed = 10f;

    private Rigidbody2D body;
    private Animator animator;
    private BoxCollider2D boxcollider;
    private Vector3 localPlayerScale;
    private bool isRunning;
    const string enemyTag = "Enemy";

    // Start is called before the first frame update
    void Start()
    {
        body = player.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxcollider = player.GetComponent<BoxCollider2D>();
        localPlayerScale = player.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // SLOW DOWN
        if (isGrounded() && body.velocity.x > speed)
        {
            //body.velocity = new Vector2(Mathf.Max(0, body.velocity.x - speed/2f), body.velocity.y);
        }


        // MOVE (HORIZONTAL)
        isRunning = false;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            body.velocity = new Vector2(-speed, body.velocity.y);
            player.transform.localScale = new Vector3(-localPlayerScale.x, localPlayerScale.y, localPlayerScale.z);
            isRunning = true;
        } 
        else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                body.velocity = new Vector2(speed, body.velocity.y);
                player.transform.localScale = new Vector3(localPlayerScale.x, localPlayerScale.y, localPlayerScale.z);
                isRunning = true;
            }
        }
        animator.SetBool("isRunning", isRunning);


        // JUMP
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded())   body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        }
        animator.SetBool("isGrounded", isGrounded());
    }

    private bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(boxcollider.bounds.min.x, boxcollider.bounds.center.y), Vector2.down, 2*boxcollider.size.y + 0.001f, groundMask);
        if (hit.collider == null) hit = Physics2D.Raycast(new Vector2(boxcollider.bounds.max.x, boxcollider.bounds.center.y), Vector2.down, 2*boxcollider.size.y + 0.001f, groundMask);
        return hit.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.layer == deathMaskNumber)
        {
            Debug.Log("Death");
            // die animation / sound effect
            SceneManager.LoadScene(2);
        }

        if (collider.gameObject.tag == enemyTag)
        {
            Debug.Log("Hit!");
        }
    }

}
