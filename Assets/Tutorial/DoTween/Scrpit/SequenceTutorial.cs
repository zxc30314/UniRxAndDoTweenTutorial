using UnityEngine;
using DG.Tweening;
using System;

namespace DoTweenTutorial
{
    public class SequenceTutorial : MonoBehaviour
    {
        // Append 是疊加 做完一個會接下去做
        // AppendInterval 是延遲
        // Join 是加入 會附加在 Append 上
        // Instert 是插入 (延後幾秒,Tween)
        
        [SerializeField] private RectTransform rectTransform;
        public void Start()
        {
            Sequence sequence = DOTween.Sequence()
                .Append(rectTransform.DOScale(Vector3.one * 1.5f, 0.5f).OnComplete(() => OnComplete("Append 0")))
                .Join(rectTransform.DOAnchorPosX(100, 2).OnComplete(() => OnComplete("Join")))
                .Insert(1, rectTransform.DORotate(Quaternion.Euler(0, 0, -15).eulerAngles, 5).OnComplete(() => OnComplete("Insert")))
                .AppendInterval(2)
                .Append(rectTransform.DOAnchorPosY(100, 3).OnComplete(() => OnComplete("Append 1")))
                .AppendCallback(OnCompelet);
        }

        private void OnComplete(string v)
        {
            Debug.Log(v);
        }

        private void OnCompelet()
        {
            Debug.Log("Compelet");
        }

        private void Reset()
        {
            rectTransform = GetComponent<RectTransform>();
        }
    }
}
