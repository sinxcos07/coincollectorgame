using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public Transform holdPoint;

    public float pickupRange = 3f;

    private GameObject heldItem;

    void Update()
    {
        // Press E to pickup or drop
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldItem == null)
            {
                PickupNearestCoin();
            }
            else
            {
                DropItem();
            }
        }

        // Keep held item in front of player
        if (heldItem != null)
        {
            heldItem.transform.position = holdPoint.position;
        }
    }

    void PickupNearestCoin()
    {
        GameObject[] coins =
            GameObject.FindGameObjectsWithTag("Pickup");

        foreach (GameObject coin in coins)
        {
            float distance =
                Vector3.Distance(
                    transform.position,
                    coin.transform.position
                );

            if (distance <= pickupRange)
            {
                heldItem = coin;

                // Disable collider while holding
                Collider col =
                    heldItem.GetComponent<Collider>();

                if (col != null)
                {
                    col.enabled = false;
                }

                // Disable physics while holding
                Rigidbody rb =
                    heldItem.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.isKinematic = true;
                }

                // Attach to hold point
                heldItem.transform.parent = holdPoint;

                heldItem.transform.localPosition =
                    Vector3.zero;

                return;
            }
        }
    }

    void DropItem()
    {
        // Remove from player
        heldItem.transform.parent = null;

        // Enable collider again
        Collider col =
            heldItem.GetComponent<Collider>();

        if (col != null)
        {
            col.enabled = true;
        }

        // Enable physics again
        Rigidbody rb =
            heldItem.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.isKinematic = false;
        }

        heldItem = null;
    }

    public GameObject GetHeldItem()
    {
        return heldItem;
    }

    public void RemoveHeldItem()
    {
        heldItem = null;
    }
}