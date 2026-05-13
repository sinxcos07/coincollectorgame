using UnityEngine;

public class ChestDeposit : MonoBehaviour
{
    private bool playerInside = false;

    private CoinPickup playerPickup;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;

            playerPickup =
                other.GetComponent<CoinPickup>();
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

                    GameManager.instance.DepositCoin();
                }
            }
        }
    }
}