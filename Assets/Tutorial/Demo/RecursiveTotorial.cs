using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;

public class RecursiveTotorial : MonoBehaviour
{
    private void Start()
    {
        OpenPanels(new string[] { "0", "1", "2", "3" });
    }

    private void OpenPanels(string[] data)
    {
        List<Action> panels = new List<Action>();
        int index = 0;
        foreach (var item in data)
        {
            Action temp = () => OpenPanel(item, OnNextPanel);
            panels.Add(temp);
        }
        OnNextPanel();
        void OnNextPanel()
        {
            if (index >= panels.Count)
            {
                return;
            }
            panels[index++]?.Invoke();
        }
    }

    private void OpenPanel(string data, TweenCallback onClsoe)
    {
        Debug.Log(data);
        transform.localScale = Vector3.zero;
        Sequence sequence = DOTween.Sequence()
         .Append(transform.DOScale(Vector3.one, 0.5f))
         .Append(transform.DOScale(Vector3.zero, 0.5f))
         .AppendCallback(onClsoe);
    }
}



