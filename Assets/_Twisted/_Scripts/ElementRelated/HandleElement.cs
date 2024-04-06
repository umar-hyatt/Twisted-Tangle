using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using _Twisted._Scripts.ControllerRelated;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class HandleElement : MonoBehaviour
{
    private ObjectDrag _dragScript;
    [HideInInspector] public bool placePossible;
    [HideInInspector] public Vector3 _lastPos;
    
    private HandleGridElement _handleGridElement;
    [SerializeField]private Vector3 _rayOffset;

    [HideInInspector] public bool mouseDown;
    private Collider _collider;

    private void Start()
    {
        _dragScript = GetComponent<ObjectDrag>();
        _lastPos = transform.position;
        _collider = GetComponent<Collider>();
    }
    
    RaycastHit hit;
    private void Update()
    {
        /*if (!mouseDown) return;
        if(Physics.Raycast(transform.position + _rayOffset, Vector3.down, out hit,15))
        {
            Debug.DrawRay(transform.position + _rayOffset, Vector3.down * 15, Color.red);
            print(hit.collider.name);
        }
        else
        {
            _dragScript.targetSnapPosition = _lastPos;
            _dragScript.isSnapping = true;
            //PlaceTheHandle(transform.position);
        }*/
    }

    public void PlaceTheHandle(Vector3 gridPos)
    {
        if(placePossible)
        {
            Vector3 pos = new Vector3(gridPos.x, 0, gridPos.z);
            transform.position = pos;
            _lastPos = pos;
        }
        else
        {
            transform.position = _lastPos;
        }
        _dragScript.draggable = true;
    }
    
}
