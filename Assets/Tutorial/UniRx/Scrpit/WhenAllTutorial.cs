using UnityEngine;

namespace UniRx.Tutorial
{
    public class WhenAllTutorial : MonoBehaviour
    {
        // 當所有的Subject OnCompleted 時通知，並且通知的值的順序會依照塞入WhenAll的順序
        Subject<int> subject0 = new Subject<int>();
        Subject<int> subject1 = new Subject<int>();
        Subject<int> subject2 = new Subject<int>();

        private void Start()
        {
            Observable.WhenAll(subject0, subject1, subject2).Subscribe(OnCompleted);

            subject0.OnNext(10);
            subject0.OnNext(15);
            subject0.OnCompleted();
            subject1.OnNext(21);
            subject2.OnCompleted();
            subject2.OnNext(33);
            subject2.OnCompleted();
            //output: 15,21,33
        }

        private void OnCompleted(int[] obj)
        {
            Debug.Log(string.Join(",", obj));
        }
    }
}
