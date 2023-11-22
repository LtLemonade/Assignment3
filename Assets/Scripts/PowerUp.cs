using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    public GameObject pickupEffect;
    public float duration = 4f;
    public string effect;

    private Slider meter;
    public int refillValue;

    public int speedBoostValue;

    private GameObject player;

    private void Start()
    {
        meter = GameObject.Find("Time").GetComponent<Slider>();
        player = GameObject.Find("Ship");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Shield"))
        {
            AudioManager.instance.Play("PowerUp");
            switch (effect)
            {
                case "Shield":
                    StartCoroutine(EnableShield());
                    break;
                case "Fog":
                    StartCoroutine(ClearFog());
                    break;
                case "Speed":
                    StartCoroutine(SpeedBoost());
                    break;
                case "Points":
                    StartCoroutine(Modifyer());
                    break;
                case "Meter":
                    FillMeter(); 
                    break;

            }
        }
    }

    IEnumerator EnableShield()
    {
        AudioManager.instance.Play("ShieldUp");
        // Spawn effect
        Instantiate(pickupEffect, transform.position, transform.rotation);
        // Apply effect
        Shield.instance.ActivateShield();

        //player.GetComponent<Collider>().enabled = false;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = true;

        // Wait effect duration
        yield return new WaitForSeconds(duration);

        // Remove effect
        if(Shield.instance.isActive)
        {
            Shield.instance.DeactivateShield();
        }

        //player.GetComponent<Collider>().enabled = true;
        // Remove power up
        Destroy(gameObject);
    }

    private void FillMeter()
    {
        // Spawn effect
        Instantiate(pickupEffect, transform.position, transform.rotation);
        // Apply effect
        meter.value += refillValue;

        // Remove power up
        Destroy(gameObject);
    }

    IEnumerator ClearFog()
    {
        // Spawn effect
        Instantiate(pickupEffect, transform.position, transform.rotation);
        // Apply effect
        RenderSettings.fog = false;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = true;

        // Wait effect duration
        yield return new WaitForSeconds(duration);

        // Remove effect
        RenderSettings.fog = true;

        // Remove power up
        Destroy(gameObject);
    }

    IEnumerator Modifyer()
    {
        // Spawn effect
        Instantiate(pickupEffect, transform.position, transform.rotation);
        // Apply effect
        ScoreManager.instance.multiplyer *= 2;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = true;

        // Wait effect duration
        yield return new WaitForSeconds(duration);

        // Remove effect
        ScoreManager.instance.multiplyer /= 2;

        // Remove power up
        Destroy(gameObject);
    }

    IEnumerator SpeedBoost()
    {
        // Spawn effect
        Instantiate(pickupEffect, transform.position, transform.rotation);
        // Apply effect
        player.gameObject.GetComponent<Movement>().speed += speedBoostValue;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = true;

        // Wait effect duration
        yield return new WaitForSeconds(duration);

        // Remove effect
        player.gameObject.GetComponent<Movement>().speed -= speedBoostValue;

        // Remove power up
        Destroy(gameObject);
    }
}
