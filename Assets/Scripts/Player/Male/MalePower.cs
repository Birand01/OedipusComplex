using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MalePower : PlayerFateAchievement
{
    [SerializeField] TMP_Text feelingText;
    [SerializeField] ParticleSystem confettiParticle;
    private Rigidbody _rb;
    protected override void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        base.Awake();
    }
  
    protected override void Update()
    {       
        FeelingText();
        base.Update();

    }
    protected override void EndLinePowerBar()
    {
       if(Power<=0 && PlayerReachesEndLine.Instance.playerReachesEndline)
        {
            confettiParticle.Play();
            PlayerReachesEndLine.Instance.playerReachesEndline = false;
            _rb.velocity = Vector3.zero;
        }
        base.EndLinePowerBar();
    }
    private  void FeelingText()
    {
        if (Power < 50)
        {
            feelingText.text = "SAD";
        }
        else
        {
            feelingText.text = "HAPPY";
        }
    }
   
}
