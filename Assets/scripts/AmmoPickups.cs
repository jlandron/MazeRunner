using UnityEngine;

public class AmmoPickups : MonoBehaviour {
    [SerializeField] int ammoAmount = 6;

    private void OnTriggerEnter( Collider other ) {
        if( other.gameObject.tag == "Player" ) {
            FindObjectOfType<Ammo>( ).increaseAmmoCount( ammoAmount );
            Destroy( gameObject );
        }
    }
}
