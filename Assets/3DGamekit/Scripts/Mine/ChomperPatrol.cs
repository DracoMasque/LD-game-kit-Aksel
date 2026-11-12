using Gamekit3D;
using UnityEngine;

public class ChomperPatrol : MonoBehaviour
{
    public static readonly int inPatrol = Animator.StringToHash("Patrol");
    
    [SerializeField] private Transform[] patrolPoints;
    private int m_PatrolPointIndex = 0;
    private bool reverse = false;
    
    protected EnemyController m_Controller;
    protected ChomperBehavior m_Behavior;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Controller = GetComponentInChildren<EnemyController>();
        m_Behavior = GetComponent<ChomperBehavior>();
        patrolPoints[0] = gameObject.transform;
    }

    void Update()
    {
        if (m_Behavior.GetM_target() is null)
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
                    m_Controller.SetTarget(patrolPoints[m_PatrolPointIndex].position);
                    m_Controller.animator.SetBool(inPatrol, true);
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
                    m_Controller.SetTarget(patrolPoints[m_PatrolPointIndex].position);
                    m_Controller.animator.SetBool(inPatrol, true);
                    //m_Controller.SetFollowNavmeshAgent(true);
                }
            }
            else if (m_PatrolPointIndex == 0 && gameObject.transform.position == patrolPoints[m_PatrolPointIndex].position)
            {
                m_PatrolPointIndex++;
                m_Controller.SetTarget(patrolPoints[m_PatrolPointIndex].position);
                m_Controller.animator.SetBool(inPatrol, true);
                //m_Controller.SetFollowNavmeshAgent(true);
            }
        }
        else
        {
            m_PatrolPointIndex = 0;
            m_Controller.animator.SetBool(inPatrol, false);
            reverse = false;
        }
    }
}
