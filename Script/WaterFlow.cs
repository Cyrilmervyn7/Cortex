using UnityEngine;
using UnityEngine.UI;

public class UIWaterController : MonoBehaviour
{
    // This property controls the fill amount of the water image
    private static readonly int FillAmount = Shader.PropertyToID("_FillAmount");

    [Header("Shader Properties")]
    [SerializeField] private float waterSpeed;
    [SerializeField] private float waterMagnitude;

    [Header("Water Level")]
    [SerializeField] private float currentWaterLevel;
    [SerializeField] private float maxWaterLevel;

    private RawImage rawImage;
    private Material waterMaterial;

    private void Awake()
    {
        rawImage = GetComponent<RawImage>();
        if (rawImage != null && rawImage.material != null)
        {
            // Get an instance of the material
            waterMaterial = rawImage.material;
        }
        else
        {
            Debug.LogError("RawImage component or its material not found. Please assign the UI_Water_Material.");
        }
    }

    public void AddWater(float amount)
    {
        // Increase the current water level, clamping it to the max
        currentWaterLevel = Mathf.Clamp(currentWaterLevel - amount, 0, maxWaterLevel);
    }

    private void Update()
    {
        if (waterMaterial != null)
        {
            // Update the shader properties with the values from the script
            waterMaterial.SetFloat(FillAmount, currentWaterLevel);
            waterMaterial.SetFloat("_Speed", waterSpeed); // This name is for the old shader, update it if you use a different one
            waterMaterial.SetFloat("_Magnitude", waterMagnitude); // Same here
        }
    }
}