using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    private static ObjectiveManager instance;

    public TextMeshProUGUI objectiveText;
    public TextMeshProUGUI objectiveList;

    public Objective[] objectives;
    private Objective[] openObjectives;

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
        }
        AddToObjectiveList(objectives[0]);
        openObjectives = new Objective[3];
    }

    public void CompleteObjective(string name)
    {
        Objective objective = FindObjective(name);

        if (!objective.isComplete)
        {
            objective.isComplete = true;
        }
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

    public void AddToObjectiveList(Objective objective)
    {
        if (objective != null)
        {
            openObjectives.Append(objective);
        }
    }

    public void RemoveFromObjectiveList(Objective objective)
    {
        if (objective != null)
        {


        }
    }
}
