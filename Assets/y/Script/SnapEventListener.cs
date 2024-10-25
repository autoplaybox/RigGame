using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapEventListener : MonoBehaviour
{
    public SnapManager snapManager;  // Reference to the SnapManager

    private void Start()
    {
        // Subscribe to the delegate event in SnapManager
        if (snapManager != null)
        {
            snapManager.OnObjectsSnapped += OnSnapSuccess;
        }
    }

    // This method will be called when the snap event is triggered
    private void OnSnapSuccess()
    {
        Debug.Log("Objects snapped together!");
    }

    private void OnDestroy()
    {
        // Unsubscribe from the delegate event to avoid memory leaks
        if (snapManager != null)
        {
            snapManager.OnObjectsSnapped -= OnSnapSuccess;
        }
    }
}
