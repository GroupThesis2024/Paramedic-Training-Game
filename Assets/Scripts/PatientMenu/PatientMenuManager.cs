using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public static class PatientMenuManager
{
    public static bool isInitialised {  get; private set; }

    public static GameObject startMenu, examMenu, procMenu, triageMenu, openAirwaysMenu,
        talkMenu, measureMenu, canWalkResponse, whereDoesItHurtResponse, breathingResponse,
        bleedingResponse, countBreathingResponse, wristPulseResponse, neckPulseResponse;
    private static List<GameObject> optionMenus = new List<GameObject>();

    private static List<GameObject> listWithoutExamMenu = new List<GameObject>();
    private static List<GameObject> listWithoutProcMenu = new List<GameObject>();
    private static List<GameObject> listWithoutTriageMenu = new List<GameObject>();    
    public static void Init()
    {
        GameObject canvas = GameObject.Find("InteractWithPatientMenu");
        startMenu = canvas.transform.Find("StartMenu").gameObject;

        examMenu = canvas.transform.Find("OptionMenuContainer").transform.Find("ExamMenu").gameObject;
        optionMenus.Add(examMenu);

        procMenu = canvas.transform.Find("OptionMenuContainer").transform.Find("ProceduresMenu").gameObject;
        optionMenus.Add(procMenu);

        triageMenu = canvas.transform.Find("OptionMenuContainer").transform.Find("TriageMenu").gameObject;
        optionMenus.Add(triageMenu);

        openAirwaysMenu = canvas.transform.Find("OptionMenuContainer").transform.Find("OpenAirwaysMenu").gameObject;
        optionMenus.Add(openAirwaysMenu);

        talkMenu = canvas.transform.Find("OptionMenuContainer").transform.Find("TalkMenu").gameObject;
        optionMenus.Add(talkMenu);

        measureMenu = canvas.transform.Find("OptionMenuContainer").transform.Find("MeasurePulseBreathingMenu").gameObject;
        optionMenus.Add(measureMenu);

        canWalkResponse = canvas.transform.Find("OptionMenuContainer").transform.Find("CanYouWalkResponse").gameObject;
        optionMenus.Add(canWalkResponse);

        whereDoesItHurtResponse = canvas.transform.Find("OptionMenuContainer").transform.Find("WhereDoesItHurtResponse").gameObject;
        optionMenus.Add(whereDoesItHurtResponse);

        breathingResponse = canvas.transform.Find("OptionMenuContainer").transform.Find("BreathingResponse").gameObject;
        optionMenus.Add(breathingResponse);

        bleedingResponse = canvas.transform.Find("OptionMenuContainer").transform.Find("BleedingResponse").gameObject;
        optionMenus.Add(bleedingResponse);

        countBreathingResponse = canvas.transform.Find("OptionMenuContainer").transform.Find("CountBreathingResponse").gameObject;
        optionMenus.Add(countBreathingResponse);

        wristPulseResponse = canvas.transform.Find("OptionMenuContainer").transform.Find("WristPulseResponse").gameObject;
        optionMenus.Add(wristPulseResponse);

        neckPulseResponse = canvas.transform.Find("OptionMenuContainer").transform.Find("NeckPulseResponse").gameObject;
        optionMenus.Add(neckPulseResponse);

        listWithoutExamMenu = new List<GameObject>(optionMenus);
        listWithoutExamMenu.Remove(examMenu);

        listWithoutProcMenu = new List<GameObject>(optionMenus);
        listWithoutProcMenu.Remove(procMenu);

        listWithoutTriageMenu = new List<GameObject>(optionMenus);
        listWithoutTriageMenu.Remove(triageMenu);

        isInitialised = true;
    }

    public static void OpenMenu(PatientMenu menu, GameObject callingMenu)
    {
        if(!isInitialised)
            Init(); 

        switch (menu)
        {
            case PatientMenu.EXAM_MENU:
                examMenu.SetActive(true);
                foreach (GameObject m in listWithoutExamMenu)
                {
                    m.SetActive(false);
                }
                break;
            case PatientMenu.PROCEDURES_MENU:
                procMenu.SetActive(true);
                foreach (GameObject m in listWithoutProcMenu)
                {
                    m.SetActive(false);
                }
                break;
            case PatientMenu.TRIAGE_MENU:
                triageMenu.SetActive(true);
                foreach (GameObject m in listWithoutTriageMenu)
                {
                    m.SetActive(false);
                }
                break;
            case PatientMenu.OPEN_AIRWAYS_MENU:
                openAirwaysMenu.SetActive(true);
                break;
            case PatientMenu.TALK_MENU:
                talkMenu.SetActive(true);
                break;
            case PatientMenu.MEASURE_PULSE_AND_BREATHING_MENU:
                measureMenu.SetActive(true);
                break;
            case PatientMenu.CAN_YOU_WALK_RESPONSE:
                canWalkResponse.SetActive(true);
                break;
            case PatientMenu.WHERE_DOES_IT_HURT_RESPONSE:
                whereDoesItHurtResponse.SetActive(true);
                break;
            case PatientMenu.BREATHING_RESPONSE:
                breathingResponse.SetActive(true);
                break;
            case PatientMenu.BLEEDING_RESPONSE:
                bleedingResponse.SetActive(true);
                break;
            case PatientMenu.COUNT_BREATHING_RESPONSE:
                countBreathingResponse.SetActive(true);
                break;
            case PatientMenu.WRIST_PULSE_RESPONSE:
                wristPulseResponse.SetActive(true);
                break;
            case PatientMenu.NECK_PULSE_RESPONSE:
                neckPulseResponse.SetActive(true);
                break;
        }

        if(callingMenu != startMenu)
            callingMenu.SetActive(false);
    }
}
