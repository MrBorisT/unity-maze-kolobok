using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Portal OtherPortal;
    [SerializeField] public Transform exit;

    public Transform GetExitTransformFromOtherPortal()
    {
        if (OtherPortal != null)
            return OtherPortal.exit;
        throw new System.NullReferenceException();
    }
}
