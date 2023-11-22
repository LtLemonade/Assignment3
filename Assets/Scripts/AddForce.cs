using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    Vector3 torque;
    Vector3 direction;
    // Start is called before the first frame update
    void Awake()
    {
        torque.x = Random.Range(-50, 50);
        torque.y = Random.Range(-50, 50);
        torque.z = Random.Range(-50, 50);
        direction.x = Random.Range(-0.5f, 0.5f);
        direction.y = Random.Range(-0.5f, 0.5f);
        direction.z = Random.Range(-0.5f, 0.5f);
        gameObject.GetComponent<Rigidbody>().AddForce(direction, ForceMode.Impulse);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(torque * Time.fixedDeltaTime);
        gameObject.GetComponent<Rigidbody>().MoveRotation(gameObject.GetComponent<Rigidbody>().rotation * deltaRotation);
    }
}
