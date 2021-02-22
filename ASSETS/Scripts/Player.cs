using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public Animator animator;
    public PlayerController controller;

    float horizontalMove = 0f;

    public float runSpeed = 30f;

    bool jump = false;
    // Update is called once per frame
    void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("RunSpeed", Mathf.Abs(horizontalMove));
        
        if (Input.GetButtonDown("Jump"))
        {

            jump = true;
        }
        
	}
    private void FixedUpdate()
    {
        //Move Character
        controller.Move(horizontalMove * Time.fixedDeltaTime,false, jump);
       
        jump = false;
    }
}
