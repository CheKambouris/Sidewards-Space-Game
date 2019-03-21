using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetIntoPositionBehaviour : StateMachineBehaviour
{
	private Vector3 destination;
	public float DistFromCamSpawn;
	public float DistFromEdgePos;
	public float Speed = 5f;
	
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		// Get Camera Corners
		Vector3 topRightCam = Camera.main.ViewportToWorldPoint(Vector3.up + Vector3.right);
		Vector3 bottomRightCam = Camera.main.ViewportToWorldPoint(Vector3.zero +Vector3.right);
		// Set position to just off screen
		animator.gameObject.transform.position = new Vector3(topRightCam.x + DistFromCamSpawn, Random.Range(topRightCam.y, bottomRightCam.y));
		// Set destination to on screen
		destination = animator.transform.position;
		destination.x = topRightCam.x - DistFromEdgePos;
		// Set default rotation to be facing left
		Quaternion faceLeftRotation = new Quaternion();
		faceLeftRotation.eulerAngles = new Vector3(0, 0, 90);
		animator.transform.rotation = faceLeftRotation;
	}
	
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		// Move to destination
		animator.gameObject.transform.position = Vector3.MoveTowards(animator.gameObject.transform.position, destination, Speed * Time.deltaTime);
		// If reached, continue
		if (animator.transform.position == destination)
		{
			animator.SetTrigger("NextAction");
		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
