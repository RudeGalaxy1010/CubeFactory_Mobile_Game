using System.Collections;
using UnityEngine;

// Enter point
public class GameManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private ProductSpawner _productSpawner;
    [SerializeField] private Destroyer _destroyer;
    [Header("Database")]
    [SerializeField] private Database _database;
    [Header("UI")]
    [SerializeField] private UI _UI;

    private IEnumerator Start()
    {
        yield return StartCoroutine(_database.Init(_UI));

        #region Subscribes
        _destroyer.OnObjectDestroyed += _database.CheckDestroyedProduct;
        _UI.SubscribeAll();
        #endregion

        // Start spawning
        var products = Database.Instance.GetAllProducts();
        var parameters = Database.Instance.ParametersController.GetAvailableParameters();
        _productSpawner.BeginSpawn(products, parameters);
    }

    #region Unsubscribes
    private void OnDisable()
    {
        _destroyer.OnObjectDestroyed += _database.CheckDestroyedProduct;
        _UI.UnSubscribeAll();
    }
    #endregion

    private void OnApplicationQuit()
    {
        _database.SaveAll();
    }
}