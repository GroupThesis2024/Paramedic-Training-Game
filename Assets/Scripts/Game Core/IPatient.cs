using System.Collections;
using System.Collections.Generic;


public interface IPatient
{
	string GetName();
	byte GetClassification();
	byte SetClassification();
	float GetPulse();
	float GetPulseAtWrist();
	float GetBreathingRate();
}