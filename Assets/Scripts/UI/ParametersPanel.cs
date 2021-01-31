using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParametersPanel : MonoBehaviour
{
    public Text ParametersText;
    [Header("Assign with material sprites")]
    public List<Sprite> MaterialIconSprites;
    [Header("Assign with UI elements")]
    public List<Image> ColorPalettes;
    public List<Image> MaterialIcons;

    public void UpdateParameters(Parameters parameters)
    {
        ParametersText.text = parameters.ToString();

        // Display colors
        for (int i = 0; i < ColorPalettes.Count; i++)
        {
            if (parameters.Colors.Count > i)
            {
                ColorPalettes[i].color = parameters.Colors[i];
                ColorPalettes[i].gameObject.SetActive(true);
            }
            else
            {
                ColorPalettes[i].gameObject.SetActive(false);
            }
        }
        // Display materials
        for (int i = 0; i < MaterialIcons.Count; i++)
        {
            if (parameters.Materials.Count > i)
            {
                MaterialIcons[i].gameObject.SetActive(true);
                MaterialIcons[i].sprite = GetMaterialSprite(parameters.Materials[i]);
            }
            else
            {
                MaterialIcons[i].gameObject.SetActive(false);
            }
        }
    }

    public Sprite GetMaterialSprite(ProductMaterial material)
    {
        if (material == ProductMaterial.Wood)
        {
            return MaterialIconSprites[0];
        }
        if (material == ProductMaterial.Rubber)
        {
            return MaterialIconSprites[1];
        }
        if (material == ProductMaterial.Plastic)
        {
            return MaterialIconSprites[2];
        }
        if (material == ProductMaterial.Non_ferrous_metal)
        {
            return MaterialIconSprites[3];
        }
        if (material == ProductMaterial.Ferrous_metal)
        {
            return MaterialIconSprites[4];
        }

        return null;
    }

    public void UpdateParameters(ProductParameters parameters)
    {
        ParametersText.text = parameters.ToString();
        ColorPalettes[0].color = parameters.Color;
        for (int i = 1; i < ColorPalettes.Count; i++)
        {
            ColorPalettes[i].gameObject.SetActive(false);
        }
    }
}
