using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public string name;
    public Sprite image;
    public string description;

    public virtual void use()
    {

    }
}
