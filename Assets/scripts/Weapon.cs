using System;
using UnityEngine;

public class Weapon : MonoBehaviour {
    [Header("General")]
    [SerializeField] float range = 100;
    [SerializeField] int damage = 20;
    [Header("External Dependencies")]
    [SerializeField] Camera PlayerCamera;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject impactFX;
    

    // Update is called once per frame
    void Update( ) {
        if( Input.GetButtonDown( "Fire1" ) ) {
            Shoot( );
        }
    }

    private void Shoot( ) {
        //TODO add fire effects
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

            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>( );
            if( !target ) {
                return;
            }

            target.takeDamage( damage );
        }
    }
}
