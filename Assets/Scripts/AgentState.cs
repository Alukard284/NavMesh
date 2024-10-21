using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AgentState : MonoBehaviour
{
    private AgetChoiceTarget agetChoiceTarget;
    private NavMeshAgent agent;
    public bool active = true;
    [SerializeField] private int timeDelay;
    [SerializeField] private Animator animator;
    [SerializeField] private string areaName;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agetChoiceTarget = GetComponent<AgetChoiceTarget>();
        StartCoroutine(DelayExecute());
    }

    private void Update()
    {

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            if (!active)
            {
                StartCoroutine(DelayExecute());
                active = true;
            } 
        }
        if (agent.velocity.magnitude > 0.5f)
        {
            animator.SetFloat("Locomotion", agent.velocity.magnitude);
        }
        else { animator.SetFloat("Locomotion", 0);}
    }

    private IEnumerator DelayExecute()
    {
        float delayTime = Random.Range(1, timeDelay);
        yield return new WaitForSeconds(delayTime);
        agent.destination = agetChoiceTarget.NavigationToTarget().transform.position;
        active = false;
        yield return new WaitForSeconds(delayTime);    
    }
}
