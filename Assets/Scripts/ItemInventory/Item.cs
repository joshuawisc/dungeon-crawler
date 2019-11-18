using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string iid;
    public Texture icon;
    public bool isStub;
}
