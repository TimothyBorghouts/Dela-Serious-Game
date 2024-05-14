using UnityEngine;

[System.Serializable]
public class Objective
{
    public int index;
    public string objectiveName;
    public string objectiveDescription;

    [HideInInspector]
    public bool isOpen;
    [HideInInspector]
    public bool isComplete;
}
