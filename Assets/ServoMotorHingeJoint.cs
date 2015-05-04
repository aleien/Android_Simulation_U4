using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ServoMotorHingeJoint : MonoBehaviour {

	public bool isActive = false; 
	private float epsilon = 1f;
	
	readonly int force = 1000;
	readonly int speed = 50;
	
	private HingeJoint thisJoint;
	
	public float currentAngle = 0;
	
	void Start () {
		thisJoint = GetComponent<HingeJoint>();
		thisJoint.motor = GetMotor();
		thisJoint.useLimits = true;
		thisJoint.useMotor = true;
	}

	void Update () {		
		print (name + ": " + thisJoint.angle);
	}
	
	JointMotor GetMotor() {
		JointMotor resultMotor = new JointMotor();
		resultMotor.force = force;
		resultMotor.targetVelocity = 0;
		return resultMotor;
	}
	
	JointMotor GetMotor(int setSpeed) {
		JointMotor resultMotor = new JointMotor();
		resultMotor.force = force;
		resultMotor.targetVelocity = setSpeed;
		return resultMotor;
	}
	
	void SetAngle(float angle) {
		thisJoint.limits = GetLimits(-angle, angle);
		thisJoint.useLimits = true;
	}
	
	JointLimits GetLimits(float min, float max) {
		JointLimits resultLimits = new JointLimits();
		resultLimits.min = min;
		resultLimits.max = max;
		return resultLimits;
	}

	public void Setup(float setAngle) {
		SetAngle(setAngle);
		thisJoint.motor = GetMotor(GetVelocity(setAngle, speed));
	}
	
	int GetVelocity(float angle, int velocity) {
		int resultVelocity = velocity;
		return (thisJoint.angle < angle) ? velocity : -velocity;
	}
	
	
	
	public void Stop() {
		thisJoint.motor = GetMotor();
	}

}
