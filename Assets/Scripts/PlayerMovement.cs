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
    void Start()
    {
        movementController = GetComponent<MovementController>(); 
    }

   
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical"); 

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
    }

    private void FixedUpdate() {
        movementController.Move(new Vector2(horizontal, vertical));
        handController.AngleHand(mousePos);
    }
}
