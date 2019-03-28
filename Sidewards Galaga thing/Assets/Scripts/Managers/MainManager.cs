using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class MainManager : MonoBehaviour
{
	public static MainManager CurrentManager;
	public UnityEvent playerDeathEvents;

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
	public void Reload()
	{
		SceneManager.LoadScene(0);
	}
}
