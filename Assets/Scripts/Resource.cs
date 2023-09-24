using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource : MonoBehaviour
{
    public enum Type
    {
        Map,
        Pet,
        Character,
    }

    public Type type;
    public int id;

}
