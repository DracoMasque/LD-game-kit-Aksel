using UnityEngine;
using UnityEngine.AI;

public class Test : MonoBehaviour
{
    public NavMeshAgent m_NavMeshAgent;
    [SerializeField] private Transform[] patrolPoints;
    private int m_PatrolPointIndex = 0;
    private bool reverse = false;
    
    void Start()
    {
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
        patrolPoints[0] = gameObject.transform;
    }

    void Update()
    {
        if (m_PatrolPointIndex != 0 && gameObject.transform.position == patrolPoints[m_PatrolPointIndex].position
                                    && !reverse)
        {
            m_PatrolPointIndex++;
            if (m_PatrolPointIndex == patrolPoints.Length-1)
            {
                reverse = true;
            }
            else
            {
                m_NavMeshAgent.SetDestination(patrolPoints[m_PatrolPointIndex].position);
                //m_Controller.SetFollowNavmeshAgent(true);
            }
        }
        else if (m_PatrolPointIndex != 0 && gameObject.transform.position ==
                                         patrolPoints[m_PatrolPointIndex].position
                                         && reverse)
        {
            m_PatrolPointIndex--;
            if (m_PatrolPointIndex == patrolPoints.Length-1)
            {
                reverse = true;
            }
            else
            {
                m_NavMeshAgent.SetDestination(patrolPoints[m_PatrolPointIndex].position);
                //m_Controller.SetFollowNavmeshAgent(true);
            }
        }
        else if (m_PatrolPointIndex == 0 && gameObject.transform.position == patrolPoints[m_PatrolPointIndex].position)
        {
            m_PatrolPointIndex++;
            m_NavMeshAgent.SetDestination(patrolPoints[m_PatrolPointIndex].position);
            //m_Controller.SetFollowNavmeshAgent(true);
        }
    }
}
