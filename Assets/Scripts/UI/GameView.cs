using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    [SerializeField] private Text _cubeCountText;
    private GameViewModel _viewModel;

    public void Initialize(GameViewModel vm)
    {
        _viewModel = vm;
        _viewModel.Model.CubeCount.Subscribe(UpdateCubeCount).AddTo(this);
    }

    private void UpdateCubeCount(int count)
    {
        _cubeCountText.text = "Cubes: " + count;
    }
}
