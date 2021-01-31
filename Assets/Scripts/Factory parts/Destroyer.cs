using UnityEngine;
using UnityEngine.Events;

// Factory objects destroyer

[RequireComponent(typeof(Collider))]
public class Destroyer : MonoBehaviour, IFactoryProductDestroyer
{
    public UnityAction<Product> OnObjectDestroyed { get; set; }
    [SerializeField] private float timeToDestroy = 4f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Product product))
        {
            OnObjectDestroyed?.Invoke(product);
        }
        Destroy(other.gameObject, timeToDestroy);
    }
}
