using BaseLib.Abstracts;
using BaseLib.Utils;
using DruidSurv.DruidSurvCode.Character;

namespace DruidSurv.DruidSurvCode.Potions;

[Pool(typeof(DruidSurvPotionPool))]
public abstract class DruidSurvPotion : CustomPotionModel;