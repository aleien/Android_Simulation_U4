using System;
using System.Collections.Generic;

public class Movement
{
	public readonly String name = "";
	
	private List<Motion> motionList = new List<Motion>();
	private List<float> overallCompensationalForce = new List<float>();
	
	
	public Movement (String inputName)
	{
		name = inputName;
	}
	
	public void Add(Motion inputMotion) {
		motionList.Add(inputMotion);
	}
	
	
}


