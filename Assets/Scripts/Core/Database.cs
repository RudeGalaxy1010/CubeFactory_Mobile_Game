using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Data container
[Serializable]
public class Database : IGameDataStorage
{
    public static Database Instance;

    // Assigned in inspector
    [SerializeField] private List<Product> _products;

    public UI UI => _UI;
    private UI _UI;

    #region Parameters
    public ParametersController ParametersController => _parametersController;
    // Assigned in inspector
    [SerializeField] private ParametersController _parametersController;
    #endregion

    #region User
    public UserInfo UserInfo => _userInfo;
    private UserInfo _userInfo;
    private SaveSystem<UserInfo> _UserInfoSaveSystem;
    #endregion

    public IEnumerator Init(UI UI)
    {
        _UI = UI;

        // Load and generate data
        #region Load or generate user info
        _UserInfoSaveSystem = new SaveSystem<UserInfo>();
        _userInfo = _UserInfoSaveSystem.LoadInfo();
        if (_UserInfoSaveSystem.IsLoaded == false)
        {
            _userInfo = new UserInfo();
            _userInfo.SetDefaultParameters(_parametersController.GetDefaultParameters());
        }
        #endregion

        // Wait for loading or creating data
        yield return new WaitUntil(()=> _userInfo.AvailableParameters != null);

        // Initialize product parameters
        _parametersController.Init(_userInfo);

        Instance = this;
    }

    public List<Product> GetAllProducts()
    {
        return _products;
    }

    public void CheckDestroyedProduct(Product product)
    {
        if (ParametersController.CheckParameters(product.Parameters))
        {
            UserInfo.AddScore(1);
        }
    }

    public void SaveAll()
    {
        _UserInfoSaveSystem.SaveInfo(_userInfo.GetInfoToSave());
    }
}
