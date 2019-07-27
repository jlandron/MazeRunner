using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DeathHandler : MonoBehaviour {
    [SerializeField] Canvas gameOverCanvas;
    private FirstPersonController player;
    public void Start( ) {
        gameOverCanvas.enabled = false;
        player = GetComponent<FirstPersonController>( );
        player.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void HandleDeath( ) {
        
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        player.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
