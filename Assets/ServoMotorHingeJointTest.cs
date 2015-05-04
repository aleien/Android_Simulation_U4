using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ServoMotorHingeJointTest : MonoBehaviour {

	public Slider targetAngleSlider;
	public Text targetAngleText;
	
	private HingeJoint servoHingeJoint;
	private int speed = 20;
	private int force = 200;
	private int absMin  = -180;
	private int absMax = 180;
	
	public float checkAngle;
	
	// Use this for initialization
	void Start () {
		targetAngleText.text = targetAngleSlider.value.ToString();
		servoHingeJoint = GetComponent<HingeJoint>();
					
		servoHingeJoint.motor = GetMotor(0, force);
		servoHingeJoint.useMotor = true;	
		servoHingeJoint.limits = GetLimits(absMin, absMax);
		servoHingeJoint.useLimits = true;
		
		Quaternion q = Quaternion.Euler(0,targetAngleSlider.value,0);
		checkAngle = Quaternion.Angle(transform.rotation, q);
		
	}
	
	// Update is called once per frame
	void Update () {
		targetAngleText.text = targetAngleSlider.value.ToString();
		
	}
	
	public void OnSliderUpdate() {
		Quaternion targetRotation = Quaternion.Euler(0,targetAngleSlider.value,0);
		checkAngle = Quaternion.Angle(transform.rotation, targetRotation);
		int newSpeed = GetSpeed(targetRotation);
		//servoHingeJoint.motor = GetMotor(newSpeed, force);
	}
	
	JointMotor GetMotor(int inSpeed, int inForce) {
		JointMotor resultMotor = new JointMotor();
		resultMotor.targetVelocity = inSpeed;
		resultMotor.force = inForce;
		return resultMotor;
	}
	
	JointLimits GetLimits(int min, int max) {
		JointLimits resultLimits = new JointLimits();
		resultLimits.min = min;
		resultLimits.max = max;
		return resultLimits;
		
	}
	
	int GetSpeed(Quaternion inAngle) {
		int resultSpeed = 0;
		resultSpeed = (int)Mathf.Sign(Quaternion.Angle(transform.rotation, inAngle))*speed;
		return resultSpeed;
	}
	
}
