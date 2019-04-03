using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
	[Header("Events")]
	public UnityEvent playerDeathEvents;

	public static MainManager CurrentManager;
	[HideInInspector]public float timer = 0f;

	private void Start()
	{
		CurrentManager = this;
	}

	public void Kill(GameObject gameObject)
	{
		if (gameObject.tag == "Player")
		{
			playerDeathEvents.Invoke();
			return;
		}
		Destroy(gameObject);
	}
	public void DestroyChildren()
	{
		for(int i = 0;  i < transform.childCount; i++)
		{
			Destroy(transform.GetChild(i).gameObject);
		}
	}
	public void StartTimer()
	{
		StartCoroutine(DoTimer());
	}
	public void StopTimer()
	{
		StopCoroutine(DoTimer());
	}
	private IEnumerator DoTimer()
	{
		while (true)
		{
			yield return new WaitForEndOfFrame();
			timer += Time.deltaTime;
		}
	}
	public void Reload()
	{
		SceneManager.LoadScene(0);
	}
}