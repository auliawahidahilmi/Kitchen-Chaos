using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounter : BaseCounter
{
    [SerializeField] FryingRecipeSO[] fryingRecipeSOArray;

    private float fryingTimer;
    private FryingRecipeSO fryingRecipeSO;

    private void Update()
    {
        if (HasKitchenObject())
        {
            fryingTimer += Time.deltaTime;
            FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
            if (fryingTimer > fryingRecipeSO.fryingTimerMax)
            {
                //fried
                fryingTimer = 0f;
                Debug.Log("fried");
                GetKitchenObject().DestroySelf();

                KitchenObject.SpawnKitchenObject(fryingRecipeSO.output, this);
            }
            Debug.Log(fryingTimer);
        }
    }
    private void Start()
    {
        StartCoroutine(HandleFryTimer());
    }

    //fungsi Coroutine
    private IEnumerator HandleFryTimer()
    {
        yield return new WaitForSeconds(1f);
    }

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            //ga ada kitchen object di sini
            if (player.HasKitchenObject())
            {
                //player bawa sesuatu
                if (HasRecipeInput(player.GetKitchenObject().GetKitchenObjectSO()))
                {
                    //player bawa sesuatu lalu digoreng
                    player.GetKitchenObject().SetKitchenObjectParent(this);

                    fryingRecipeSO = GetFryingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());

                }
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

    private bool HasRecipeInput(KitchenObjectSO inputKitchenObjectSO)
    {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(inputKitchenObjectSO);
        return fryingRecipeSO != null;
    }

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSO)
    {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(inputKitchenObjectSO);
        if(fryingRecipeSO != null)
        {
            return fryingRecipeSO.output;
        }
        else
        {
            return null;
        }
    }

    private FryingRecipeSO GetFryingRecipeSOWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (FryingRecipeSO fryingRecipeSO in fryingRecipeSOArray)
        {
            if (fryingRecipeSO.input == inputKitchenObjectSO)
            {
                return fryingRecipeSO;
            }
        }
        return null;
    }
}
