using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public GameObject pickupEffect;
    public string effect;

    private Slider timeSlider;
    private GameObject player;

    private void Start()
    {
        timeSlider = GameObject.Find("Time").GetComponent<Slider>();
        player = GameObject.Find("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Shield"))
        {
            AudioManager.instance.Play("PowerUp");
            switch (effect)
            {
                case "ROF":
                    ROF();
                    break;
                case "Rewind":
                    RewindIncrease();
                    break;
                case "Multiplyer":
                    Multiplyer();
                    break;

            }
        }
    }
    public void ROF()
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        UpgradeManager.instance.ROFCollected++;
        if (UpgradeManager.instance.ROFCollected % UpgradeManager.instance.ROFToCollect == 0)
        {
            AudioManager.instance.Play("Upgrade");
            player.GetComponent<Shooting>().fireDelay /= UpgradeManager.instance.ROFMultiplyer;
        }
        Destroy(gameObject);
    }

    public void RewindIncrease()
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        UpgradeManager.instance.rewindCollected++;
        if (UpgradeManager.instance.rewindCollected % UpgradeManager.instance.rewindToCollect == 0)
        {
            AudioManager.instance.Play("Upgrade");
            timeSlider.maxValue *= UpgradeManager.instance.rewindMultiplyer;
            timeSlider.value = timeSlider.maxValue;
        }
        Destroy(gameObject);
    }
    
    public void Multiplyer()
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        UpgradeManager.instance.multiplyerCollected++;
        if (UpgradeManager.instance.multiplyerCollected % UpgradeManager.instance.multiplyerToCollect == 0)
        {
            AudioManager.instance.Play("Upgrade");
            ScoreManager.instance.multiplyer *= UpgradeManager.instance.multiplyerMultiplyer;
        }
        Destroy(gameObject);
    }
}
