using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayerBehaviour : StateMachineBehaviour
{
	private GameObject player;
	public float RotateSpeed = 50f;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Vector2 target = player.transform.position;
		Vector2 dir = target - (Vector2)animator.gameObject.transform.position;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

		Quaternion newRotation = animator.gameObject.transform.rotation;
		newRotation = Quaternion.RotateTowards(newRotation, Quaternion.AngleAxis(angle, Vector3.forward), RotateSpeed * Time.fixedDeltaTime);
		if(newRotation == animator.gameObject.transform.rotation)
		{
			animator.SetTrigger("NextAction");
			return;
		}
		animator.gameObject.transform.rotation = newRotation;
	}
}
