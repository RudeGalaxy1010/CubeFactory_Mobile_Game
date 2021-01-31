using UnityEngine;

public interface IProduct
{
    void SetParameters(ProductParameters parameters);
    void Move(Vector3 direction, float speed);
    void Stop();
    void ForceMove(Vector3 direction, float force);
    void SetMovingSpeed(float speed);
    void SetMovingDirection(Vector3 direction);
}
