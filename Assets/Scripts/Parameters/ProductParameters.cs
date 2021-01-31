using UnityEngine;

// Parameters container for product

[System.Serializable]
public class ProductParameters
{
    [HideInInspector] public float Scale;
    [HideInInspector] public int Weight;
    [HideInInspector] public Color Color;
    [HideInInspector] public ProductMaterial Material;
    [HideInInspector] public ProductQuality Quality;

    public override string ToString()
    {
        var quality = "";

        if (Quality != ProductQuality.None)
        {
            quality = "qua: " + Quality.ToString() + "\n";
        }

        var scale = "scale: " + Scale.ToString() + "\n";

        var weight = "";

        if (Weight > 0)
        {
            weight = "weight: " + Weight.ToString() + "\n";
        }

        return $"{quality}{scale}{weight}";
    }
}
