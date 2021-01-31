using UnityEngine;
using UnityEngine.Events;

public interface IFactoryProductDestroyer
{
    UnityAction<Product> OnObjectDestroyed { get; set; }
}
