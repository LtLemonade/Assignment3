using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewindBody : MonoBehaviour
{
    public bool isRewinding = false;
    List<Vector3> positions;
    private Slider timeBar;
    public int rewindDepletionRate;
    // Start is called before the first frame update
    void Start()
    {
        positions = new List<Vector3>();
        timeBar = GameObject.Find("Time").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !ScoreManager.instance.isDead)
        {
            StartRewind();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && !ScoreManager.instance.isDead)
        {
            StopRewind();
        }
    }

    private void FixedUpdate()
    {
        if (isRewinding)
        {
            timeBar.value -= rewindDepletionRate * Time.deltaTime;
            Rewind();
        }
        else
        {
            Record();
        }
    }

    void Record()
    {
        positions.Insert(0, transform.position);
    }

    void Rewind()
    {
        if (positions.Count > 0 && timeBar.value > 0)
        {
            transform.position = positions[0];
            positions.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }
    }

    public void StartRewind()
    {
        AudioManager.instance.Play("Rewind");
        isRewinding = true;
    }

    public void StopRewind()
    {
        AudioManager.instance.Stop("Rewind");
        isRewinding = false;
    }
}
