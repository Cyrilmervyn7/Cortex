using UnityEngine;
using UnityEngine.UI;

public class Waterflow : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Image waterbar;
    [SerializeField] private Image maxwaterbar;
    [Header("Settings")]
    [SerializeField] private float fillSpeed = 0.005f;
    [SerializeField] private bool autoDrain = false;
    [SerializeField] private float drainRate = 0.001f;

    private float targetFill = 0f;

    void Start()
    {
        waterbar.fillAmount = 10f;
        if (maxwaterbar != null)
            maxwaterbar.fillAmount = 1f;
    }

    void Update()
    {
        waterbar.fillAmount = Mathf.MoveTowards(
            waterbar.fillAmount,
            targetFill,
            fillSpeed * Time.deltaTime
        );

        if (autoDrain && targetFill > 0f)
        {
            targetFill -= drainRate * Time.deltaTime;
            targetFill = Mathf.Clamp01(targetFill);
        }
    }

    public void AddWater(float amount)
    {
        targetFill = Mathf.Clamp01(targetFill - amount);
    }

    public void RemoveWater(float amount)
    {
        targetFill = Mathf.Clamp01(targetFill + amount);
    }
}
