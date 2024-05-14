using System.Text;
using TMPro;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    private static ObjectiveManager instance;

    public TextMeshProUGUI objectiveText;
    public TextMeshProUGUI objectiveList;

    public Objective[] objectives;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        foreach (Objective objective in objectives)
        {
            objective.isComplete = false;
            objective.isOpen = false;
        }

        AddToObjectiveList("Phone");
    }

    public Objective FindObjective(string name)
    {
        Objective objective = null;

        foreach (Objective obj in objectives)
        {
            if (obj.objectiveName == name)
            {
                objective = obj;
            }
        }
        return objective;
    }

    public void AddToObjectiveList(string name)
    {
        Objective openObjective = FindObjective(name);
        openObjective.isOpen = true;
        UpdateObjectiveList();

    }

    public void RemoveFromObjectiveList(Objective objective)
    {
        Objective closedObjective = FindObjective(objective.objectiveName);
        closedObjective.isComplete = true;
        UpdateObjectiveList();
    }

    public void UpdateObjectiveList()
    {
        StringBuilder sb = new StringBuilder();
        foreach (Objective obj in objectives)
        {
            if (obj.isOpen && !obj.isComplete)
            {
                sb.Append("- " + obj.objectiveDescription + "\n");
            }
        }
        objectiveList.text = sb.ToString();
    }
}
