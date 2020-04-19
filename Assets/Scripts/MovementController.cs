using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float moveSpeed;
    public float moveLimiter = 0.7f;
    private Rigidbody2D rigidbody;

    private void Start() {
        rigidbody = GetComponent<Rigidbody2D>(); 
        
    }

    public void Move(Vector2 movement) {
        if (movement.x != 0 && movement.y != 0)
        {
            movement.x *= moveLimiter;
            movement.y *= moveLimiter;
        }

<<<<<<< HEAD
        rigidbody.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
=======
         rigidbody.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);

        if (rigidbody.velocity.x > 0 && !m_FacingRight)
        {
            Flip();
        }
        else if (rigidbody.velocity.x < 0 && m_FacingRight)
        {
            Flip();
        }
>>>>>>> a1750b3a1f8b3a3b7135f02cb2726ff99a7a1766
    }
}
