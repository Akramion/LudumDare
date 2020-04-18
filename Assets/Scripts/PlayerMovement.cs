using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontal;
    float vertical;
    MovementController movementController;
    void Start()
    {
        movementController = GetComponent<MovementController>(); 
    }

   
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical"); 
    }

    private void FixedUpdate() {
        movementController.Move(new Vector2(horizontal, vertical));
    }
}
