using UnityEngine;
using System.Collections;

public class ServoMotorConfigurable : MonoBehaviour
{	
	ConfigurableJoint cj;
	// Use this for initialization
	void Start ()
	{
		Quaternion q = Quaternion.Euler(0,0,0);
		cj = GetComponent<ConfigurableJoint>();
		cj.targetRotation = q;
		cj.angularXMotion = ConfigurableJointMotion.Limited;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	public void SetAngle(float angle) {
		Quaternion q = Quaternion.Euler(angle,0,0);
		cj = GetComponent<ConfigurableJoint>();
		cj.targetRotation = q;
	}
	
	public void Setup(float angle) {
		SetAngle(angle);
		cj.lowAngularXLimit = GetLimit(-angle);
		cj.highAngularXLimit = GetLimit(angle);
	}
	
	SoftJointLimit GetLimit(float angle) {
		SoftJointLimit resultLimit = new SoftJointLimit();
		resultLimit.limit = angle;
		return resultLimit;
	}
}

