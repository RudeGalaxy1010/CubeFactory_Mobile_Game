using UnityEngine;

// Factory conveyor component

[RequireComponent(typeof(Collider))]
public class Conveyor : MonoBehaviour
{
    [SerializeField] private float speed;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Product product))
        {
            product.SetMovingDirection(transform.forward);
            product.SetMovingSpeed(speed);
        }
    }
}
