using System;
using System.Collections.Generic;

public class Motion
{
	public readonly String name = "";
	public readonly Dictionary<String, int> servoAngles = new Dictionary<String, int>();
	
	readonly List<float> compensationalForce = new List<float>(3);
	
	public Motion (String inputName, List<int> inputServoAngles, List<float> inputCompensationalForce)
	{
		name = inputName;
		for (int i = 0; i < inputServoAngles.Count; i++) {
			servoAngles.Add(i.ToString("00"), inputServoAngles[i]);
		}
		for (int i = 0; i < 3; i++) {
			compensationalForce.Add(inputCompensationalForce[i]);
		}
	}
	
	public Motion (String inputName, Dictionary<String,int> inputServoAngles, List<float> inputCompensationalForce)
	{
		name = inputName;
		servoAngles = inputServoAngles;
		for (int i = 0; i < 3; i++) {
			compensationalForce.Add(inputCompensationalForce[i]);
		}
	}
	
}


