using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathScanner : MonoBehaviour
{
    bool isBlocked;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Maze")
        {            
            isBlocked = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Maze")
        {
            isBlocked = false;
        }
    }

    public bool Blocked 
    {
        get { return isBlocked; }
    }
}
