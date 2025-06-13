using UnityEngine;

public class WindPower : MonoBehaviour
{
    public float pushForce = 200;
    //public float zDirection = -100;
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && other.attachedRigidbody)
        {
            //other.attachedRigidbody.AddForce(Vector3.forward * zDirection);

            // Calculate the direction from the center of the WindPower object to the enemy
            Vector3 pushDirection = other.transform.position - transform.position;
            // Normalize the direction to ensure consistent force regardless of distance
            pushDirection.Normalize();
            // Apply the force to the enemy's rigidbody
            other.attachedRigidbody.AddForce(pushDirection * pushForce);
        }
    }
}
