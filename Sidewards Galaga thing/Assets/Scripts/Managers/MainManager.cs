using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class MainManager : MonoBehaviour
{
	public static MainManager CurrentManager;
	public UnityEvent deathEvents;

	private void Start()
	{
		CurrentManager = this;
	}

	public void Kill(GameObject gameObject)
	{
		if (gameObject.tag == "Player")
		{
			gameObject.GetComponent<PlayerMovement>().CanMove = false;
			gameObject.GetComponent<Animator>().SetBool("Dead", true);
			deathEvents.Invoke();
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
