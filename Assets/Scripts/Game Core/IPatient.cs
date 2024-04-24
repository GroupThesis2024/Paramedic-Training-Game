using System.Collections;
using System.Collections.Generic;


public interface IPatient
{
  //ID   
    string GetName(); 


    //Condition 
    string GetCondition(); 
    string SetCondition(); 
    bool GetIsDead(); 
    bool SetIsDead (); 

 
    //Heart Rate 
    float GetPulse(); 
    float SetPulse(); 
    float GetPulseAtWrist(); 

 
    //Breathing Rate 
    float GetBreathingRate(); 
    float SetBreathingRate(); 


    //Bleeding 
    bool getBleeding(); 
    bool SetBleeding(); 


    //Dialogue with NPC 
    string GetConversation(); 
	 string SetConversation(); 


    //Classification 
    byte GetClassification(); 
    byte SetClassification(); 

}
