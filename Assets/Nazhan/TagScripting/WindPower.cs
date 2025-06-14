using UnityEngine;

public class WindPower : MonoBehaviour
{
    public ParticleSystem particleEffect;

    public float pushForce = 200f;
    //public float zDirection = -100;
    private bool isButtonPressed = false;
    public AudioSource audioSource;
    private Collider windCollider;


    void Start()
    {
        windCollider = GetComponent<Collider>();
        if (windCollider != null)
        {
            windCollider.enabled = false; // Disable collider by default
        }
        else
        {
            Debug.LogWarning("No collider found on WindPower GameObject.");
        }
        
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                Debug.LogWarning("No AudioSource component found on WindPower GameObject.");
            }
        }
    }

    void Update()
    {

        // Check if the J key is pressed
        if (Input.GetKeyDown(KeyCode.J))
        {
            // Enable collider and play particle effect
            if (windCollider != null)
            {
                windCollider.enabled = true;
            }
            PlayEffect();
            PlayAudio();
            isButtonPressed = true; // Set flag
        }
        
        // When J key released, disable collider and reset flag
        if (Input.GetKeyUp(KeyCode.J))
        {
            if (windCollider != null)
            {
                windCollider.enabled = false;
            }
            StopEffect();
            StopAudio();
            isButtonPressed = false;
        }

    }

    public void OnTriggerStay(Collider other)
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
    
    
    public void PlayEffect()
    {
        if (particleEffect != null)
        {
            particleEffect.Play();
        }
    }
    
    public void StopEffect()
    {
        if (particleEffect != null)
        {
            particleEffect.Stop();
        }
    }

    public void PlayAudio()
    {
        if (audioSource != null)
        {

            audioSource.loop = true; // loop while button held
            audioSource.Play();
        }
    }
  
    public void StopAudio()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }


}
