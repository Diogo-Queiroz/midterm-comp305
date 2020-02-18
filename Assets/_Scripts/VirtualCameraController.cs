using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[ExecuteInEditMode]
public class VirtualCameraController : MonoBehaviour
{
    public static VirtualCameraController _instance;
    public List<GameObject> virtualCameras;
    public GameObject playerCam;
    public GameObject levelCam;
    PlayerController player;
    void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        } else
        {
            Destroy(gameObject);
        }

        player = FindObjectOfType<PlayerController>();

        virtualCameras.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            virtualCameras.Add(transform.GetChild(i).gameObject);
        }


    }

    public void TransitionTo(GameObject cameraToTransitionTo)
    {
        for (int i = 0; i < virtualCameras.Count; i++)
        {
            if (virtualCameras[i] == cameraToTransitionTo)
            {
                virtualCameras[i].GetComponent<CinemachineVirtualCamera>().Priority = 10;
            }
            else
            {
                virtualCameras[i].GetComponent<CinemachineVirtualCamera>().Priority = 5;
            }
        }

    }

    public void TransitionTo(GameObject cameraToTransitionTo, GameObject cameraOut, float timeToWait)
    {
        for (int i = 0; i < virtualCameras.Count; i++)
        {
            if (virtualCameras[i] == cameraToTransitionTo)
            {
                virtualCameras[i].GetComponent<CinemachineVirtualCamera>().Priority = 10;
            }
            else
            {
                virtualCameras[i].GetComponent<CinemachineVirtualCamera>().Priority = 5;
            }
        }
        StartCoroutine(TransitionBack(cameraOut,timeToWait));
    }

    public IEnumerator TransitionBack(GameObject cameraOut, float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        player.canMove = true;
        for (int i = 0; i < virtualCameras.Count; i++)
        {
            if (virtualCameras[i] == cameraOut)
            {
                virtualCameras[i].GetComponent<CinemachineVirtualCamera>().Priority = 10;
            }
            else
            {
                virtualCameras[i].GetComponent<CinemachineVirtualCamera>().Priority = 5;
            }
        }
    }
}
