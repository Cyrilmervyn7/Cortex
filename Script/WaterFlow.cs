using UnityEngine;
using UnityEngine.UI;

public class Waterflow : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Image waterbar;     // Current water fill
    [SerializeField] private Image maxwaterbar;  // Optional background bar

    [Header("Settings")]
    [SerializeField] private float fillSpeed = 0.005f;   // Super slow fill speed
    [SerializeField] private bool autoDrain = false;     // Enable/disable auto decrease
    [SerializeField] private float drainRate = 0.001f;   // Super slow drain rate

    private float targetFill = 0f; // Target value (0 to 1)

    void Start()
    {
        // Start empty
        waterbar.fillAmount = 10f;
        if (maxwaterbar != null)
            maxwaterbar.fillAmount = 1f; // Background always full
    }

    void Update()
    {
        // Smoothly move waterbar.fillAmount toward targetFill
        waterbar.fillAmount = Mathf.MoveTowards(
            waterbar.fillAmount,
            targetFill,
            fillSpeed * Time.deltaTime
        );

        // Optional: auto-drain water over time
        if (autoDrain && targetFill > 0f)
        {
            targetFill -= drainRate * Time.deltaTime;
            targetFill = Mathf.Clamp01(targetFill);
        }
    }

    // Call this from another script or button
    public void AddWater(float amount)
    {
        targetFill = Mathf.Clamp01(targetFill - amount); // More water = bar increases
    }

    public void RemoveWater(float amount)
    {
        targetFill = Mathf.Clamp01(targetFill + amount); // Less water = bar decreases
    }
}
