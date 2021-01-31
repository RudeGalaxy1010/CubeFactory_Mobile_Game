using System.Collections.Generic;
using UnityEngine;

// Universal parameters container

public enum ProductMaterial
{
    None,
    Wood,
    Rubber,
    Plastic,
    Non_ferrous_metal,
    Ferrous_metal,
}
public enum ProductQuality
{
    None,
    Awful,
    Bad,
    Ok,
    Good,
    Perfect,
}

[System.Serializable]
[CreateAssetMenu(fileName = "New product parameters", menuName = "Parameters Data", order = 51)]
public class Parameters: ScriptableObject
{
    public List<Color> Colors = new List<Color>();
    public Vector2 ScaleLimitsPercentage = Vector2.zero;
    public Vector2 WeightLimits = Vector2.zero;
    public List<ProductMaterial> Materials = new List<ProductMaterial>();
    public List<ProductQuality> Quality = new List<ProductQuality>();

    public ProductParameters GetRandomParameters()
    {
        var result = new ProductParameters();

        if (Colors.Count > 0)
        {
            result.Color = Colors[UnityEngine.Random.Range(0, Colors.Count)];
        }
        if (ScaleLimitsPercentage != Vector2.zero)
        {
            result.Scale = ((int)UnityEngine.Random.Range(ScaleLimitsPercentage.x, ScaleLimitsPercentage.y + 1)) / 100f;
        }
        if (WeightLimits != Vector2.zero)
        {
            result.Weight = (int)UnityEngine.Random.Range(WeightLimits.x, WeightLimits.y + 1);
        }
        if (Materials.Count > 0)
        {
            result.Material = Materials[UnityEngine.Random.Range(1, Materials.Count)];
        }
        if (Quality.Count > 0)
        {
            result.Quality = Quality[UnityEngine.Random.Range(1, Quality.Count)];
        }
        
        return result;
    }

    #region Merge
    public void Merge(Parameters parameters)
    {
        MergeColors(parameters.Colors);
        MergeMaterials(parameters.Materials);
        MergeQuality(parameters.Quality);
        MergeScale(parameters.ScaleLimitsPercentage);
        MergeWeight(parameters.WeightLimits);
    }

    public void MergeColors(List<Color> colors)
    {
        // Color
        for (int i = 0; i < colors.Count; i++)
        {
            if (Colors.Contains(colors[i]) == false)
            {
                Colors.Add(colors[i]);
            }
        }
    }

    public void MergeMaterials(List<ProductMaterial> materials)
    {
        // Material
        for (int i = 0; i < materials.Count; i++)
        {
            if (Materials.Contains(materials[i]) == false)
            {
                Materials.Add(materials[i]);
            }
        }
    }

    public void MergeQuality(List<ProductQuality> quality)
    {
        // Quality
        for (int i = 0; i < quality.Count; i++)
        {
            if (Quality.Contains(quality[i]) == false)
            {
                Quality.Add(quality[i]);
            }
        }
    }

    public void MergeScale(Vector2 scaleLimitsPercentage)
    {
        // Scale
        if (scaleLimitsPercentage.x < ScaleLimitsPercentage.x)
        {
            ScaleLimitsPercentage =
                new Vector2(scaleLimitsPercentage.x, ScaleLimitsPercentage.y);
        }
        if (scaleLimitsPercentage.y > ScaleLimitsPercentage.y)
        {
            ScaleLimitsPercentage =
                new Vector2(ScaleLimitsPercentage.x, scaleLimitsPercentage.y);
        }
    }

    public void MergeWeight(Vector2 weightLimits)
    {
        // Weight
        if (weightLimits.x < WeightLimits.x)
        {
            WeightLimits =
                new Vector2(weightLimits.x, WeightLimits.y);
        }
        if (weightLimits.y > WeightLimits.y)
        {
            WeightLimits =
                new Vector2(WeightLimits.x, weightLimits.y);
        }
    }
    #endregion

    public Color GetRandomColor()
    {
        return Colors[Random.Range(0, Colors.Count)];
    }

    public ProductMaterial GetRandomMaterial()
    {
        return Materials[Random.Range(1, Materials.Count)];
    }

    public override string ToString()
    {
        var quality = "";

        if (Quality.Count > 0)
        {
            quality = "qua: ";

            foreach (var qualityOption in Quality)
            {
                quality = qualityOption.ToString();
                if (Quality.IndexOf(qualityOption) != Quality.Count - 1)
                {
                    quality += " | ";
                }
            }

            quality += "\n";
        }

        var scale = $"{ScaleLimitsPercentage.x} - {ScaleLimitsPercentage.y} \n";

        var weight = "";

        if (WeightLimits != Vector2.zero)
        {
            weight = $"{WeightLimits.x} - {WeightLimits.y} \n";
        }

        return $"{quality}{scale}{weight}";
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override bool Equals(object other)
    {
        var parameters = other as ProductParameters;
        if (parameters != null)
        {
            if (Colors.Count > 0 && !Colors.Contains(parameters.Color))
            {
                return false;
            }
            if (Materials.Count > 0 && !Materials.Contains(parameters.Material))
            {
                return false;
            }
            if (Quality.Count > 0 && !Quality.Contains(parameters.Quality))
            {
                return false;
            }
            if (ScaleLimitsPercentage != Vector2.zero &&
                (parameters.Scale < ScaleLimitsPercentage.x || 
                parameters.Scale > ScaleLimitsPercentage.y))
            {
                return false;
            }
            if (WeightLimits != Vector2.zero &&
                (parameters.Weight < WeightLimits.x ||
                parameters.Weight > WeightLimits.y))
            {
                return false;
            }

            return true;
        }

        return base.Equals(other);
    }
}
