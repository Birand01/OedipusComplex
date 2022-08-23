using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class VirtualCamController : MonoBehaviour
{
   CinemachineVirtualCamera cam;
    private void Awake()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
       
    }
    private void OnEnable()
    {
        FinishLine.OnGoalReach += GameEndCameraPosition;
    }
    private void Start()
    {
       


        CinemachineTransposer transposer = cam.GetCinemachineComponent<CinemachineTransposer>();
        transposer.m_FollowOffset = new Vector3(0, 3f, -4.5f);
        CinemachineComposer composer= cam.GetCinemachineComponent<CinemachineComposer>();
        composer.m_SoftZoneHeight = 0.2f;
        composer.m_SoftZoneWidth = 0.16f;
        transposer.m_XDamping = 0f;
        transposer.m_YDamping = 0f;
        transposer.m_ZDamping = 0f;
        composer.m_BiasY = -0.28f;
        composer.m_TrackedObjectOffset=new Vector3(0,2.58f,0);
      
    }
    private void LateUpdate()
    {
        //Transform focusObject = CharacterSpawner.Instance.characterPrefabs[CharacterSpawner.Instance.selectedCharacter].transform.GetChild(0);
        cam.Follow = CharacterSpawner.Instance.clone.transform.GetChild(0);
        cam.LookAt = CharacterSpawner.Instance.clone.transform.GetChild(0);

       
    }

    private void GameEndCameraPosition()
    {
        CinemachineTransposer transposer = cam.GetCinemachineComponent<CinemachineTransposer>();
        transposer.m_FollowOffset = new Vector3(0, 5f, -7f);
        transposer.m_YDamping = 2f;
        transposer.m_XDamping = 2f;
        transposer.m_ZDamping = 2f;
    }

    private void OnDisable()
    {
        FinishLine.OnGoalReach -= GameEndCameraPosition;
    }


}
