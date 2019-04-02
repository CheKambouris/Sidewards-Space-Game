using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
	public bool CanMove { get; set; }
	Rigidbody2D m_rb;
    Vector2 m_input;

    public Vector2 MaxVelocity;
    public Vector2 Acceleration;

    private void Start()
    {
		CanMove = true;
        m_rb = GetComponent<Rigidbody2D>();
    }
    void Update ()
    {
		if (!CanMove)
		{
			m_input = Vector2.zero;
			return;
		}

		Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.up = mousePosition - (Vector2)transform.position;

        m_input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
	}
    private void FixedUpdate()
    {
		// Act on inputs
        float xVelocity = m_input.x * Acceleration.x * Time.fixedDeltaTime;
        float yVelocity = m_input.y * Acceleration.y * Time.fixedDeltaTime;
		// Clamp velocity
        m_rb.velocity += new Vector2(
            Mathf.Clamp(xVelocity, -MaxVelocity.x - m_rb.velocity.x, MaxVelocity.x - m_rb.velocity.x), 
            Mathf.Clamp(yVelocity, -MaxVelocity.y - m_rb.velocity.y, MaxVelocity.y - m_rb.velocity.y));
		// Get camera positions
		Vector2 cameraBottomLeft = Camera.main.ViewportToWorldPoint(Vector3.zero);
		Vector2 cameraTopRight = Camera.main.ViewportToWorldPoint(Vector3.right + Vector3.up);
		// Clamp player to camera
		transform.position = new Vector2
			(Mathf.Clamp(transform.position.x, cameraBottomLeft.x, cameraTopRight.x),
			Mathf.Clamp(transform.position.y, cameraBottomLeft.y, cameraTopRight.y));
    }
}
