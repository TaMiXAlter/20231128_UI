using System.Collections.Generic;
using UnityEngine;

namespace AIExhibition.UIManagement.Base
{
    public class ViewManager : MonoBehaviour
    {
        private static ViewManager _instance;
        [SerializeField] private View _startingView;
        [SerializeField] private List<View> _views = new List<View>();
        private View _currentView;
        private readonly Stack<View> _history = new Stack<View>();
        private void Awake() => _instance = this;
        private void Start()
        {
            foreach (var v in _views)
            {
                v.Initialize();
                if (v != _startingView)
                {
                    v.Hide();
                }
            }

            if (_startingView != null)
            {
                Show(_startingView);
            }

        }

        #region Static Methods
        public static T GetView<T>() where T : View
        {
            foreach (View view in _instance._views)
            {
                if (view is T tView)
                {
                    return tView;
                }
            }
            return null;
        }
        public static void AddView(View view)
        {
            if (!_instance._views.Contains(view))
            {
                _instance._views.Add(view);
            }
        }

        /// <summary>
        /// 從View lists裡面找到T类型的View并显示，如果有多個T类型的View，則顯示第一個。
        /// 主要用在你確定View lists裡面只有一個T类型的View的時候。
        /// </summary>
        /// <param name="isRemember">是否要加入紀錄以便之後可以上一頁</param>
        /// <typeparam name="T"></typeparam>
        public static void ShowFirst<T>(bool isRemember = true) where T : View
        {
            foreach (View t in _instance._views)
            {
                if (t is not T) continue;
                if (_instance._currentView != null)
                {
                    if (isRemember)
                    {
                        _instance._history.Push(_instance._currentView);
                    }
                    _instance._currentView.Hide();
                }
                _instance._currentView = t;
                _instance._currentView.Show();
                break;
            }
        }

        /// <summary>
        /// 直接顯示指定的View，不管是否在View lists裡面，並且不會有T类型的View重複的問題。
        /// </summary>
        /// <param name="view"></param>
        /// <param name="isRemember"></param>
        public static void Show(View view, bool isRemember = true)
        {
            if (_instance._currentView != null)
            {
                if (isRemember)
                {
                    _instance._history.Push(_instance._currentView);
                }
                _instance._currentView.Hide();
            }
            _instance._currentView = view;
            _instance._currentView.Show();
        }

        public static void ShowLast()
        {
            if (_instance._history.Count != 0)
            {
                Show(_instance._history.Pop(), false);
            }

        }
        #endregion

    }
}
