using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileBehavior : MonoBehaviour
{
    public int speed;
    public ParticleSystem explosion;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Destroyable")
        {
            Destroy(collision.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            AudioManager.instance.Play("Explosion");
            ScoreManager.instance.AddPoints(50);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}