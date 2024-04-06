using System;
using _Twisted._Scripts.ElementRelated;
using UnityEngine;

public class PlaceChecker : MonoBehaviour
{
    [SerializeField] public HandleGridElement _handleGridElement;
    [SerializeField] private HandleElement handleElement;
    [SerializeField] private ObjectDrag _dragScript;

    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Port")
        {
            other.tag="PortFull";
            _handleGridElement = other.GetComponent<HandleGridElement>();
            if (_handleGridElement)
            {
                _handleGridElement.ChangeVisual(true);
                handleElement.placePossible = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Port")
        {
            other.tag="PortFull";
            _handleGridElement = other.GetComponent<HandleGridElement>();
            if (_handleGridElement)
            {
                handleElement.placePossible = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "PortFull")
        {
            other.tag ="Port";
        }
        if (other.tag == "Port")
        {
            //other.tag="PortFull";
            HandleGridElement ballPlaceElement = other.GetComponent<HandleGridElement>();
            if (ballPlaceElement)
            {
                ballPlaceElement.ChangeVisual(false);
                _handleGridElement = null;
                handleElement.placePossible = false;
            }
        }
            if (other.CompareTag("floor"))
            {
                _dragScript.targetSnapPosition = handleElement._lastPos;
                _dragScript.isSnapping = true;
            }
        
    }
    public void PlaceHandle()
    {
        if(_handleGridElement)
        _handleGridElement.GetComponent<SphereCollider>().tag="PortFull";
        handleElement.PlaceTheHandle(_handleGridElement != null ? _handleGridElement.transform.position : handleElement.transform.position);
    }
}