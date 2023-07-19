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
                if (player.HasKitchenObject())
                {
                    //player is carrying somethig
                    if(player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                    {
                        //player is holding plate
                        if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                        {
                            GetKitchenObject().DestroySelf();
                        }
                    }
                    else
                    {
                        //player is not carrying plate or something else
                        if(GetKitchenObject().TryGetPlate(out plateKitchenObject))
                        {
                            //BaseCounter is holding a plate
                            plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO());
                            {
                                player.GetKitchenObject().DestroySelf();
                            }
                        }
                    }
                }
            }
            else
            {
                //player ga bawa apa2
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
                
    }
}
