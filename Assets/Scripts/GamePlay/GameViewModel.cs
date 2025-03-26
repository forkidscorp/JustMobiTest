public class GameViewModel
{
    public GameModel Model { get; private set; }

    public GameViewModel(GameModel model)
    {
        Model = model;
    }
}
