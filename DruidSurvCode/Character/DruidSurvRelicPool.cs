using BaseLib.Abstracts;
using Godot;

namespace DruidSurv.DruidSurvCode.Character;

public class DruidSurvRelicPool : CustomRelicPoolModel
{
    public override string EnergyColorName => DruidSurv.CharacterId;
    public override Color LabOutlineColor => DruidSurv.Color;
}