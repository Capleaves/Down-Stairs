using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerControl : MonoBehaviour
{
    private Animator ani;
    private Rigidbody2D rbody;
    private bool isGround;

    public GameObject replayButton;
    void Start()
    {
        ani = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();   
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if(horizontal != 0)
        {
            transform.Translate(Vector2.right*horizontal*Time.deltaTime);
            GetComponent<SpriteRenderer>().flipX=horizontal>0?false:true;
            ani.SetBool("IsRun",true);
        }
        else
        {
            ani.SetBool("IsRun",false);
        }

        if(Input.GetKeyDown(KeyCode.Space)&&isGround==true)
        {
            rbody.AddForce(Vector2.up*150);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag=="Ground")
        {
            isGround=true;
            ani.SetBool("IsJump",false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            isGround = false;
            ani.SetBool("IsJump",true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="DeathLine")
        {
            Die();
        }
    }

    void Die()
    {
        Time.timeScale = 0f;
        replayButton.SetActive(true);
    }

    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }
}
