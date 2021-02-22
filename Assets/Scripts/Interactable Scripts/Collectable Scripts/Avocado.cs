﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avocado : Collectable
{
    /// <summary> The number of uses on this Avocado. </summary>
    /// <value> Represents how many hits this item will take before
    /// being destroyed. </value>
    public int Uses { get; set; } = 2;

    public override void Interact()
    {
        ///On pick up is added to inventory.
        ///And gives the player an additional heart

        if (Player.Instance.PInven.AddItem(this)) 
            Player.Instance.BonusHealth += Uses;
    }
}
