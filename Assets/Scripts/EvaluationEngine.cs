using System.Collections.Generic;
using System.Linq;
using Backend;
using TMPro;
using UnityEngine;

public class EvaluationEngine : MonoBehaviour
{
    public TextMeshPro classificationPercentage;
    public TextMeshPro classificationBlackUiElement;
    public TextMeshPro classificationRedUiElement;
    public TextMeshPro classificationYellowUiElement;
    public TextMeshPro classificationGreenUiElement;

    private int[] trueClassificationCounts;
    private int[] correctPlayerClassificationCounts;
    private int[] incorrectPlayerClassificationCounts;
    private float classificationPercentageCorrect;


    void Start()
    {
        // FetchPatientData();
        InitializeClassificationCounts();
        // ProcessPatientData(patients);
        CalculateOverallPercentage();
        UpdateEvaluationView();
    }

    void Update()
    {
        // TO-DO: Figure out if needed to keep
    }

    private void FetchPatientData()
    {
        // TO-DO: Add Functionality to Fetch patient with backend access interface
    }

    private void InitializeClassificationCounts()
    {
        int typesOfDifferentClassifications = 4;
        trueClassificationCounts = new int[typesOfDifferentClassifications];
        correctPlayerClassificationCounts = new int[typesOfDifferentClassifications];
        incorrectPlayerClassificationCounts = new int[typesOfDifferentClassifications];
    }

    private void ProcessPatientData(List<PatientInformation> patients)
    {
        foreach (PatientInformation patient in patients)
        {
            IncrementTrueClassificationCount(patient.trueClassification);
            IncrementPlayerClassificationCount(patient.playerGivenClassification, patient.trueClassification);
        }
    }

    private void IncrementTrueClassificationCount(int classification)
    {
        trueClassificationCounts[classification]++;
    }

    private void IncrementPlayerClassificationCount(int playerClassification, int trueClassification)
    {
        if (playerClassification == trueClassification)
        {
            correctPlayerClassificationCounts[playerClassification]++;
        }
        else
        {
            incorrectPlayerClassificationCounts[playerClassification]++;
        }
    }

    private void CalculateOverallPercentage()
    {
        int overallCorrectCount = correctPlayerClassificationCounts.Sum();
        int overallTotalCount = trueClassificationCounts.Sum();
        CalculatePercentage(overallCorrectCount, overallTotalCount);
    }

    private void CalculatePercentage(int correctCount, int totalCount)
    {
        bool totalCountIsZero = totalCount == 0;
        if (totalCountIsZero)
        {
            classificationPercentageCorrect = 0f; // Avoid division by zero
        }
        else
        {
            float percentage = (float)correctCount / totalCount * 100;
            classificationPercentageCorrect = percentage;
        }
    }

    private void UpdateEvaluationView()
    {
        // 0 = Black, 1 = Red, 2 = Yellow, 3 = Green
        classificationPercentage.SetText($"Classification report | {classificationPercentageCorrect:F0}%");
        classificationBlackUiElement.SetText($"Black: {correctPlayerClassificationCounts[0]}/{trueClassificationCounts[0]}");
        classificationRedUiElement.SetText($"Red: {correctPlayerClassificationCounts[1]}/{trueClassificationCounts[1]}");
        classificationYellowUiElement.SetText($"Yellow: {correctPlayerClassificationCounts[2]}/{trueClassificationCounts[2]}");
        classificationGreenUiElement.SetText($"Green: {correctPlayerClassificationCounts[3]}/{trueClassificationCounts[3]}");
    }
}