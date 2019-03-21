using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class EnemyController : MonoBehaviour
{
	public Transform Transform;

	private Animator m_animator;

	private void Start()
	{
		//m_animator.GetBehaviour<PositioningBehaviour>().Transform = Transform;
	}

	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
#region Spaghettttt
//[Header("Positioning")]
//public Vector2 FirePosition;
//public Vector2 Destination;
//[Header("Properties")]
//public float Speed = 1;
//public float RotateSpeed = 1;

//private byte action = 0;
//private Rigidbody2D _rb;

//private void Start()
//{
//	_rb = GetComponent<Rigidbody2D>();
//}

//private void FixedUpdate()
//{
//	switch (action)
//	{
//		case 0:
//			Vector2 target = GameObject.FindGameObjectWithTag("Player").transform.position;
//			Vector2 dir = target - (Vector2)transform.position;
//			float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
//			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), RotateSpeed * Time.fixedDeltaTime);
//			break;
//		case 1:
//		case 2:
//		case 3:
//		case 4:
//		case 5:
//		default:
//			Destroy(gameObject);
//			break;
//	}
//}
#endregion