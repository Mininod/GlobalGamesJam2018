using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyType : MonoBehaviour {

    public enum objectTag
    {
        Player,
        Warrior,
        Archer,
        Wizard,
        floor
    }

    public objectTag mytype;
}
