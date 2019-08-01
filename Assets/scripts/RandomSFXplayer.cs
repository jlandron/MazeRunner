using System.Collections;
using UnityEngine;

public class RandomSFXplayer : MonoBehaviour {
    AudioSource audioSource;
    [SerializeField] AudioClip[] audioClips;
    void Start( ) {
        audioSource = GetComponent<AudioSource>( );
        StartCoroutine( RandomPlayAfterWait( ) );
    }

    IEnumerator RandomPlayAfterWait( ) {
        while( true ) {
            int randomSFX = UnityEngine.Random.Range( 0, audioClips.Length );
            audioSource.PlayOneShot( audioClips[randomSFX] );
            yield return new WaitForSeconds( UnityEngine.Random.Range( 10, 20 ) );
        }
    }
}
