using UnityEngine;

namespace UniRx.Tutorial
{
    public class ReactivePropertyTutorial : MonoBehaviour
    {
        //ReactiveProperty 註冊時會先通知 Default ，之後更改值會通知
        //如果更改的值跟原本一樣 則不會通知
        //判定的標準 
        //Value Type 值
        //Ref   Type 記憶體位置
        ReactiveProperty<int> rank = new ReactiveProperty<int>();

        private void Start()
        {
            rank.Subscribe(UpdateRank).AddTo(this);
            rank.Value = 1;
            rank.Value = 2;
            rank.Value = 2;
            rank.Value = 5;
            rank.Value = 5;
            rank.SetValueAndForceNotify(5);

            //Log: 0 1 2 5 25
        }

        private void UpdateRank(int obj)
        {
            Debug.Log($"Rank is {obj}");
        }
    }
}
