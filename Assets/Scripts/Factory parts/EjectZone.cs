using System.Collections.Generic;
using UnityEngine;

// Factory objects eject zone

[RequireComponent(typeof(Collider))]
public class EjectZone : MonoBehaviour
{
    [SerializeField] private Vector3 ejectDirection;
    [SerializeField] private float ejectForce;
    [SerializeField] private YSwipeRegistrar swipeRegastrar;

    private List<Product> currentCubes = new List<Product>();

    #region Initialize swipe registrar
    private void OnEnable()
    {
        swipeRegastrar.OnSwipeRegistered += TryEject;
    }

    private void OnDisable()
    {
        swipeRegastrar.OnSwipeRegistered -= TryEject;
    }
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Product cube))
        {
            currentCubes.Add(cube);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Product cube))
        {
            currentCubes.Remove(cube);
        }
    }

    public void TryEject()
    {
        if (currentCubes.Count > 0)
        {
            Eject();
        }
    }

    public void Eject()
    {
        currentCubes[0].ForceMove(ejectDirection, ejectForce);
        currentCubes.RemoveAt(0);
    }
}
