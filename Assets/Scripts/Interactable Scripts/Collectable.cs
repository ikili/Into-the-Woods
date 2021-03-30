﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : Interactable
{
    /// <summary>
    /// The logic that may or may not need to be applied when
    /// the player drops an item.
    /// </summary>
    /// 

    public Sprite UISprite;

    public abstract void DropLogic();

    public override void Interact()
    {
        ///Add to inventory
        Player.Instance.PInven.AddItem(this);
        if (this is PotionIngredient && PlayerInfo.DoubleHarvest)
        {
            Player.Instance.PInven.AddItem(this);
        }

        PopupCheck();
    }

    /// <summary>
    /// Checks to see if the popup for the item needs to be displayed.
    /// </summary>
    protected void PopupCheck()
    {
        if (!Player.Instance.PInven.HasCollectedBefore(this))
        {
            //Debug.Log("Collected before");
            PopUpManager.Instance.PopUp(this);
        }
    }
}
