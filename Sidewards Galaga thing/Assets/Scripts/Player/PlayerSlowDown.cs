using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSlowDown : MonoBehaviour
{
	public Image EnergyBar;
	public float SlowFactor = 0.5f;
	public float MaxSlowTime;
	public float EnergyRecoveredPerSecond = 1;
	private float timeEnergy;

	void Start ()
	{
		timeEnergy = MaxSlowTime;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown("Slow") && timeEnergy / MaxSlowTime > 1f / 3f)
		{
			Time.timeScale = SlowFactor;
			Time.fixedDeltaTime *= SlowFactor;
		}
		if (Input.GetButtonUp("Slow") || timeEnergy <= 0f)
		{
			Time.timeScale = 1f;
			Time.fixedDeltaTime /= SlowFactor;
		}
		if(Time.timeScale != 1f)
		{
			timeEnergy -= Time.deltaTime;
		}
		else
		{
			timeEnergy += Time.deltaTime * EnergyRecoveredPerSecond;
		}
		EnergyBar.fillAmount = timeEnergy / MaxSlowTime;
	}
}
