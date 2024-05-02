using System.Collections;
using System.Collections.Generic;


public interface IPatient
{
	string GetName();
	byte GetClassification();
	void SetClassification(byte classification);
	int GetPulse();
	int GetPulseAtWrist();
	int GetBreathingRate();
}