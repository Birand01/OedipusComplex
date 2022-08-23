using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReachesEndLine : MonoBehaviour
{
    public bool playerReachesEndline;
    public static PlayerReachesEndLine Instance { get; private set; }
    private void Awake()
    {    
        if (Instance == null)
            Instance = this;
    }
   
    private void OnEnable()
    {
        FinishLine.OnGoalReach += EndLine;
        PlayerInput.OnPlayerBodyMovement += GameEndState;
    }
   
    
    private void EndLine()
    {
        
        playerReachesEndline = true;
       

    }
    private void GameEndState(Ray pointerPosition)
    {
        if (playerReachesEndline)
        {
            CharacterSelection.Instance.isGameActive = false;
            Transform endPos = GameObject.FindGameObjectWithTag("EndPos").transform;
            transform.position = Vector3.MoveTowards(transform.position, endPos.position, 10 * Time.deltaTime);
            //transform.Translate(Vector3.forward * 10 * Time.deltaTime);
        }
    }


    private void OnDisable()
    {
        PlayerInput.OnPlayerBodyMovement -= GameEndState;
        FinishLine.OnGoalReach -= EndLine;
    }
}
