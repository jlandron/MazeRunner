using UnityEngine;
using UnityEngine.AI;



public class EnemyAI : MonoBehaviour {

    PlayerHealth target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float tetherRange = 10f;
    [SerializeField] int hitPoints = 100;
    [SerializeField] int damage = 40;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    bool isDead = false;


    // Start is called before the first frame update
    void Start( ) {
        navMeshAgent = GetComponent<NavMeshAgent>( );
        target = FindObjectOfType<PlayerHealth>( );
    }

    // Update is called once per frame
    void Update( ) {
        EngageTarget( );
    }
    public void takeDamage( int damage ) {
        hitPoints -= damage;
        if( hitPoints <= 0 ) {
            Die( );
        }

    }
    public void AttackHitEvent( ) {
        if( target == null ) {
            return;
        }
        Debug.Log("bang!");
        target.TakeDamage( damage );
    }
    private void EngageTarget( ) {
        if( isDead ) {
            return;
        }
        distanceToTarget = Vector3.Distance( target.transform.position, transform.position );
        if( distanceToTarget <= chaseRange ) {
            if( distanceToTarget > navMeshAgent.stoppingDistance ) {
                Chase( );
            }
            else if( distanceToTarget <= navMeshAgent.stoppingDistance ) {
                AttackTarget( );
            }
        }
        else if( isProvoked && distanceToTarget <= tetherRange ) {
            Chase( );
        }
        else {
            isProvoked = false;
        }
    }

    private void Chase( ) {
        GetComponent<Animator>( ).SetBool( "Attack", false );
        GetComponent<Animator>( ).SetTrigger( "Move" );
        navMeshAgent.SetDestination( target.transform.position );
        isProvoked = true;
    }

    private void AttackTarget( ) {
        GetComponent<Animator>( ).SetBool( "Attack", true );
    }

    private void Die( ) {
        GetComponent<Animator>( ).SetBool( "isDead", true );
        isDead = true;
        //Destroy( gameObject );
    }
}
