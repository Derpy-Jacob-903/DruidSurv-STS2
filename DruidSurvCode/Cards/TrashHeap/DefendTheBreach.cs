using BaseLib.Utils;
using DruidSurv.DruidSurvCode.Cards;
using Godot;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;

namespace DruidSurv.DruidSurvCode.Cards.TrashHeap;
public class DefendTheBreach() : DruidSurvCard(1,
    CardType.Skill, CardRarity.Event,
    TargetType.Self, "DefendTheBreach_CardArt")
{
    protected override IEnumerable<DynamicVar> CanonicalVars =>
    [
        new PowerVar<StrengthPower>(2M)
    ];
    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        if (Owner.PlayerCombatState != null && Owner.PlayerCombatState.Energy == 0)
        {
            await PowerCmd.Apply<StrengthPower>(Owner.Creature, DynamicVars.Strength.BaseValue, Owner.Creature, this);
        }
        else
        {
            await PowerCmd.Apply<FlexPotionPower>(Owner.Creature, DynamicVars.Strength.BaseValue, Owner.Creature, this);
        }
    }

    protected override void OnUpgrade() => this.DynamicVars["StrengthPower"].UpgradeValueBy(1M);
    
    public override Material CreateCustomFrameMaterial => ShaderUtils.GenerateHsv(269.2f / 360f, .7f, 1f);
}