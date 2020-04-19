using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera cam;
    public HandController handController;
    float horizontal;
    float vertical;
    Vector2 mousePos;
    MovementController movementController;

    private Animator animator;
    void Start()
    {
        movementController = GetComponent<MovementController>(); 
        animator = gameObject.GetComponent<Animator>();
    }

   
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical"); 

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Animate();
        
    }

    private void Animate() {
        if(horizontal != 0 || vertical != 0) {
            animator.SetBool("isMove", true);
        }

        else {
            animator.SetBool("isMove", false);
        }
    }

    private void FixedUpdate() {
        movementController.Move(new Vector2(horizontal, vertical));
    }
}
