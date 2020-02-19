using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    private VirtualCameraController cameraController;

    [SerializeField] private GameObject cameraToTransition;
    [SerializeField] private GameObject cameraPlayer;

    // Start is called before the first frame update
    void Start()
    {
        cameraController = FindObjectOfType<VirtualCameraController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            VirtualCameraController._instance.TransitionTo(cameraToTransition);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            VirtualCameraController._instance.TransitionTo(cameraPlayer);
        }
    }
}
