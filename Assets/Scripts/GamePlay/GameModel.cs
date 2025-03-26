using UniRx;
using UnityEngine;

public class GameModel
{
    public ReactiveProperty<int> CubeCount { get; private set; } = new ReactiveProperty<int>(0);
    public ReactiveCollection<Color> CubeColors { get; private set; } = new ReactiveCollection<Color>();

    public void Initialize(GameConfig config)
    {
        CubeCount.Value = config.InitialCubeCount;
        CubeColors.Clear();
        foreach (var color in config.CubeColors)
        {
            CubeColors.Add(color);
        }
    }
}
