using System;
using UniRx;
using UnityEngine;

public class ExpansionTutorial : MonoBehaviour
{
    private void Start()
    {
        var observable = Observable.Interval(TimeSpan.FromSeconds(2));

        //Amazing Code
        this.Subscribe(observable, UpdateIndex);
    }

    private void UpdateIndex(long index)
    {
        Debug.Log(index);
    }
}
