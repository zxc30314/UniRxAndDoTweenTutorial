using System;
using UniRx;
using UnityEngine;

public static class UniRxExpansion
{
    public static void Subscribe<T>(this MonoBehaviour monoBehaviour, IObservable<T> observable, Action<T> action)
    {
        observable.ObserveOnMainThread().Subscribe(action).AddTo(monoBehaviour);
    }
}