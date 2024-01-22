using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    static public PlayerMovement Instance;

    private Animator PlayerAnimator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        PlayerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        PlayerAnimator.SetFloat("Speed",Mathf.Abs(horizontalMove));
        if(Input.GetButton("Jump") && runSpeed != 0)
        {
            jump = true;
            PlayerAnimator.SetBool("isJumping",true);
        }
        if(Input.GetButtonDown("Crouch") && runSpeed != 0) // 나중에 기어다니는거 추가할때 대가리 collider추가해서 컴포넌트에 추가하기!!!!!!!
        {
            crouch = true;
        } 
        else if(Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void onLand()
    {
        PlayerAnimator.SetBool("isJumping",false);
    }

    public void onCrouch(bool crouch)
    {
        PlayerAnimator.SetBool("isCrouching",crouch);
    }

    void FixedUpdate() 
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
