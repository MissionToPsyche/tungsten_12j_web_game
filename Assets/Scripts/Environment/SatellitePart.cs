using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatellitePart : MonoBehaviour
{
    
    private string Name;
    private string Description;
    private Sprite Image;

    public SatellitePart(string name, string description, Sprite image)
    {
        Name = name;
        Description = description;
        Image = image;
    }

    public string getName() {
        return Name;
    }

    public string getDescription()
    {
        return Description;
    }

    public Sprite getImage()
    {
        return Image;
    }

}
