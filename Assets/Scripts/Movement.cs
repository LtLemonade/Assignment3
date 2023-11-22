using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Rigidbody player;
    private Vector3 playerSize;
    public float speed;
    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        if (!ScoreManager.instance.isDead)
        {
            Vector2 direction = Vector2.up * movement.y + Vector2.right * movement.x;
            player.velocity = direction * speed;
        }
    }
}
