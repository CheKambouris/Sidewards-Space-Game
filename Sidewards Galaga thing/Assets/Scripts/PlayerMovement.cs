﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {
    Rigidbody2D m_rb;
    Vector2 m_input;
    public Vector2 MaxVelocity;
    public Vector2 Acceleration;
    public float SlowFactor = 0.5f;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }
    void Update ()
    {
		Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.up = mousePosition - (Vector2)transform.position;

        m_input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Input.GetButtonDown("Slow"))
        {
            Time.timeScale = SlowFactor;
            Time.fixedDeltaTime *= SlowFactor;
        }
        if(Input.GetButtonUp("Slow"))
        {
            Time.timeScale = 1f;
			Time.fixedDeltaTime /= SlowFactor;
        }
	}
    private void FixedUpdate()
    {
        float xVelocity = m_input.x * Acceleration.x * Time.fixedDeltaTime;
        float yVelocity = m_input.y * Acceleration.y * Time.fixedDeltaTime;
        m_rb.velocity += new Vector2(
            Mathf.Clamp(xVelocity, -MaxVelocity.x - m_rb.velocity.x, MaxVelocity.x - m_rb.velocity.x), 
            Mathf.Clamp(yVelocity, -MaxVelocity.y - m_rb.velocity.y, MaxVelocity.y - m_rb.velocity.y));
    }
}
