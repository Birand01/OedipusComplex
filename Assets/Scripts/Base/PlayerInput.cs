using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public delegate void OnPlayerBodyMovementHandler(Ray point);
    public static event OnPlayerBodyMovementHandler OnPlayerBodyMovement;

    public delegate void OnGameStartEventHandler(bool state);
    public static event OnGameStartEventHandler OnGameStart;


   
    protected virtual void Update()
    {
        OnBodyMovement();
        OnStartGame();
    }

    private void OnStartGame()
    {
        if(Input.GetMouseButton(0) && !PlayerReachesEndLine.Instance.playerReachesEndline)
        {
            OnGameStart?.Invoke(true);
        }
      
      
    }

    private void OnBodyMovement()
    {
        OnPlayerBodyMovement?.Invoke(GetMousePosition());
    }

    private Ray GetMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        Ray mouseWorldPos = Camera.main.ScreenPointToRay(mousePos);
        return mouseWorldPos;
    }
}
