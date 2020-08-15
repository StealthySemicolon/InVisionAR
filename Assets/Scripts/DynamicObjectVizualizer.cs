using UnityEngine;

public class DynamicObjectVizualizer : MonoBehaviour
{
    Rigidbody rb;
    Vector3 lastVelocity;
    Vector3 velocity;
    Vector3 acceleration;
    public LineRenderer velocityLineRenderer;
    public LineRenderer accelLineRenderer;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastVelocity = rb.velocity;
    }

    void FixedUpdate()
    {
        velocity = rb.velocity;
        var deltaV = velocity - lastVelocity;
        lastVelocity = velocity;
        acceleration = deltaV / Time.fixedDeltaTime;

        Vector3 offset = new Vector3(0, 0.15f, 0);

        velocityLineRenderer.SetPositions(new Vector3[] { transform.position - offset, transform.position - offset + velocity });
        accelLineRenderer.SetPositions(new Vector3[] { transform.position + offset, transform.position + offset + acceleration });
    }
}
