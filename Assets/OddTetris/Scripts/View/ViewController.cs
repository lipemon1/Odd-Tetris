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
        
        public static void plusMinus(List<int> arr)
        {
            Console.WriteLine("Have Amount of " + arr.Count);
            arr.Sort();
        
            int[] numbersToSum = new int[4];
            int minSum = 0;
            int maxSum = 0;
        
            for(int i = 0; i < 4; i++)
            {
                numbersToSum[i] = arr[i];
            }
        
            minSum = numbersToSum.Sum();
        
            numbersToSum = new int[4];
            int startIndex = arr.Count - 1;
            int endIndex = startIndex - 2;
        
            Console.WriteLine("Start " + startIndex + " with End " + endIndex);
            for(int i = 4; i > 1; i--)
            {
                Console.WriteLine("Passaing index " + i);
                numbersToSum[i] = arr[i];
            }
        
            maxSum = numbersToSum.Sum();
        
            Console.WriteLine(minSum + " " + maxSum);   
        }
    }
}

