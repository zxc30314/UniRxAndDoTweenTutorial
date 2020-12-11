using UnityEngine;
using DG.Tweening;

namespace DoTweenTutorial
{
    public class PlaybackTutorial : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;
        Tween tween;
        private void Start()
        {
            tween = rectTransform.DOScale(Vector3.zero, 0.5f).OnComplete(OnClose).SetAutoKill(false);
        }

        private void OnClose()
        {
            Debug.Log("Clsoe");
            tween.PlayBackwards();
        }

        private void Reset()
        {
            rectTransform = GetComponent<RectTransform>();
        }

    }

}
