using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
	public float Speed;

	// Update is called once per frame
	void Update ()
	{
		transform.position += transform.up * Speed * Time.deltaTime;
	}

	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
