using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPickUp : PickUp
{
    protected override void OnPickUp(PlayerFateAchievement playerFate)
    {
        if (playerFate.gameObject.CompareTag("Male"))
        {
            IPowerBooster booster = playerFate.GetComponent<IPowerBooster>();
            if (booster != null)
            {
                booster.GainPower(5);
            }
        }
        else if (playerFate.gameObject.CompareTag("Female"))
        {
            IReducePower booster = playerFate.GetComponent<IReducePower>();
            if (booster != null)
            {
                booster.ReducePower(5);
            }
        }
    }
}
