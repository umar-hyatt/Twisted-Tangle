using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleGridElement : MonoBehaviour
{
    public GameObject selectedVisual;
    
    public void ChangeVisual(bool state)
    {
        selectedVisual.SetActive(state);
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
