using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace OddTetris.View
{
    public static class ViewController
    {
        private static Dictionary<ViewType, IView> _views = new Dictionary<ViewType, IView>();

        public static void RegisterView(IView newViewItem)
        {
            if (_views.TryGetValue(newViewItem.GetViewType(), out IView alreadyRegisteredView))
                Debug.LogError("Trying to register an already registered view");
            else
                _views.Add(newViewItem.GetViewType(), newViewItem);
        }

        public static void OpenView(ViewType viewWanted, bool closeOthers = true)
        {
            if (_views.TryGetValue(viewWanted, out IView view))
                view.OpenView();
            else
                Debug.LogError($"No view found with type [{viewWanted}]");
        }

        public static void CloseView(ViewType viewToClose)
        {
            if (_views.TryGetValue(viewToClose, out IView view))
                view.CloseView();
            else
                Debug.LogError($"No view found with type [{viewToClose}]");
        }

        public static void OnSingleStart()
        {
            foreach (KeyValuePair<ViewType, IView> view in _views)
            {
                view.Value.OnSinglePlayerStart();
            }
        }
        
        public static void OnAIVersusStart()
        {
            foreach (KeyValuePair<ViewType, IView> view in _views)
            {
                view.Value.OnVersusAIStart();
            }
        }
    }
}

