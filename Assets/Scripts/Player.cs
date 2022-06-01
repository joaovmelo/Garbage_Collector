using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Speed;
    public float JumpForce;
    
    public bool isJumping;
    public bool DoubleJump;
    
    private Rigidbody2D rig;
    private Animator anim;




    // Start is called before the first frame update
    void Start(){
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){
        Move();
        Jump();
    }

    void Move(){
        
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        //transform.position += movement * Time.deltaTime * Speed;

        float movement = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(movement * Speed, rig.velocity.y);

        if (movement > 0){
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        else if (movement < 0){
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        else if (movement == 0){
            anim.SetBool("walk", false);
        }
    }

    void Jump(){
        if(Input.GetButtonDown("Jump")){
            if (!isJumping){
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                DoubleJump = true;
                anim.SetBool("jump", true);
            }
            else
            {
                if (DoubleJump){
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    DoubleJump = false;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer == 8){
            isJumping = false;
            anim.SetBool("jump", false);
        }

        if(collision.gameObject.tag == "Spike"){
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Saw")
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.layer == 8){
            isJumping = true;
        }
    }
}
