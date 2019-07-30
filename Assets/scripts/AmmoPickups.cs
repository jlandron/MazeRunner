using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickups : MonoBehaviour
{
    private void OnTriggerEnter( Collider other ) {
        if( other.gameObject.tag == "Player" ) {
            print( "Player picked me up!" );
            Destroy( gameObject );
        }
    }
}
