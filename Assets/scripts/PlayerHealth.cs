using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] int playerhealth = 100;

    public void TakeDamage(int damage) {
        playerhealth -= damage;
        print( "Player was Hit!!!!" );
        if( playerhealth <= 0 ) {
            print( "Player is dead!!!" );
        }
    }


}
