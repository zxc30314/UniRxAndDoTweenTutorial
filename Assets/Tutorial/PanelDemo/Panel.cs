using DG.Tweening;
using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Panel
{
    [RequireComponent(typeof(RectTransform))]
    public class Panel : MonoBehaviour
    {
        private RectTransform rectTransform;
        public RectTransform RectTransform => rectTransform ? rectTransform : rectTransform = GetComponent<RectTransform>();
        [SerializeField] private Button button;
        [SerializeField] private Text text;
        [SerializeField] private Text timer;
        TweenCallback closeEvent;
        private long closeDelay = 5;
        public void Open(string item, TweenCallback onClosed)
        {
            text.text = item;
            closeEvent = onClosed;
            RectTransform.localScale = Vector3.zero;
            RectTransform.DOScale(1, 0.5f);
            button.onClick.AddListener(Close);
            Observable.Interval(TimeSpan.FromSeconds(1)).Where(value => value <= closeDelay).Subscribe(OnNext).AddTo(this);
        }

        private void OnNext(long index)
        {
            var temp = closeDelay - index;
            timer.text = temp.ToString();
            if (temp == 0)
            {
                Close();
            }
        }

        public void Close()
        {
            RectTransform.DOScale(0, 0.5f).OnComplete(() =>
            {
                closeEvent?.Invoke();
                Destroy(gameObject);
            });

        }
    }
}