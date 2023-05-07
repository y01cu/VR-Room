using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class AnalogClockController : MonoBehaviour
{
    private int hour;
    private int minute;
    private int second;

    // hour * 30
    // minute * 1
    // second * 1

    [SerializeField] private GameObject hourGameObject;
    [SerializeField] private GameObject minuteGameObject;
    [SerializeField] private GameObject secondGameObject;

    private void Start()
    {
        AssignTimePeriods();
        AssignClock();
        LogCalculateCurrentTime();
        UpdateClock();
    }

    private IEnumerator UpdateHour()
    {
        yield return new WaitForSeconds(3600);
        hourGameObject.transform.Rotate(0, 30, 0);
        StartCoroutine(UpdateHour());
    }

    private IEnumerator UpdateMinute()
    {
        yield return new WaitForSeconds(60);
        minuteGameObject.transform.Rotate(0, 6, 0);
        StartCoroutine(UpdateMinute());
    }
    private IEnumerator UpdateSecond()
    {
        yield return new WaitForSeconds(1);
        secondGameObject.transform.Rotate(0, 6, 0);
        StartCoroutine(UpdateSecond());
    }

    private void AssignClock()
    {
        //float baseAngle = 90;

        
        float hourInitialAngle = hour * 30;
        float minuteInitialAngle = minute * 6;
        float secondInitialAngle = 0;
        
        hourGameObject.transform.Rotate(0, hourInitialAngle, 0);
        minuteGameObject.transform.Rotate(0, minuteInitialAngle, 0);
        secondGameObject.transform.Rotate(0, secondInitialAngle, 0);
    }
    
    private void UpdateClock()
    {
        // Start coroutines at the same time
        StartCoroutine(UpdateHour());
        StartCoroutine(UpdateMinute());
        StartCoroutine(UpdateSecond());
    }

    private void AssignTimePeriods()
    {
        DateTime currentTime = DateTime.Now;

        hour = currentTime.Hour;
        minute = currentTime.Minute;
        second = currentTime.Second;
    }

    private void LogCalculateCurrentTime()
    {
        DateTime currentTime = DateTime.Now;
        Debug.Log(hour + "/n" + minute + "/n" + second);
    }

}
