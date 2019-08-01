using System.Collections;
using UnityEngine;

public class BarrierMover : MonoBehaviour {
    private bool isBlocking = false;
    private bool isMoveingUp = false;
    private bool isMoveingDown = false;
    private float originalYpos;
    private AudioSource audioSource;
    [SerializeField] AudioClip grindSFX;
    [SerializeField] AudioClip bangSFX;
    [SerializeField] float verticalMoveAmount = 10f;
    [Range( 1, 20 )] [SerializeField] float moveSpeed = 2f;

    void Start( ) {
        originalYpos = gameObject.transform.position.y;
        audioSource = GetComponent<AudioSource>( );
        StartCoroutine( RandomWait( ) );
    }
    void Update( ) {
        MoveBlock( );
    }

    private void MoveBlock( ) {
        if( isMoveingUp ) {
            if( gameObject.transform.position.y >= originalYpos  ) {
                audioSource.Stop( );
                audioSource.PlayOneShot( bangSFX );
                isMoveingUp = false;
                isBlocking = false;
            }
            Move( 1 );
        }
        else if( isMoveingDown ) {
            if( gameObject.transform.position.y <= originalYpos - verticalMoveAmount ) {
                audioSource.Stop( );
                audioSource.PlayOneShot( bangSFX );
                isMoveingDown = false;
                isBlocking = true;
            }
            Move( -1 );
        }
    }

    private void Move( int direction ) {
        Vector3 currentPosition = gameObject.transform.position;
        float offset = Time.deltaTime * moveSpeed;
        Vector3 nextPosition = new Vector3( gameObject.transform.position.x,
                                            gameObject.transform.position.y + (offset * direction),
                                            gameObject.transform.position.z );
        gameObject.transform.position = nextPosition;
    }

    IEnumerator RandomWait( ) {
        while( true ) {
            if( !isMoveingDown || !isMoveingUp ) {
                if( isBlocking ) {
                    isMoveingUp = true;
                }
                else {
                    isMoveingDown = true;
                }
                audioSource.PlayOneShot( grindSFX );
            }
            yield return new WaitForSeconds( UnityEngine.Random.Range( 10, 40 ) );
        }
    }
}
