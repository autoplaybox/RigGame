using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SnapManager : MonoBehaviour
{
    public GameObject player;  
    public GameObject mesh;  
    public float snapDistance = 0.5f;  // Distance threshold to snap 


    // Define a delegate type for the snap event
    public delegate void SnapEventHandler();

    // Create an event based on the delegate
    public event SnapEventHandler OnObjectsSnapped;

    private void Update()
    {
        CheckSnapCondition();
    }   

    // Check if objects are close enough to snap
    private void CheckSnapCondition()
    {
        float distance = Vector3.Distance(player.transform.position, mesh.transform.position);

        if (distance <= snapDistance)
        {
            SnapObjects();
        }
    }

    private void SnapObjects()
    {
        // Align object B to object A
        mesh.transform.position = player.transform.position;

        // Invoke the UnityEvent for snapping success
        if (OnObjectsSnapped != null)
        {
            OnObjectsSnapped.Invoke();
        }
    }
}
