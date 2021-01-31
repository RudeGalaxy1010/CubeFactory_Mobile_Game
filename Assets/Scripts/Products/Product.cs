using UnityEngine;

// No comments

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Product : MonoBehaviour, IProduct
{
    public ProductParameters Parameters { get; private set; }

    private Rigidbody Rigidbody;
    private Vector3 direction = Vector3.zero;
    private float speed = 0;

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move(direction, speed);
    }

    public void SetParameters(ProductParameters parameters)
    {
        Parameters = parameters;

        transform.localScale = Vector3.one * parameters.Scale;
        gameObject.GetComponent<Renderer>().material.color = parameters.Color;
    }

    public void Move(Vector3 direction, float speed)
    {
        Rigidbody.MovePosition(Rigidbody.position + direction * speed * Time.deltaTime);
    }

    public void Stop()
    {
        direction = Vector3.zero;
        speed = 0;
    }

    public void ForceMove(Vector3 direction, float force)
    {
        Stop();
        Rigidbody.AddForce(direction * force, ForceMode.Impulse);
        Destroy(gameObject, 5f);
    }

    public void SetMovingSpeed(float speed)
    {
        this.speed = speed;
    }

    public void SetMovingDirection(Vector3 direction)
    {
        this.direction = direction;
    }

    private void OnMouseDown()
    {
        if (GameTime.Instance.isBaseTimeScale)
        {
            GameTime.Instance.SlowDown();
            Database.Instance.UI.ProductParametersPanel.UpdateParameters(Parameters);
        }
        else
        {
            GameTime.Instance.Normalize();
        }
    }
}