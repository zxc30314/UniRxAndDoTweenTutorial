using UnityEngine;
using System;

namespace UniRx.Tutorial
{
    public class WhereTutorial : MonoBehaviour
    {
        // 延遲幾秒後，並且通知的值為Where 裡面設定的才通知
        private void Start()
        {

            Observable.Interval(TimeSpan.FromSeconds(2)).Where(value => value == 3).Subscribe(UpdateIndex).AddTo(this);
            // 8秒後通知 3
        }

        private void UpdateIndex(long index)
        {
            Debug.Log(index);
        }
    }
}
