using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
	bool anim_Invincible
	{
		get { return GetComponent<Animator>().GetBool("Invincible"); }
		set { GetComponent<Animator>().SetBool("Invincible", value); }
	}
	HealthScript m_healthScript;
	private void Start()
	{
		m_healthScript = GetComponent<HealthScript>();
	}
	private void Update()
	{
		anim_Invincible = m_healthScript.Invincible;
	}
}
