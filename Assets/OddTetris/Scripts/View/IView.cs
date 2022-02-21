namespace OddTetris.View
{
    public interface IView
    {
        void OpenView();
        void CloseView();
        ViewType GetViewType();
        void OnSinglePlayerStart();
        void OnVersusAIStart();
    }   
}
