using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
	public int MaxHealth;
	public float HurtInvincibleTime;
	[Tooltip("The tag of objects that hurt this on collision")]
	public string[] TagsThatHurt;
	public int ContactDamage = 1;
	public bool DieOnContact = false;
	public bool Invincible = false;
	public bool WaitForDeathAnimation = true;
	public bool UseHealthbar = false;
	public Image Healthbar;
	private int m_currentHealth;
	private Animator m_animator;

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
				StartCoroutine(Die());
			}
		}
	}

	private void Start()
	{
		CurrentHealth = MaxHealth;
		m_animator = GetComponent<Animator>();
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (Invincible) return;
		bool tagFound = false;
		foreach (string tag in TagsThatHurt)
		{
			if (collision.gameObject.tag == tag)
			{
				tagFound = true;
				break;
			}
		}
		if (!tagFound) return;

		if (DieOnContact)
		{
			StartCoroutine(Die());
		}
		HealthScript healthScript = collision.gameObject.GetComponent<HealthScript>();
		CurrentHealth -= healthScript != null ? healthScript.ContactDamage : 1;
		if (UseHealthbar)
			Healthbar.fillAmount = (float)m_currentHealth / MaxHealth;
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
		if(m_animator)m_animator.SetBool("Invincible", true);
		yield return new WaitForSeconds(time);
		if(m_animator)m_animator.SetBool("Invincible", false);
		Invincible = false;
	}

	private IEnumerator Die()
	{
		if(m_animator)m_animator.SetTrigger("Die");
		yield return new WaitForEndOfFrame();
		if(WaitForDeathAnimation)
			yield return new WaitForSeconds(m_animator.GetCurrentAnimatorClipInfo(0)[0].clip.length);
		MainManager.CurrentManager.Kill(gameObject);
	}
}
