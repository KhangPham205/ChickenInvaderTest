using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlackHole : MonoBehaviour
{
    public GameObject objectToControl;
    public float waitTime = 20f;
    public float t = 0f;

    public float rotationSpeed = 30f;
    private bool objectShown = false;

    void Start()
    {
        objectToControl.SetActive(false);
    }

    void Update()
    {
        t += Time.deltaTime;
        if (!objectShown && t >= waitTime)
        {
            // Hiện vật thể
            objectToControl.SetActive(true);
            objectShown = true;
        }

        // Xoay vật thể
        objectToControl.transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
    }
}
