using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leonard : PlayerController,IMoveable
{
    private Animator anim;
    private void Awake()
    {
        anim=GetComponent<Animator>();
    }
    protected override void OnEnable()
    {
        PlayerFateAchievement.OnPlayerDanceAnimation += DanceAnimation;
        FinishLine.OnGoalReach += FastRunAnimation;
        Gate.OnMaleSadWalkAnimation += SadWalkAnimation;
        Gate.OnMaleSpinAnimation += SpinAnimation;
        PlayerInput.OnGameStart += WalkAnimation;
        base.OnEnable();
    }
    protected override void OnDisable()
    {
        PlayerFateAchievement.OnPlayerDanceAnimation -= DanceAnimation;
        FinishLine.OnGoalReach -= FastRunAnimation;
        Gate.OnMaleSadWalkAnimation -= SadWalkAnimation;
        Gate.OnMaleSpinAnimation -= SpinAnimation;
        PlayerInput.OnGameStart -= WalkAnimation;
        base.OnDisable();
    }
    public void WalkAnimation(bool state)
    {
        anim.SetFloat("Speed", 1.0f);
    }
    public void SpinAnimation()
    {
        anim.SetTrigger("Spin");
    }
    
    public void SadWalkAnimation()
    {
        anim.SetTrigger("SadWalk");
    }

    public void FastRunAnimation()
    {
        anim.SetFloat("Speed", 2.0f);
    }

    public void DanceAnimation()
    {
        anim.SetTrigger("Dance");
    }
}
