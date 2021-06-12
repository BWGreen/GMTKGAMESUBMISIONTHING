using System.Collections;
using System.Collections.Generic;
// using Assets.NPCScript;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NPCStateController : MonoBehaviour
{
    public NPCStats nPCStats;
    public NPCStates_SO remainState;

    [SerializeField] private Transform chaseTarget;
    [SerializeField] private float stateTimeElapsed = 0;
    [SerializeField] private NPCStates_SO currentState;
    [SerializeField] private List<Transform> wayPoints;
    [SerializeField] private Transform seatTransform;
    [SerializeField] private int wayPointIndex;


    private NavMeshAgent navMeshAgent;


    //PROPERTIES

    public Transform SeatTransform
    {
        get{ return seatTransform;}
    }
    
    private bool inChurch;
    public bool InChurch
    {
        get { return inChurch; }
        set { inChurch = value; }
    }
    
    public bool IsplayerIn { get; set; }

    public Transform ChaseTarget
    {
        get { return chaseTarget; }

        set { chaseTarget = value; }
    }
    public int WayPointIndex
    {
        get { return wayPointIndex; }

        set { wayPointIndex = value; }
    }
    public List<Transform> WayPoints
    {
        get { return wayPoints; }
    }
    public NavMeshAgent NavMeshAgent
    {
        get
        {
            return navMeshAgent;
        }
    }

    private void Awake()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    //This is getting passing the argument rather than the values won't set in the scriptable object
    void Update()
    {
        currentState.UpdateState(this);
    }

    private void OnDrawGizmos()
    {
    }

    public void TransistionToState(NPCStates_SO nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
            OnExitState();
        }
    }

    public bool checkCountDownElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
        return (stateTimeElapsed >= duration);
    }

    private void OnExitState()
    {
        stateTimeElapsed = 0;
    }


}
