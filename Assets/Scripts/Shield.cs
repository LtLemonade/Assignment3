using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Shield : MonoBehaviour
{
    public static Shield instance;

    private MeshRenderer meshRenderer;
    private Collider shieldCollider;
    public bool isActive;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        isActive = false;
        meshRenderer = GetComponent<MeshRenderer>();
        shieldCollider = GetComponent<Collider>();
        // Disable MeshRenderer and Collider by default.
        DisableShieldGraphics();
    }

    public void ActivateShield()
    {

        isActive = true;
        // Enable MeshRenderer and Collider.
        EnableShieldGraphics();
    }

    public void DeactivateShield()
    {
        AudioManager.instance.Play("ShieldLoss");
        isActive = false;
        // Disable MeshRenderer and Collider.
        DisableShieldGraphics();
    }

    private void EnableShieldGraphics()
    {
        if (meshRenderer != null)
        {
            meshRenderer.enabled = true;
        }

        if (shieldCollider != null)
        {
            shieldCollider.enabled = true;
        }
    }

    private void DisableShieldGraphics()
    {
        if (meshRenderer != null)
        {
            meshRenderer.enabled = false;
        }

        if (shieldCollider != null)
        {
            shieldCollider.enabled = false;
        }
    }

    // Update the shield's position to match the player's position.
    void LateUpdate()
    {
        if (transform.parent != null)
        {
            transform.position = transform.parent.position;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Destroyable")
        {
            AudioManager.instance.Play("ShieldLoss");
            StartCoroutine(DeactivateShieldEarly());
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Destroyable")
        {
            AudioManager.instance.Play("ShieldLoss");
            StartCoroutine(DeactivateShieldEarly());
        }
    }

    IEnumerator DeactivateShieldEarly()
    {
        DisableShieldGraphics();

        yield return new WaitForSeconds(1f);
        
        isActive = false;
    }
}
