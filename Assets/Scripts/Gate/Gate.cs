using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Gate : MonoBehaviour
{
    public delegate void OnMaleSpinAnimationHandler();
    public delegate void OnFemaleSpinAnimationHandler();
    public delegate void OnMaleSadWalkAnimationHandler();
    public delegate void OnFemaleSadWalkAnimationHandler();

    public static event OnMaleSadWalkAnimationHandler OnMaleSadWalkAnimation;    
    public static event OnMaleSpinAnimationHandler OnMaleSpinAnimation;

    public static event OnFemaleSadWalkAnimationHandler OnFemaleSadWalkAnimation;
    public static event OnFemaleSpinAnimationHandler OnFemaleSpinAnimation;

    [SerializeField] private TMP_Text speechText=null;
    [SerializeField] SpeechData speechData;
    [SerializeField] private enum GateType
    {
        MaleGate,FemaleGate
    }
    [SerializeField] private GateType gateType;
    [SerializeField] private int speechIndex;

    private void Awake()
    {
        RandomGateSpeech();
    }
   

    private void RandomGateSpeech()
    {
        switch (gateType)
        {
            case GateType.MaleGate:
               
                speechIndex =UnityEngine.Random.Range(0,7);
                speechText.text = speechData.speeches[speechIndex];            
                break;
            case GateType.FemaleGate:
               
                speechIndex = UnityEngine.Random.Range(0, 7);
                speechText.text = speechData.speeches[speechIndex];
                break;
            

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (gateType)
        {
            case GateType.MaleGate:
                if(other.gameObject.CompareTag("Male"))
                {
                    OnMaleSpinAnimation?.Invoke();
                    IPowerBooster booster = other.GetComponent<IPowerBooster>();
                    if (booster != null)
                    {                      
                        booster.GainPower(20);
                    }    
                }
                else if (other.gameObject.CompareTag("Female"))
                {
                    OnFemaleSadWalkAnimation?.Invoke();
                    IReducePower reducePower = other.GetComponent<IReducePower>();
                    if (reducePower != null)
                    {
                        reducePower.ReducePower(20);
                    }
                }
                break;
            case GateType.FemaleGate:
                if (other.gameObject.CompareTag("Female"))
                {
                    OnFemaleSpinAnimation?.Invoke();
                    IPowerBooster booster = other.GetComponent<IPowerBooster>();
                    if (booster != null)
                    {                   
                        booster.GainPower(20);
                    }
                }
                else if (other.gameObject.CompareTag("Male"))
                {
                    OnMaleSadWalkAnimation?.Invoke();
                    IReducePower reducePower = other.GetComponent<IReducePower>();
                    if (reducePower != null)
                    {
                        reducePower.ReducePower(20);
                    }
                }
                break;
        
        }
    }
}
