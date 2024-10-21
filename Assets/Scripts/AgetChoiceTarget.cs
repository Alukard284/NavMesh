using UnityEngine;


public class AgetChoiceTarget : MonoBehaviour
{
    [SerializeField] private string targetName = "Target";
    private GameObject[] allTargets;
    private GameObject target;
    private int index;

    private void Start()
    {
        FindAllTargets();
    }
    public GameObject NavigationToTarget()
    {
        target = allTargets[Random.Range(0, index)];
        return target;
    }

    public void FindAllTargets()
    {
        allTargets = GameObject.FindGameObjectsWithTag(targetName);
        index = allTargets.Length;
    }
}
