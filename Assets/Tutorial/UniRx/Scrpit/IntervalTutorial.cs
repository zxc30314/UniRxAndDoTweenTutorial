using System;
using UnityEngine;

namespace UniRx.Tutorial
{
    public class IntervalTutorial : MonoBehaviour
    {
        //Interval 延遲2秒後通知，之後每兩秒通知一次，通知的值為index
        private void Start()
        {
            Observable.Interval(TimeSpan.FromSeconds(2)).Subscribe(UpdateIndex).AddTo(this);
        }

        private void UpdateIndex(long index)
        {
            Debug.Log(index);
        }
    }
}
