using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// No comments

public class ProductSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private float _spawnTime;

    public void BeginSpawn(List<Product> products, Parameters parameters)
    {
        StartCoroutine(Spawn(products, parameters));
    }

    private IEnumerator Spawn(List<Product> products, Parameters parameters)
    {
        while (true)
        {
            var newProduct = products[Random.Range(0, products.Count)];
            var newParameters = parameters.GetRandomParameters();

            Spawn(newProduct, newParameters);

            yield return new WaitForSeconds(_spawnTime);
        }
    }

    private void Spawn(Product prefab, ProductParameters parameters)
    {
        var product = Instantiate(prefab.gameObject, _spawnPosition.position, Quaternion.identity).GetComponent<Product>();
        product.SetParameters(parameters);
    }
}
