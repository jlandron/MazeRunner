using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomHandler : MonoBehaviour
{
    [Header( "FOV" )]
    [SerializeField] float zoomedInFOV = 50;
    [SerializeField] float zoomedOutFOV = 60;

    private Camera camera;

    void Awake( ) {
        camera = FindObjectOfType<Camera>( );
    }
    void Update( ) {
        if( Input.GetButton( "Zoom" ) ) {
            ZoomIn( );
        }
        else {
            ZoomOut( );
        }

    }

    private void ZoomOut( ) {
        camera.fieldOfView = zoomedOutFOV;
    }

    void ZoomIn( ) {
        camera.fieldOfView = zoomedInFOV;
    }
}
