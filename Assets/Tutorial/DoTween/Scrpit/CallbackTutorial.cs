using UnityEngine;
using DG.Tweening;

namespace DoTweenTutorial
{
    public class CallbackTutorial : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;
        private void Start()
        {
            Tween tween = rectTransform.DOScale(Vector3.zero, 0.5f).OnComplete(OnClose);
        }

        private void OnClose()
        {
            Debug.Log("Clsoe");
        }
        private void Reset()
        {
            rectTransform = GetComponent<RectTransform>();
        }
    }

}
