using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public ProjectileBehavior projectile;
    public GameObject barrel;
    public LevelGenerator movement;
    private float nextShot;
    public float fireDelay;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextShot && Time.timeScale != 0.0f)
        {
            AudioManager.instance.Play("Gun");
            ProjectileBehavior bullet = Instantiate(projectile, barrel.gameObject.transform.position, Quaternion.identity);
            Quaternion targetRotation = Quaternion.Euler(90, 0, 0);

            bullet.transform.rotation = targetRotation;
            if (movement.isMovingForward)
            {
                bullet.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1) * (bullet.speed + movement.tileSpeed) * Time.deltaTime;
            }
            else if (movement.isMovingBackward)
            {
                bullet.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1) * (bullet.speed - movement.tileSpeed) * Time.deltaTime;
            }
            else
            {
                bullet.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1) * bullet.speed * Time.deltaTime;
            }

            nextShot = Time.time + fireDelay;
        }
    }
}

