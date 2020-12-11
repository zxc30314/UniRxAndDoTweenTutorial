using UnityEngine;

namespace UniRx.Tutorial
{
    public class SubjectTutorial : MonoBehaviour
    {
        //Subject 在每次OnNext時，都會通知
        Subject<int> level = new Subject<int>();

        private void Start()
        {
            level.Subscribe(UpdateLevel).AddTo(this);

            level.OnNext(0);
            level.OnNext(1);
            level.OnNext(2);
            level.OnNext(2);
        }

        private void UpdateLevel(int obj)
        {
            Debug.Log($"Level is {obj}");
        }
    }
}
