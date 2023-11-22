using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] easyTiles;
    public GameObject[] mediumTiles;
    public GameObject[] hardTiles;
    public GameObject startTile;

    public float tileSpeed;
    public int difficulty;
    public float index = 0;
    public bool isMovingForward;
    public bool isMovingBackward;

    private bool penalty;
    public int penaltyDelay;

    private void Start()
    {
        GameObject StartTile = Instantiate(startTile, transform);
        StartTile.transform.position = transform.position;
        penaltyDelay = 3;
        int RandomInt1 = Random.Range(0, easyTiles.Length);
        GameObject TempTile1 = Instantiate(easyTiles[RandomInt1], transform);
        TempTile1.transform.position = new Vector3(0, 0, 500);
        penalty = false;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && !ScoreManager.instance.isDead)
        {
            if (!isMovingForward)
            {
                AudioManager.instance.Play("Spaceship");
            }
            gameObject.transform.position += new Vector3(0, 0, -(tileSpeed * Time.deltaTime));
            isMovingForward = true;
            isMovingBackward = false;
            penalty = false;
            ScoreManager.instance.AddPoints(1);
        }
        else if (gameObject.GetComponent<RewindBody>().isRewinding && !ScoreManager.instance.isDead)
        {
            penalty = false;
        }
        else
        {
            AudioManager.instance.Stop("Spaceship");
            StartCoroutine(PenaltyTimer());
            isMovingForward = false;
        }

        if(!isMovingForward && penalty && !ScoreManager.instance.isDead)
        {
            ScoreManager.instance.AddPoints(-1);
            Debug.Log(penalty);
        }

        if (transform.position.z <= index)
        {
            if (difficulty == 0)
            {

                int RandomInt2 = Random.Range(0, easyTiles.Length);
                GameObject TempTile2 = Instantiate(easyTiles[RandomInt2], transform);
                TempTile2.transform.position = new Vector3(0, 0, 1000);
            }
            else if (difficulty == 1)
            {
                Debug.Log("Difficulty Increased");
                int RandomInt2 = Random.Range(0, mediumTiles.Length);
                GameObject TempTile2 = Instantiate(mediumTiles[RandomInt2], transform);
                TempTile2.transform.position = new Vector3(0, 0, 1000);
            }
            else if (difficulty == 2)
            {
                Debug.Log("Difficulty Increased");
                int RandomInt2 = Random.Range(0, hardTiles.Length);
                GameObject TempTile2 = Instantiate(hardTiles[RandomInt2], transform);
                TempTile2.transform.position = new Vector3(0, 0, 1000);
            }

            index -= 500f;
        }
    }

    IEnumerator PenaltyTimer()
    {
        yield return new WaitForSeconds(penaltyDelay);
        if (!isMovingForward)
            penalty = true;
    }
}
