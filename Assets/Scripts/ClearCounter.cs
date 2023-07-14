using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{

    [SerializeField] KitchenObjectSO kitchenObjectSO;

    
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            //ga ada kitchen object di sini
            if (player.HasKitchenObject())
            {
                //player bawa sesuatu
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                //player ga bawa apa2
            }
        }
        else
        {
            //ada kitchen object di sini
            if (player.HasKitchenObject())
            {
                //player bawa sesuatu
            }
            else
            {
                //player ga bawa apa2
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
                
    }
}
