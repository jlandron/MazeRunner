using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour {
    [Header("General")]
    [SerializeField] float range = 100;
    [SerializeField] int damage = 20;
    [Header("External Dependencies")]
    [SerializeField] Camera PlayerCamera;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject impactFX;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] Text ammoText;

    // Update is called once per frame
    void Update( ) {
        if( Input.GetButtonDown( "Fire1" ) ) {
            if( ammoSlot.GetAmmoCount( ) > 0 ) {
                Shoot( );
                ammoSlot.decreaseAmmoCount( );
            }
        }
        ammoText.text = ("Ammo: " + ammoSlot.GetAmmoCount());
    }

    private void Shoot( ) {
        //TODO add sound effects
        MuzzleFlash( );
        ProcessRaycasting( );
    }

    private void MuzzleFlash( ) {
        muzzleFlash.Play( );
    }

    private void ProcessRaycasting( ) {
        RaycastHit hit;
        if( Physics.Raycast( PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, range ) ) {
            Debug.Log( hit.transform.name );

            Instantiate( impactFX, hit.point , Quaternion.identity );

            EnemyAI target = hit.transform.GetComponent<EnemyAI>( );
            if( !target ) {
                return;
            }

            target.takeDamage( damage );
        }
    }
}
