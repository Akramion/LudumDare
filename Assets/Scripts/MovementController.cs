using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float moveSpeed;
    public float moveLimiter = 0.7f;
    private Rigidbody2D rigidbody;
    private bool m_FacingRight = true;

    

    private GameObject hand;

    private void Start() {
        rigidbody = GetComponent<Rigidbody2D>(); 
        hand = gameObject.transform.GetChild(0).gameObject;
        
    }

    public void Move(Vector2 movement) {
        if (movement.x != 0 && movement.y != 0)
        {
            movement.x *= moveLimiter;
            movement.y *= moveLimiter;
        }

        rigidbody.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);

        if (rigidbody.velocity.x > 0 && !m_FacingRight)
        {
            Flip();
        }
        else if (rigidbody.velocity.x < 0 && m_FacingRight)
        {
            Flip();
        }
    }

	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

        Vector3 handScale = hand.transform.localScale;
        handScale.y *= -1;
        hand.transform.localScale = handScale;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
