using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
 [SerializeField] int hitPoints = 100;

    public void takeDamage( int damage ) {
        hitPoints -= damage;
        if( hitPoints <= 0 ) {
            Die( );
        }

    }

    private void Die( ) {
        Destroy( gameObject );
    }
}
