using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SnowballMover : MonoBehaviour 
{
    public bool moving;
    public float speed;

    public bool doMovement;
    
    private Vector3 targetVelocity;

    public Rigidbody rb;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();
    }

    public void UpdateVelocity(float xMovement, float zMovement) 
    {
        if (!doMovement)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            // rb.velocity = Vector3.zero;
            // rb.angularVelocity = Vector3.zero;
            return;
        }
        
        rb.velocity = xMovement * speed * Vector3.right + zMovement * speed * Vector3.forward + Physics.gravity;

       // Vector3 axis = Vector3.Cross(rb.velocity, Vector3.down);
        //float angle = (rb.velocity.magnitude * 360 / transform.GetChild(0).localScale.x * Mathf.PI);
       // transform.Rotate(axis,angle * Time.deltaTime, Space.World);

        float w = 180 * rb.velocity.magnitude / (Mathf.PI * transform.GetChild(0).localScale.x * 0.5f);
        Vector3 axis = Vector3.Cross(rb.velocity, Vector3.down);
        transform.Rotate(axis,w * Time.deltaTime, Space.World);
        
       // rb.angularVelocity = -xMovement * speed * Vector3.forward + zMovement * speed * Vector3.right;

        if (xMovement.Equals(0) && zMovement.Equals(0)) 
        {
            moving = false;
        } 
        else 
        {
            moving = true;
        }
    }
}