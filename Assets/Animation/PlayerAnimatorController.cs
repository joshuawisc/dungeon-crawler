using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{

	public bool IsRolling = false;
	public bool IsDead = false;
	public bool IsJump = false;
	public float Direction = 0.5f;
	public Animator Anitor;
	public float Velocity = 0f;

	public int IsRollingId =-1;
	public int IsJumpId = -1;
	public int IsDeadId = -1;

	AnimatorOverrideController overrideController;

	void Awake()
	{
		//获得哈希id
		IsRollingId = Animator.StringToHash ("IsRolling");
		IsDeadId = Animator.StringToHash ("IsDead");
		IsJumpId = Animator.StringToHash ("IsJump");

		//要动态修改Animator 需要给OverrideController
		overrideController = new AnimatorOverrideController();  
		overrideController.runtimeAnimatorController  = Anitor.runtimeAnimatorController;  
	}

	// Use this for initialization
	void Start () {
		
		var runClip = overrideController["Run"];  
		Anitor.runtimeAnimatorController = overrideController;  

		//动态添加事件
		AnimationEvent aEvent1 = new AnimationEvent();  
		aEvent1.time           = runClip.length;  
		aEvent1.functionName   = "OnOpenComplete";   
		aEvent1.stringParameter = runClip.length.ToString ();
		runClip.AddEvent(aEvent1);  
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.A)) {
			Velocity = 1.0f;
		} else {
			Velocity = 0f;
		}
	   
		if (Input.GetKey (KeyCode.W)) {
			IsJump = true;
		} else {
			IsJump = false;
		}
		if (Input.GetKey (KeyCode.A)) {
			Direction = 0;
		} else if (Input.GetKey (KeyCode.D)) {
			Direction = 1;
		} else {
			Direction = 0.5f;
		}


		Anitor.SetFloat ("Velocity",Velocity);
		Anitor.SetBool (IsRollingId,IsRolling);
		Anitor.SetBool (IsDeadId,IsDead);
		Anitor.SetBool (IsJumpId,IsJump);
		Anitor.SetFloat ("Direction",Direction);

	}

	void OnOpenComplete(string str)
	{
		Debug.Log ("OnOpenComplete="+str);
	}
}