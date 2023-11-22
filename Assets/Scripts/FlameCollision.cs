using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameCollision : MonoBehaviour
{

    private void OnParticleCollision(GameObject other)
    {
        if (!Shield.instance.isActive && other.gameObject.tag == "Player")
        {
            other.GetComponent<ShipCollision>().Died();
        }
    }
}
