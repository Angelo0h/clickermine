using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats
{
    public float gold;
    public float money;
    public int goldperClick;
    public int goldPerSec;

    public Block[] state = new Block[10];

}
