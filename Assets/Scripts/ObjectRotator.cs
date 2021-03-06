﻿using UnityEngine;
using System.Collections;
using Cinemachine;

public class ObjectRotator : MonoBehaviour
{
    public GameObject Target;     
    public float _sensitivity;
    private Vector3 _mouseReference;
    private Vector3 _mouseOffset;
    private Vector3 _rotation;
    private bool _isRotating;
    public float PanSpeed;
    public CinemachineVirtualCamera cam;
    
    public Vector2 ScrollLimit;
    private bool _isPanning;

    private CinemachineComposer comp;
    void Start ()
    {
        _rotation = Vector3.zero;
        comp = cam.GetCinemachineComponent<CinemachineComposer>();
    }
         
    void Update()
    {
        if(_isRotating)
        {
            // offset
            _mouseOffset = (Input.mousePosition - _mouseReference);
                 
            // apply rotation
            _rotation.x = _mouseOffset.x * _sensitivity;
            _rotation.y = -_mouseOffset.y * _sensitivity;
            
            // rotate
            transform.RotateAround(Target.transform.position, Vector3.up, _rotation.x);

            if (_rotation.y > 0 && transform.position.y < 4.7f)
                transform.RotateAround(Target.transform.position, transform.right, _rotation.y);
                
            if( _rotation.y < 0 && transform.position.y > 0 )
                transform.RotateAround(Target.transform.position, transform.right, _rotation.y);
            
            
            // store mouse
            _mouseReference = Input.mousePosition;
        }else if (_isPanning)
        {
            _mouseOffset = (Input.mousePosition - _mouseReference);
            comp.m_TrackedObjectOffset -= transform.InverseTransformDirection(_mouseOffset * PanSpeed); 
        }

        // Rotate
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseAction();
        }
        if (Input.GetMouseButtonUp(0))
        {
            OnMouseStopAction();
        }

        // Pan
        if (Input.GetMouseButtonDown(1))
        {
            OnMouseActionPan();
        }
        if (Input.GetMouseButtonUp(1))
        {
            OnMouseStopActionPan();
        }
        
        // Scroll
        if (Input.mouseScrollDelta.magnitude > 0)
        {
            if (Input.mouseScrollDelta.y > 0)
            {
                if(Vector3.Distance(transform.position, Target.transform.position) > ScrollLimit.x)
                    transform.Translate(Vector3.forward*_sensitivity);
            }
            else
            {
                if(Vector3.Distance(transform.position, Target.transform.position) < ScrollLimit.y)
                    transform.Translate(Vector3.back*_sensitivity);
            }
        }
        
    }


    void OnMouseAction()
    {
        // rotating flag
        _isRotating = true;
             
        // store mouse
        _mouseReference = Input.mousePosition;
    }
         
    void OnMouseStopAction()
    {
        // rotating flag
        _isRotating = false;
    }
    
    
    void OnMouseActionPan()
    {
        // rotating flag
        _isPanning = true;
             
        // store mouse
        _mouseReference = Input.mousePosition;
    }
         
    void OnMouseStopActionPan()
    {
        // rotating flag
        _isPanning = false;
    }
         
}