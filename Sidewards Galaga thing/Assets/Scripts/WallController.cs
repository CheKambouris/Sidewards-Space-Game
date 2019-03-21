using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    [Header("Wall Parts")]
    public GameObject top;
    public GameObject bottom;
    [Header("Properties")]
    float space;
    public float Space
    {
        get { return space; }
        set
        {
            Vector3 newTopPos = top.transform.position;
            newTopPos.y = value / 2;
            top.transform.position = newTopPos;
            Vector3 newBottomPos = bottom.transform.position;
            newBottomPos.y = -value / 2;
            bottom.transform.position = newBottomPos;
            space = value;
        }
    }
    public float speed;

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
