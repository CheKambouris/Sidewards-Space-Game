using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	public void GoToGameMode()
	{
		SceneManager.LoadSceneAsync(1);
		SceneManager.UnloadSceneAsync(0);
	}
}
