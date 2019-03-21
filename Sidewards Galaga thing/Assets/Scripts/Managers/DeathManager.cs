using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
	public void ReloadMenuScene()
	{
		SceneManager.LoadScene(3); // Load Main
	}
}
