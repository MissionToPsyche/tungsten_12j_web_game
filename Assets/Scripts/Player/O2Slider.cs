using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class O2Slider : MonoBehaviour
{

    [SerializeField]
    private int totalOxygen;

    [SerializeField]
    private float oxygenLossInterval;
    [SerializeField]
    private float oxygenChangeAmount;

    [SerializeField]
    private Slider oxygenSlider;

    [SerializeField]
    private bool willLoseOxygen = false;

    float _frame = 0f;

    // Update is called once per frame
    void Update()
    {
        _frame += 1f;

        //Debug.Log(_frame);

            //Every few frames lose oxygen
            if (_frame >= oxygenLossInterval)
            {
                if (willLoseOxygen)
                    oxygenSlider.value -= oxygenChangeAmount;
                else
                    oxygenSlider.value += oxygenChangeAmount;

                _frame = 0f; 
            }
    }

    //updates totalOxygen variable to match oxygenSlider value
    public void updateOxygen() { totalOxygen = (int)oxygenSlider.value; }

}
