using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnSetActive : MonoBehaviour {

	public UnityEvent UnityEvent;
	private void Awake()
	{
		UnityEvent.Invoke();
	}
	
}
