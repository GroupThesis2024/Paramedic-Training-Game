using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatientMenuButtonEvents : MonoBehaviour
{
    public void OnOpenExamMenu()
    {
        PatientMenuManager.OpenMenu(PatientMenu.EXAM_MENU, gameObject);
    }

    public void OnOpenProcedureMenu()
    {
        PatientMenuManager.OpenMenu(PatientMenu.PROCEDURES_MENU, gameObject);
    }

    public void OnOpenTriageMenu()
    {
        PatientMenuManager.OpenMenu(PatientMenu.TRIAGE_MENU, gameObject);
    }

    public void OnOpenOpenAirwaysMenu()
    {
        PatientMenuManager.OpenMenu(PatientMenu.OPEN_AIRWAYS_MENU, gameObject);
    }

    public void OnOpenTalkMenu()
    {
        PatientMenuManager.OpenMenu(PatientMenu.TALK_MENU, gameObject);
    } 
    
    public void OnOpenMeasureMenu()
    {
        PatientMenuManager.OpenMenu(PatientMenu.MEASURE_PULSE_AND_BREATHING_MENU, gameObject);
    } 
    
    public void OnOpenCanWalkResponse()
    {
        PatientMenuManager.OpenMenu(PatientMenu.CAN_YOU_WALK_RESPONSE, gameObject);
    } 
    
    public void OnOpenWhereDoesItHurtResponse()
    {
        PatientMenuManager.OpenMenu(PatientMenu.WHERE_DOES_IT_HURT_RESPONSE, gameObject);
    } 
    
    public void OnOpenBreathingResponse()
    {
        PatientMenuManager.OpenMenu(PatientMenu.BREATHING_RESPONSE, gameObject);
    }
    
    public void OnOpenBleedingResponse()
    {
        PatientMenuManager.OpenMenu(PatientMenu.BLEEDING_RESPONSE, gameObject);
    }
    
    public void OnOpenCountBreathingResponse()
    {
        PatientMenuManager.OpenMenu(PatientMenu.COUNT_BREATHING_RESPONSE, gameObject);
    }
    
    public void OnOpenWristPulseResponse()
    {
        PatientMenuManager.OpenMenu(PatientMenu.WRIST_PULSE_RESPONSE, gameObject);
    }

    public void OnOpenNeckPulseResponse()
    {
        PatientMenuManager.OpenMenu(PatientMenu.NECK_PULSE_RESPONSE, gameObject);
    }

    public void OnClickBack_talk()
    {
        PatientMenuManager.OpenMenu(PatientMenu.TALK_MENU, gameObject);
    }

    public void OnClickBack_Exam()
    {
        PatientMenuManager.OpenMenu(PatientMenu.EXAM_MENU, gameObject);
    }

    public void OnClickBack_Procedure()
    {
        PatientMenuManager.OpenMenu(PatientMenu.PROCEDURES_MENU, gameObject);
    }

    public void OnClickBack_MeasurePulseAndBreathing()
    {
        PatientMenuManager.OpenMenu(PatientMenu.MEASURE_PULSE_AND_BREATHING_MENU, gameObject);
    }

}
