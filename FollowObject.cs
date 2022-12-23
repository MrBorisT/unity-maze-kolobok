using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] Transform objectToFollow;
    void Update()
    {
        transform.position = objectToFollow.position;        
    }
}
