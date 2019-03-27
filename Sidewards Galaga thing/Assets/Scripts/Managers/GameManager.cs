using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager gameManager;

	private void Start()
	{
		gameManager = this;
	}

	public void Kill(GameObject gameObject)
	{
		if(gameObject.tag == "Player")
		{
			gameObject.GetComponent<PlayerMovement>().CanMove = false;
			gameObject.GetComponent<Animator>().SetBool("Dead", true);
			return;
		}
		Destroy(gameObject);
	}
}
