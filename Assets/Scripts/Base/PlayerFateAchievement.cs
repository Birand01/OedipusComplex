using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class PlayerFateAchievement : MonoBehaviour,IPowerBooster, IReducePower
{
    public delegate void OnPlayerDanceAnimationHandler();
    public delegate void OnLevelEndEventHandler();

    public static event OnLevelEndEventHandler OnLevelEnd;
    public static event OnPlayerDanceAnimationHandler OnPlayerDanceAnimation;


    [SerializeField] private Slider powerSlider;
    [SerializeField] private Image powerBarFillImage;
    [SerializeField] private Color maxPowerColor, zeroPowerColor;
    [SerializeField] float currentPower;

    public float Power
    {
        get
        {
            return currentPower;
        }
        set
        {
            currentPower = value;
        }
    }
   

    protected virtual void Awake()
    {
        Power = 0;
        SetPowerBarUI();
    }
    protected virtual void Update()
    {
        EndLinePowerBar();
    }

    protected virtual void Start()
    {
        SetPowerBarUI();
    }
   
    public virtual void GainPower(float booster)
    {
        Power += booster;
        Power = Mathf.Clamp(Power, 0, 100f);
        EndLinePowerBar();
        SetPowerBarUI();
    }

    public virtual void ReducePower(float booster)
    {
        Power -= booster;
        Power = Mathf.Clamp(Power, 0, 100f);
        SetPowerBarUI();
    }
    protected virtual void EndLinePowerBar()
    {
        if (PlayerReachesEndLine.Instance.playerReachesEndline)
        {
            Power -= 10*Time.deltaTime;
            Power = Mathf.Clamp(Power, 0, 100f);
            if(Power<=0)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                OnPlayerDanceAnimation?.Invoke();
                OnLevelEnd?.Invoke();
            }
            SetPowerBarUI();
        }

    }
   

    protected virtual void SetPowerBarUI()
    {
        float powerPercentage = CalculatePowerPercentage();
        powerSlider.value = powerPercentage;
        powerBarFillImage.color=Color.Lerp(maxPowerColor, zeroPowerColor, powerPercentage/100);
            
    }
    private float CalculatePowerPercentage()
    {
        return (Power / powerSlider.maxValue) * 100;
    }

  
}
