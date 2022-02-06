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
            Vector3 newTopPos = top.transform.localPosition;
            newTopPos.y = value / 2;
            top.transform.localPosition = newTopPos;
            Vector3 newBottomPos = bottom.transform.localPosition;
            newBottomPos.y = -value / 2;
            bottom.transform.localPosition = newBottomPos;
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
