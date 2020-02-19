using UnityEngine;
using System.Collections;

public class DestroyStar : MonoBehaviour
{
    public float force = 20.0f;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 4.0f);
    }
}
