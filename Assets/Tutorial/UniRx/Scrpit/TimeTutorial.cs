using UnityEngine;
using System;

namespace UniRx.Tutorial
{
    public class TimeTutorial : MonoBehaviour
    {
        // 延遲幾秒後通知，通知的值為index
        private void Start()
        {
            Observable.Timer(TimeSpan.FromSeconds(2)).Subscribe(UpdateIndex).AddTo(this);
        }

        private void UpdateIndex(long index)
        {
            Debug.Log(index);
        }
    }
}
