using UnityEngine;

namespace OddTetris.View
{
    public abstract class ViewBehavior : MonoBehaviour, IView
    {
        [SerializeField]
        private ViewType m_Type;
        private ViewType Type => m_Type;
        [SerializeField]
        private GameObject m_GameObject;

        [SerializeField] 
        private bool m_disableOnAwake = true;

        #region Monobehavior

        private void Awake()
        {
            ViewController.RegisterView(this);
            
            if(m_disableOnAwake)
                CloseView();
        }

        #endregion

        #region IVIEW

        public virtual void OpenView()
        {
            m_GameObject.SetActive(true);
            OnViewOpened();
        }
        public virtual void CloseView()
        {
            m_GameObject.SetActive(false);
            OnViewClosed();
        }
        
        protected virtual void OnViewOpened() { }
        protected virtual void OnViewClosed() { }

        public ViewType GetViewType()
        {
            return Type;
        }

        #endregion

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
