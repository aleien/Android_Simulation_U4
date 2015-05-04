using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ServoMotorConfigurableTest : MonoBehaviour {
	public Slider targetAngleSlider;
	public Text targetAngleText;
	//public Text currentAngleText;
	
	public Text currentLocalRotationText;
	public Text currentLocalEulerText;

	// Use this for initialization
	void Start () {
		currentLocalRotationText.text = transform.localRotation.ToString();
		currentLocalEulerText.text = transform.rotation.eulerAngles.ToString();
		targetAngleText.text = targetAngleSlider.value.ToString();
	
	}
	
	// Update is called once per frame
	void Update () {
		currentLocalRotationText.text = transform.localRotation.ToString();
		currentLocalEulerText.text = transform.localEulerAngles.ToString();
		targetAngleText.text = targetAngleSlider.value.ToString();
	}
	
	public void OnSliderChange() {
		GetComponent<ServoMotorConfigurable>().SetAngle(targetAngleSlider.value);
	}
}
