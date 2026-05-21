using UnityEngine;

public class FoodPickup : MonoBehaviour
{
    public float pickupRange = 3f;

    public Transform holdPoint;

    private GameObject heldItem;

    void Update()
    {
        // Pickup or Drop
        if (
            Input.GetKeyDown(KeyCode.E)
            ||
            Input.GetMouseButtonDown(0)
        )
        {
            if (heldItem == null)
            {
                PickupNearestFood();
            }
            else
            {
                DropItem();
            }
        }

        // Hold item in front
        if (heldItem != null)
        {
            heldItem.transform.position =
                holdPoint.position;

            heldItem.transform.rotation =
                holdPoint.rotation;
        }
    }

    void PickupNearestFood()
    {
        GameObject[] foods =
            GameObject.FindGameObjectsWithTag(
                "Pickup"
            );

        GameObject nearestFood = null;

        float nearestDistance =
            pickupRange;

        foreach (GameObject food in foods)
        {
            float distance =
                Vector3.Distance(
                    transform.position,
                    food.transform.position
                );

            if (distance < nearestDistance)
            {
                nearestDistance = distance;

                nearestFood = food;
            }
        }

        if (nearestFood != null)
        {
            heldItem = nearestFood;

            Rigidbody rb =
                heldItem.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.isKinematic = true;

                rb.useGravity = false;
            }
        }
    }

    void DropItem()
    {
        if (heldItem != null)
        {
            Rigidbody rb =
                heldItem.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.isKinematic = false;

                rb.useGravity = true;
            }

            heldItem = null;
        }
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