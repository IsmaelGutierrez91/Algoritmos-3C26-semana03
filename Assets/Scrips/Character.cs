using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string name;
    public float speed;
    public Character(string name, float speed)
    {
        this.name = name;
        this.speed = speed;
    }
    public void GetInformation()
    {
        Debug.Log("Nombre: " + name + " / Velocidad: " + speed);
    }
}
