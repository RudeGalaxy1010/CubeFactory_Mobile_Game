using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Controller for better setup and access to parameters data

[System.Serializable]
public class ParametersController: IParametersController, ILevelParametersContainer
{
    public UnityAction<Parameters> OnLevelParametersChanged { get; set; }

    // Assigned in inspector
    [SerializeField] private Parameters _allParameters;
    [SerializeField] private Parameters _defaultParameters;
    // Assigned automatically
    private Parameters _availableParameters;
    private Parameters _levelParameters;

    public void Init(UserInfo userInfo)
    {
        SetAvailableParameters(userInfo.AvailableParameters);
        _levelParameters = GenerateLevelParameters();
    }

    public bool CheckParameters(ProductParameters parameters)
    {
        if (_levelParameters.Equals(parameters))
        {
            return true;
        }

        return false;
    }

    public (Color? newColor, ProductMaterial? newMaterial) OpenNewParameter()
    {
        if (Random.Range(0, 100) < 50 &&
            _availableParameters.Colors.Count != _allParameters.Colors.Count)
        {
            Color newColor = _availableParameters.GetRandomColor();
            while (_availableParameters.Colors.Contains(newColor))
            {
                newColor = _allParameters.GetRandomColor();
            }
            _availableParameters.MergeColors(new List<Color> { newColor });
            return (newColor, null);
        }
        else if (_allParameters.Materials.Count != _allParameters.Materials.Count)
        {
            ProductMaterial newMaterial = ProductMaterial.None;
            while (newMaterial == ProductMaterial.None ||
                _availableParameters.Materials.Contains(newMaterial))
            {
                newMaterial = _allParameters.GetRandomMaterial();
            }
            _availableParameters.MergeMaterials(new List<ProductMaterial>() { newMaterial });
            return (null, newMaterial);
        }

        return (null, null);
    }

    public Parameters GenerateLevelParameters()
    {
        _levelParameters = ScriptableObject.CreateInstance<Parameters>();

        for (int i = 0; i < 3; i++)
        {
            var newParameters = _availableParameters.GetRandomParameters();

            // Color
            if (_levelParameters.Colors.Contains(newParameters.Color) == false)
            {
                _levelParameters.Colors.Add(newParameters.Color);
            }
            // Material
            if (_levelParameters.Materials.Contains(newParameters.Material) == false)
            {
                _levelParameters.Materials.Add(newParameters.Material);
            }
            // Quality
            if (_levelParameters.Quality.Contains(newParameters.Quality) == false)
            {
                _levelParameters.Quality.Add(newParameters.Quality);
            }

            #region Weight
            if (newParameters.Weight < _levelParameters.WeightLimits.x)
            {
                _levelParameters.WeightLimits =
                    new Vector2(newParameters.Weight, _levelParameters.WeightLimits.y);
            }
            if (newParameters.Weight > _levelParameters.WeightLimits.y)
            {
                _levelParameters.WeightLimits =
                    new Vector2(_levelParameters.WeightLimits.x, newParameters.Weight);
            }
            #endregion

            #region Scale
            if (newParameters.Scale < _levelParameters.ScaleLimitsPercentage.x)
            {
                _levelParameters.ScaleLimitsPercentage =
                    new Vector2(newParameters.Scale, _levelParameters.ScaleLimitsPercentage.y);
            }
            if (newParameters.Scale > _levelParameters.ScaleLimitsPercentage.y)
            {
                _levelParameters.ScaleLimitsPercentage =
                    new Vector2(_levelParameters.ScaleLimitsPercentage.x, newParameters.Scale);
            }
            #endregion
        }

        OnLevelParametersChanged?.Invoke(_levelParameters);
        return _levelParameters;
    }

    public Parameters GetAllParameters()
    {
        return _allParameters;
    }

    public Parameters GetDefaultParameters()
    {
        return _defaultParameters;
    }

    public Parameters GetAvailableParameters()
    {
        return _availableParameters;
    }

    private void SetAvailableParameters(Parameters parameters)
    {
        _availableParameters = parameters;
    }
}
