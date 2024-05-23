using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvaluationMenuOpener : MonoBehaviour
{
    public GameObject evaluationMenu;
    public Transform menuSpawnParent;

    public void OpenMenu()
    {
        Instantiate(evaluationMenu, menuSpawnParent);
    }
}
