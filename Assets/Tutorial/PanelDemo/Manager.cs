using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Panel
{
    public class Manager : MonoBehaviour
    {
        [SerializeField] private Panel panelPrefab;
        // Start is called before the first frame update
        void Start()
        {
            string[] data = new string[] { "0", "1", "2" };
            OpenPanels(data);
        }

        private void OpenPanels(string[] data)
        {
            List<Action> actions = new List<Action>();
            var count = 0;
            foreach (var item in data)
            {
                Action action = () => OpenPanels(item, OnNext);
                actions.Add(action);
            }
            OnNext();
            void OnNext()
            {
                if (count >= data.Length)
                {
                    return;
                }
                actions[count++]?.Invoke();
            }
        }

        private void OpenPanels(string item, TweenCallback onNext)
        {
            var go = Instantiate(panelPrefab, transform);
            go.Open(item, onNext);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}