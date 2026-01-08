using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
   
    public static bool isAim = false;
    public static bool axel = false;
    public float playerSpeed = 3f;
    [HideInInspector] public Vector3 dir;
    float hzInput, vInput;
    CharacterController controller;
    Animator animPlayer;

    [SerializeField] float groundYOffset;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float gravity = -9.81f;
    Vector3 spherePos;
    Vector3 velocity;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetDirectionAndMove();
        Gravity();
        RunAnimation();
        AnimAxel();
    }

    void GetDirectionAndMove()
    {
        hzInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        dir = transform.forward * vInput + transform.right * hzInput;
        controller.Move(dir.normalized * playerSpeed * Time.deltaTime);
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed = 6f;
            
        }
        else playerSpeed = 3f; 

        animPlayer.SetFloat("hzInput", hzInput);
        animPlayer.SetFloat("vInput", vInput);
    }
     void RunAnimation()
    {
        if (playerSpeed == 6f)
        {
            animPlayer.SetBool("Run", true);
        }
        else animPlayer.SetBool("Run", false);
    }

    bool IsGrounded()
    {
        spherePos = new Vector3(transform.position.x, transform.position.y - groundYOffset, transform.position.z);
        if (Physics.CheckSphere(spherePos, controller.radius - 0.05f, groundMask)) return true;
        return false;

    }

    void Gravity()
    {
        if (!IsGrounded()) velocity.y += gravity * Time.deltaTime;
        else if (velocity.y < 0) velocity.y = -2;
        controller.Move(velocity * Time.deltaTime);
     }


    void AnimAxel()
    {
        if(axel == true  )
        {
            animPlayer.SetBool("AxelWalk", true);
        }
        else animPlayer.SetBool("AxelWalk", false);

        if ( axel == true && Input.GetKey(KeyCode.LeftShift))
       {
            animPlayer.SetBool("AxelRun", true);
       } else animPlayer.SetBool("AxelRun", false);

    }

    
    
   
}
