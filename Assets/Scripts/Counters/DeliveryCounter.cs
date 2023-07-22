using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    public override void Interact(Player player)
    {
        if(player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
        {
            //only accepts plates

            DeliveryManager.Instance.DeliveryRecipe(plateKitchenObject);

            player.GetKitchenObject().DestroySelf();
        }
    }
}
