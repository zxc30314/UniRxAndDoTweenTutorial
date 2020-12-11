using UnityEngine;

namespace UniRx.Tutorial
{
    public class ReactiveCollectionTutorial : MonoBehaviour
    {

        ReactiveCollection<string> names = new ReactiveCollection<string>();
        private void Start()
        {
            names.ObserveCountChanged().Subscribe(OnCountChange).AddTo(this);
            names.ObserveAdd().Subscribe(OnAdd).AddTo(this);
            names.ObserveMove().Subscribe(OnMove).AddTo(this);
            names.ObserveRemove().Subscribe(OnRemove).AddTo(this);
        }

        private void OnRemove(CollectionRemoveEvent<string> obj)
        {
            Debug.Log($"Remvoe {obj.Value} ");
        }

        private void OnMove(CollectionMoveEvent<string> obj)
        {
            Debug.Log($"Move {obj.Value} ");
        }

        private void OnAdd(CollectionAddEvent<string> obj)
        {
            Debug.Log($"Add {obj.Value} to Collection");
        }

        private void OnCountChange(int obj)
        {
            Debug.Log($"Count is change to {obj}");
        }
    }
}
