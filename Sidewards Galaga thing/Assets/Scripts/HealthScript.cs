using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
	public int MaxHealth;
	[Tooltip("The tag of objects that hurt this on collision")]
	public string[] TagsThatHurt;
	public int ContactDamage = 1;
	public bool DieOnContact = false;
	public bool Invincible = false;
	public float HurtInvincibleTime;
	private int m_currentHealth;
	public int CurrentHealth
	{ 
		get
		{
			return m_currentHealth;
		}
		set
		{
			m_currentHealth = value;
			if (m_currentHealth <= 0 && !Invincible)
			{
				Die();
			}
		}
	}

	private void Start()
	{
		CurrentHealth = MaxHealth;
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		bool tagFound = false;
		foreach (string tag in TagsThatHurt)
		{
			if (collision.gameObject.tag == tag || Invincible) tagFound = true;
		}
		if (!tagFound) return;

		if (DieOnContact)
		{
			Die();
		}
		HealthScript healthScript = collision.gameObject.GetComponent<HealthScript>();
		CurrentHealth -= healthScript != null ? healthScript.ContactDamage : 1;
		StartCoroutine(InvinciblePeriod(HurtInvincibleTime));
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		OnTriggerEnter2D(collision.collider);
	}

	private IEnumerator InvinciblePeriod(float time)
	{
		if (time == 0) yield break;
		Invincible = true;
		GetComponent<Animator>().SetBool("Invincible", true);
		yield return new WaitForSeconds(time);
		GetComponent<Animator>().SetBool("Invincible", false);
		Invincible = false;
	}

	private void Die()
	{
		MainManager.CurrentManager.Kill(gameObject);
	}
}
