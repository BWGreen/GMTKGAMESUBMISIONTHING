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

    [SerializeField] private GameObject patienceHolder = null;
    [SerializeField] private SpriteRenderer timer = null;
    [SerializeField] private CharecterSeatUI seatUI = null;


    private NavMeshAgent navMeshAgent;
    private Animator anim;


    //PROPERTIES
    private bool memberCollide;
    public bool MemberCollided
    {
        get { return memberCollide; }
        set { memberCollide = value; }
    }
    
    public bool UseItem { get; set; }

    public Transform SeatTransform
    {
        get { return seatTransform; }
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
        anim = this.GetComponent<Animator>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    //This is getting passing the argument rather than the values won't set in the scriptable object
    void Update()
    {
        // Debug.Log(navMeshAgent.velocity);
        currentState.UpdateState(this);
    }

    private void LateUpdate()
    {
        anim.SetFloat("X",navMeshAgent.velocity.x);
        anim.SetFloat("Y",navMeshAgent.velocity.y);
        anim.SetFloat("Speed",Mathf.Abs(navMeshAgent.velocity.magnitude));
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
        if(inChurch)
        {
            patienceHolder.SetActive(true);
            timer.transform.localScale = new Vector3(stateTimeElapsed/duration,1f,1f);
            seatUI.ToggleUI(false);
        }
        return (stateTimeElapsed >= duration);
    }

    public void AddFollower(GameObject controller)
    {
        
    }

    private void OnExitState()
    {
        stateTimeElapsed = 0;
        patienceHolder.SetActive(false);
        timer.transform.localScale = new Vector3(0f,1f,1f);
        seatUI.ToggleUI(true);
    }


}
