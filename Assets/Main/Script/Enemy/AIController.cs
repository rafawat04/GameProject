using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIController : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;               //  Nav mesh agent component
    public float startWaitTime = 0.5f;                 //  Wait time of every action
    public float timeToRotate = 2;                  //  Wait time when the enemy detect near the player without seeing
    public float speedWalk = 6;                     //  Walking speed, speed in the nav mesh agent
    public float speedRun = 9;                      //  Running speed
    public float viewRadius = 15;
    public float fieldOfView = 180;             //  Radius of the enemy view
    public float viewAngle = 90;                    //  Angle of the enemy view
    public LayerMask playerMask;                    //  To detect the player with the raycast
    public LayerMask obstacleMask;                  //  To detect the obstacles with the raycast
    public float meshResolution = 1.0f;             //  How many rays will cast per degree
    public int edgeIterations = 4;                  //  Number of iterations to get a better performance of the mesh filter when the raycast hit an obstacule
    public float edgeDistance = 0.5f;
    public float rotationSpeed =  30f;            //  Max distance to calcule the a minimun and a maximum raycast when hits something
    public EnemyShooting enemyShooting;
    public Transform[] waypoints;                   //  All the waypoints where the enemy patrols
    int m_CurrentWaypointIndex;
    // private bool isHit = false;
    private Vector3 hitDirection;                  //  Current waypoint where the enemy is going to
    Vector3 playerLastPosition = Vector3.zero;      //  Last position of the player when was near the enemy
    Vector3 m_PlayerPosition;                       //  Last position of the player when the player is seen by the enemy
    float m_WaitTime;                               //  Variable of the wait time that makes the delay
    float m_TimeToRotate;                           //  Variable of the wait time to rotate when the player is near that makes the delay
    bool m_playerInRange;                           //  If the player is in range of vision, state of chasing
    bool m_PlayerNear;                              //  If the player is near, state of hearing
    bool m_IsPatrol;                                //  If the enemy is patrol, state of patroling
    bool m_CaughtPlayer;
    bool chasing = false;           //  if the enemy has caught the player
 
    void Start()
    {
      
        m_PlayerPosition = Vector3.zero;
        m_IsPatrol = true;
        m_CaughtPlayer = false;
        m_playerInRange = false;
        m_PlayerNear = false;
        m_WaitTime = startWaitTime;                 //  Set the wait time variable that will change
        m_TimeToRotate = timeToRotate;
        m_CurrentWaypointIndex = 0;                 //  Set the initial waypoint
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.isStopped = false;
        navMeshAgent.speed = speedWalk;             //  Set the navmesh speed with the normal speed of the enemy
           //  Set the destination to the first waypoint
        // Shuffle the array of waypoints
        Shuffle(waypoints);
    }
    private void Update()
    {
        EnviromentView();
        
        if (!m_IsPatrol)
        {
        Chasing();
        chasing = true;
        if (chasing )
            {
                int n = Random.Range(0, 100);
                if (n > 80)
                {
                    enemyShooting.Shoot(EnemyShooting.TargetLocation.PlayerHead);
                }
                else
                {
                    enemyShooting.Shoot(EnemyShooting.TargetLocation.PlayerBody);
                } 
            }
        }
        else
            {
                Patroling();
         
            }
    }
    private void Chasing()
    {
        m_PlayerNear = false;
        playerLastPosition = Vector3.zero;
        // Get a vector from the enemy to the player
        Vector3 toPlayer = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
        // Check if the player is in front of the enemy
        if (Vector3.Dot(transform.forward, toPlayer.normalized) > 0.5f)
        {
            // Get the angle between the enemy's forward direction and the vector to the player
            float angle = Vector3.Angle(transform.forward, toPlayer.normalized);
            // Check if the angle is less than or equal to the enemy's field of view
            if (angle <= fieldOfView)
            {
                int n = Random.Range(0, 100);
                if (n > 95)
                {
                    enemyShooting.Shoot(EnemyShooting.TargetLocation.PlayerHead);
                }
                else
                {
                    enemyShooting.Shoot(EnemyShooting.TargetLocation.PlayerBody);
                }
            }
        }
        if (!m_CaughtPlayer)
        {
            Move(speedRun);
            // Estimate the future position of the player based on their current velocity
            Vector3 futurePlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position +
                                            GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>().velocity * 0.5f;
            // Set the destination of the enemy to the future player position
            navMeshAgent.SetDestination(futurePlayerPosition);
        }
        else
        {
            m_PlayerNear = false;
            Move(speedWalk);
        }
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            if (m_WaitTime <= 0 && !m_CaughtPlayer && Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= 0.5f)
            {
                m_IsPatrol = true;
                m_PlayerNear = false;
                Move(speedWalk);
                m_TimeToRotate = timeToRotate;
                m_WaitTime = startWaitTime;
                navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
            }
            else
            {
                if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= 2.5f)
                    Stop();
                m_WaitTime -= Time.deltaTime;
            }
        }
    }
    // Shuffle an array using Fisher-Yates algorithm
    public static void Shuffle<T>(T[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            T temp = array[j];
            array[j] = array[i];
            array[i] = temp;
        }
    }
    private void Patroling()
    {
    if (m_PlayerNear)
    {
        // Check if the enemy detects the player nearby
        if (m_TimeToRotate <= 0)
        {
            Move(speedWalk);
            LookingPlayer(playerLastPosition);
        }
        else
        {
            Stop();
            m_TimeToRotate -= Time.deltaTime;
        }
    }
    else
    {
        // If the enemy is patrolling, set the destination to the next random waypoint
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            m_IsPatrol = true;
            Move(speedWalk);
            m_TimeToRotate = timeToRotate;
            m_WaitTime = startWaitTime;
            // Set the destination to the next waypoint in the shuffled array
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }
    // Set the NavMeshAgent's avoidance priority to avoid obstacles more aggressively
    navMeshAgent.avoidancePriority = 70;
    }
    public void NextPoint()
    {
         m_CurrentWaypointIndex = (m_CurrentWaypointIndex +1) % waypoints.Length;
        navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
    }
    void Stop()
    {
        navMeshAgent.isStopped = true;
        navMeshAgent.speed = 0;
    }
    void Move(float speed)
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.speed = speed;
    }
    void CaughtPlayer()
    {
        m_CaughtPlayer = true;
    }
    void LookingPlayer(Vector3 player)
    {
        navMeshAgent.SetDestination(player);
        if (Vector3.Distance(transform.position, player) <= 0.3)
        {
            if (m_WaitTime <= 0)
            {
                m_PlayerNear = false;
                Move(speedWalk);
                navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
                m_WaitTime = startWaitTime;
                m_TimeToRotate = timeToRotate;
            }
            else
            {
                Stop();
                m_WaitTime -= Time.deltaTime;
            }
        }
    }
    void EnviromentView()
    {
        Collider[] playerInRange = Physics.OverlapSphere(transform.position, viewRadius, playerMask);   //  Make an overlap sphere around the enemy to detect the playermask in the view radius
        for (int i = 0; i < playerInRange.Length; i++)
        {
            Transform player = playerInRange[i].transform;
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToPlayer) < viewAngle / 2)
            {
                float dstToPlayer = Vector3.Distance(transform.position, player.position);          //  Distance of the enmy and the player
                if (!Physics.Raycast(transform.position, dirToPlayer, dstToPlayer, obstacleMask))
                {
                    m_playerInRange = true;             //  The player has been seeing by the enemy and then the nemy starts to chasing the player
                    m_IsPatrol = false;                 //  Change the state to chasing the player
                }
                else
                {
                    /*
                     *  If the player is behind a obstacle the player position will not be registered
                     * */
                    m_playerInRange = false;
                }
            }
            if (Vector3.Distance(transform.position, player.position) > viewRadius)
            {
                /*
                 *  If the player is further than the view radius, then the enemy will no longer keep the player's current position.
                 *  Or the enemy is a safe zone, the enemy will no chase
                 * */
                m_playerInRange = false;                //  Change the sate of chasing
            }
            if (m_playerInRange)
            {
                /*
                 *  If the enemy no longer sees the player, then the enemy will go to the last position that has been registered
                 * */
                m_PlayerPosition = player.transform.position;       //  Save the player's current position if the player is in range of vision
            }
        }
    }
}