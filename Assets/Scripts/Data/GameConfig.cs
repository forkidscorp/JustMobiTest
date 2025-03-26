using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Config/GameConfig")]
public class GameConfig : ScriptableObject
{
    public int InitialCubeCount = 20;
    public List<Color> CubeColors;
}