using CodeMonkey.FreeWindow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter: BaseCounter 
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            // There is no KitchenObject here
            if(player.HasKitchenObject())
            {
                //Player is carrying somthing
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                //Player not Carrying anything
            }
        }
        else
        {
            // There is a KitchenObject here
            if(player.HasKitchenObject())
            {
                // Player is carrying something
            }
            else
            {
                //Player not Carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
