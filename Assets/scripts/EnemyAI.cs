using UnityEngine;
using UnityEngine.AI;



public class EnemyAI : MonoBehaviour {

    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float tetherRange = 10f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;


    // Start is called before the first frame update
    void Start( ) {
        navMeshAgent = GetComponent<NavMeshAgent>( );
    }

    // Update is called once per frame
    void Update( ) {
        EngageTarget( );
    }

    private void EngageTarget( ) {
        distanceToTarget = Vector3.Distance( target.position, transform.position );
        if( distanceToTarget <= chaseRange ) {
            if( distanceToTarget > navMeshAgent.stoppingDistance ) {
                navMeshAgent.SetDestination( target.position );
                isProvoked = true;
            }
            else if( distanceToTarget <= navMeshAgent.stoppingDistance ) {
                AttackTarget( );
            }
        }
        else if( isProvoked && distanceToTarget <= tetherRange ) {
            navMeshAgent.SetDestination( target.position );
        }
        else {
            isProvoked = false;
        }
    }

    private void AttackTarget( ) {
        Debug.Log( "blarghaghagh!!!!" );
    }
}
