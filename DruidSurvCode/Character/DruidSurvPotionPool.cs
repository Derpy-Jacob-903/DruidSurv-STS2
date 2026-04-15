using BaseLib.Abstracts;
using Godot;

namespace DruidSurv.DruidSurvCode.Character;

public class DruidSurvPotionPool : CustomPotionPoolModel
{
    public override string EnergyColorName => DruidSurv.CharacterId;
    public override Color LabOutlineColor => DruidSurv.Color;
}