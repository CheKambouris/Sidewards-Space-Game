using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamiKazeBehaviour : StateMachineBehaviour {

	public float Speed;
	private Vector3 playerPosition;
	
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Vector3 nextPos = Vector3.MoveTowards(animator.transform.position, playerPosition, Speed * Time.deltaTime);
		if (animator.transform.position == playerPosition)
		{
			animator.SetTrigger("NextAction");
			return;
		}
		animator.transform.position = nextPos;
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
