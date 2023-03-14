using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharMove : MonoBehaviour {
	Animator animator;
	CharacterController cc;
	public GameObject enemy;
	NavMeshAgent navMeshAgent;
	AIController AIController;

	void Start () {
		animator = GetComponent<Animator> ();
		cc = GetComponent<CharacterController> ();
		navMeshAgent = enemy.GetComponent<NavMeshAgent> ();
		AIController = enemy.GetComponent<AIController> ();
	}

	void Update () {
		//前進成分を取得(0~1),今回はバックはしない
		// float acc = Mathf.Max (Input.GetAxis ("Vertical"), 0f);

		if (navMeshAgent.speed==AIController.speedWalk) {
			//walkモーション開始
			animator.SetBool("walk", true);
		} else {
			animator.SetBool("walk", false);
		}
		if (navMeshAgent.speed==AIController.speedRun) {
			//runモーション開始
			animator.SetBool("run", true);
		}else {
			animator.SetBool("run", false);
			//shootモーション開始
			// animator.SetTrigger ("shoot");
		}
	}	
}

