using UnityEngine;

public class Ammo : MonoBehaviour {
    [SerializeField] int ammoCount = 10;

    public void increaseAmmoCount( int amount ) {
        ammoCount += amount;
    }
    public void decreaseAmmoCount( ) {
        ammoCount--;
    }
    public int GetAmmoCount( ) {
        return ammoCount;
    }
}
