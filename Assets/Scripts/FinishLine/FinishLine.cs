using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public delegate void OnGoalReachHandler();
    public static event OnGoalReachHandler OnGoalReach;
    private void OnTriggerEnter(Collider other)
    {
        OnGoalReach?.Invoke();
    }
}
