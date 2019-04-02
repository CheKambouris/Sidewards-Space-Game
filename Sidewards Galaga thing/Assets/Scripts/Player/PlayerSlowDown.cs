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
	[SerializeField]private float timeEnergy;
	private float normalFixedUpdate;

	void Start ()
	{
		timeEnergy = MaxSlowTime;
		normalFixedUpdate = Time.fixedDeltaTime;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown("Slow") && timeEnergy / MaxSlowTime > 1f / 3f)
		{
			Time.timeScale = SlowFactor;
			Time.fixedDeltaTime = Time.timeScale * normalFixedUpdate;
		}
		if (Input.GetButtonUp("Slow") || timeEnergy <= 0f)
		{
			Time.timeScale = 1f;
			Time.fixedDeltaTime = normalFixedUpdate;
		}
		if (Time.timeScale != 1f)
		{
			timeEnergy -= Time.deltaTime / Time.timeScale;
			if (timeEnergy < 0) timeEnergy = 0;
		}
		else
		{
			float nextEnergyVal = timeEnergy + EnergyRecoveredPerSecond * Time.deltaTime;
			timeEnergy = timeEnergy >= MaxSlowTime ? MaxSlowTime : nextEnergyVal;
		}
		EnergyBar.fillAmount = timeEnergy / MaxSlowTime;
	}
}
