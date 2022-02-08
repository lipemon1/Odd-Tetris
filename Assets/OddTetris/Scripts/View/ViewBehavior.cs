using System;
using OddTetris.Controller;
using UnityEngine;

namespace OddTetris.View
{
    public abstract class ViewBehavior : MonoBehaviour, IView
    {
        [SerializeField]
        private ViewType m_Type;
        public ViewType Type => m_Type;
        [SerializeField]
        private GameObject m_GameObject;

        [SerializeField] 
        private bool m_disableOnAwake = true;

        public virtual void OpenView()
        {
            m_GameObject.SetActive(true);
        }
        public virtual void CloseView()
        {
            m_GameObject.SetActive(false);
        }

        private void Awake()
        {
            ViewController.RegisterView(this);
            
            if(m_disableOnAwake)
                CloseView();
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (m_GameObject != null)
            {
                m_GameObject.name = $"[VIEW] - {Type.ToString()}";
            }
        }
#endif
    }   
}
