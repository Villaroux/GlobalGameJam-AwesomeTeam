using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    public void TPTo(Transform newPos)
    {
        this.transform.position = newPos.position;
    }
}
