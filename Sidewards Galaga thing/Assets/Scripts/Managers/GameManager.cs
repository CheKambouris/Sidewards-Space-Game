using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private void Start()
	{
		SceneManager.SetActiveScene(gameObject.scene);
	}

	public static void Kill(GameObject gameObject)
	{
		if(gameObject.tag == "Player")
		{
			gameObject.GetComponent<PlayerMovement>().IsAllowedToMove = false;
			gameObject.GetComponent<Animator>().SetBool("Dead", true);
			SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive); // Death Scene
			SceneManager.UnloadSceneAsync(1); // Unload Game Scene
			return;
		}
		Destroy(gameObject);
	}
}
