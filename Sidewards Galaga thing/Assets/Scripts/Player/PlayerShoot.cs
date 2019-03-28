using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
	public GameObject Bullet;
	public float CoolDown;
	private float m_coolDownTimer;
	public bool CanShoot { get; set; }

	void Start ()
	{
		CanShoot = true;
		m_coolDownTimer = CoolDown;
	}

	void Update ()
	{
		if (m_coolDownTimer <= 0f && Input.GetButton("Fire1") && CanShoot)
		{
			Instantiate(Bullet, transform.position, transform.rotation);
			m_coolDownTimer = CoolDown;
		}
		m_coolDownTimer -= Time.deltaTime;
	}
}
