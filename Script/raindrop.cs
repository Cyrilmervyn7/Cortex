using UnityEngine;

public class Raindrop : MonoBehaviour
{
    // A reference to the UIWaterController script
    public UIWaterController waterController;

    [Header("Water Amount")]
    // The range of water to subtract when a raindrop is collected
    public float minWaterAmount = 0.02f;
    public float maxWaterAmount = 0.1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider that entered the trigger is the player
        if (other.CompareTag("Player"))
        {
            // Generate a random amount of water to subtract within the defined range
            float randomAmount = Random.Range(minWaterAmount, maxWaterAmount);

            // Call the method to add water to the UI controller
            if (waterController != null)
            {
                waterController.AddWater(randomAmount);
            }

            // Destroy the raindrop after it's collected
            Destroy(gameObject);
        }
    }
}