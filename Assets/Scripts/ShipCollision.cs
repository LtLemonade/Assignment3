using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShipCollision : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject explosion;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with: " + collision.gameObject.name);
        if (!Shield.instance.isActive && (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Destroyable"))
        {
            Died();
        }
        else if (collision.gameObject.tag == "PowerUp")
        {
            collision.gameObject.SetActive(false);
        }
    }

    public void Died()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        AudioManager.instance.Play("Dead");
        gameObject.SetActive(false);
        gameOverScreen.SetActive(true);
        ScoreManager.instance.isDead = true;
    }
}
