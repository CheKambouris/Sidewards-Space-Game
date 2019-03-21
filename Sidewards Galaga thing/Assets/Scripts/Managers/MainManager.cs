using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
	private void Start()
	{
		SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive);
	}
	
}
