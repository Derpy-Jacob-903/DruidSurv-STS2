using BaseLib.Utils;
using DruidSurv.DruidSurvCode.Relics;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Runs;

namespace DruidSurv.DruidSurvCode.Relics;

public class DruidStarter() : DruidSurvRelic
{
    public override RelicRarity Rarity =>
        RelicRarity.Starter;
}