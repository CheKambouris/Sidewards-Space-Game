using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

	public void GoToGameMode()
	{
		Camera.main.GetComponent<Animator>().SetBool("InBattle", true);
		
		SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
		SceneManager.UnloadSceneAsync(gameObject.scene);
	}
}
