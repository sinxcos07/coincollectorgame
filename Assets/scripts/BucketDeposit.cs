using UnityEngine;

public class BucketDeposit : MonoBehaviour
{
    private bool playerInside = false;

    private FoodPickup playerPickup;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;

            playerPickup =
                other.GetComponent<FoodPickup>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }

    void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.F))
        {
            if (playerPickup != null)
            {
                GameObject heldItem =
                    playerPickup.GetHeldItem();

                if (heldItem != null)
                {
                    Destroy(heldItem);

                    playerPickup.RemoveHeldItem();

                    // Update food counter
                    FoodGameManager.instance
                        .DepositFood();
                }
            }
        }
    }
}