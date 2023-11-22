using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{

    public static UpgradeManager instance;
    public int ROFToCollect;
    [HideInInspector]
    public int ROFCollected;
    public float ROFMultiplyer;

    public int rewindToCollect;
    [HideInInspector]
    public int rewindCollected;
    public float rewindMultiplyer;

    public int multiplyerToCollect;
    [HideInInspector]
    public int multiplyerCollected;
    public int multiplyerMultiplyer;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        ROFCollected = 0;
        rewindCollected = 0;
        multiplyerCollected = 0;
    }


}
