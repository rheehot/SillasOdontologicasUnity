﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitController : MonoBehaviour
{

    public ResetStates ResetStates;
    
    public TextMeshProUGUI unitName;
    [HideInInspector] public AnimatorCtrl currAnimator;
    [HideInInspector] public ChangeChairColor ChairColor;

    public List<Unit> Units;
    // Start is called before the first frame update
    void Start()
    {
        ChangeChair(0);
    }

    public void ChangeChair(int index)
    {
        // reset all cameras
        foreach (var unit in Units)
        {
            unit.Obj.SetActive(false);
        }

        var u = Units[index];
        u.Obj.SetActive(true);
        unitName.text = u.name;
        currAnimator = u.Animator;
        ChairColor = u.ChangeColor;
        ResetStates.ResetObjects();
        ResetStates.bandejaPrincipal.SetObjectActive(true);
    }

    public void StartAnimation(string anim)
    {
        currAnimator.StartAnimation(anim);
    }
    
    public void StartIngresar()
    {
        currAnimator.StartIngresar();
    }
    
    public void StartExaminar()
    {
        currAnimator.StartExaminar();
    }
    
    //Lift Back
    public void OnLiftBack()
    {
        currAnimator.OnLiftBack();
    }
    public void OffLiftBack()
    {
        currAnimator.OffLiftBack();
    }
    //Lower Back
    public void OnLowerBack()
    {
        currAnimator.OnLowerBack();
    }
    public void OffLowerBack()
    {
        currAnimator.OffLowerBack();
    }

    //Lift Chair
    public void OnLiftChair()
    {
        currAnimator.OnLiftChair();
    }
    public void OffLiftChair()
    {
        currAnimator.OffLiftChair();
    }
    
    //Lower Chair
    public void OnLowerChair()
    {
        currAnimator.OnLowerChair();
    }
    public void OffLowerChair()
    {
        currAnimator.OffLowerChair();
    }

    // Plate
    public void OnLowerPlate()
    {
        currAnimator.OnLowerPlate();
    }
    public void OffLowerPlate()
    {
        currAnimator.OffLowerPlate();
    }

    public void OnLiftPlate()
    {
        currAnimator.OnLiftPlate();
    }
    public void OffLiftPlate()
    {
        currAnimator.OffLiftPlate();
    }

    public void OnOpenPlate()
    {
        currAnimator.OnOpenPlate();
    }
    public void OffOpenPlate()
    {
        currAnimator.OffOpenPlate();
    }

    public void OnClosePlate()
    {
        currAnimator.OnClosePlate();
    }
    public void OffClosePlate()
    {
        currAnimator.OffClosePlate();
    }


    // Arm Plate

    public void OnOpenArmPlate()
    {
        currAnimator.OnOpenArmPlate();
    }
    public void OffOpenArmPlate()
    {
        currAnimator.OffOpenArmPlate();
    }

    public void OnCloseArmPlate()
    {
        currAnimator.OnCloseArmPlate();
    }
    public void OffCloseArmPlate()
    {
        currAnimator.OffCloseArmPlate();
    }


    public void ChangeColor(int c)
    {
        ChairColor.ChangeColor(c);
    }
    
    public void EnableTapWater(bool isActive)
    {
        currAnimator.EnableTapWater(isActive);
    }
    
    public void EnablePipeWater(bool isActive)
    {
        currAnimator.EnablePipeWater(isActive);
    }

    public void EnableLight(bool isEnabled)
    {
        currAnimator.EnableLight(isEnabled);
    }
    
    public void SetLightIntensity(int intensity)
    {
        currAnimator.SetLightIntensity(intensity);
    }

    public void SetQuad(bool isEnabled)
    {
        currAnimator.SetQuad(isEnabled);
    }
}

[Serializable]
public class Unit
{
    public string name;
    public GameObject Obj;
    public AnimatorCtrl Animator;
    public ChangeChairColor ChangeColor;

}