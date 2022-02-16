using OddTetris.GameLoop;

public abstract class GameMode
{
    public abstract void PrepareMode();

    protected void OnPrepareEnd()
    {

    }
    public abstract void EndMode();
}
