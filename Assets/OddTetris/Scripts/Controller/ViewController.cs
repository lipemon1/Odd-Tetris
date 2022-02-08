using System.Collections.Generic;
using OddTetris.View;
using UnityEngine;

namespace OddTetris.Controller
{
    public static class ViewController
    {
        private static HashSet<IView> _Views = new HashSet<IView>();

        public static void RegisterView(IView newViewItem)
        {
            if (_Views.Contains(newViewItem))
                Debug.LogError("Trying to register an already registered view");
            else
                _Views.Add(newViewItem);
        }
    }
}

