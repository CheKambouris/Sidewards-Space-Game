using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static void Kill(GameObject gameObject)
	{
		if(gameObject.tag == "Player")
		{
			gameObject.GetComponent<PlayerMovement>().IsAllowedToMove = false;
			gameObject.GetComponent<Animator>().SetBool("Dead", true);
		}
		Destroy(gameObject);
	}
}
