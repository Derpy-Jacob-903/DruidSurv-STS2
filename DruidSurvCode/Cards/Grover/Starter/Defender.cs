using DruidSurv.DruidSurvCode.Powers;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Relics;
using MegaCrit.Sts2.Core.ValueProps;

namespace DruidSurv.DruidSurvCode.Cards.Grover.Starter;

public class Defender() : DruidSurvCard(2,
    CardType.Skill, CardRarity.Basic,
    TargetType.Self, "Druid")
{
    protected override HashSet<CardTag> CanonicalTags => [CardTag.Defend];

    protected override IEnumerable<DynamicVar> CanonicalVars =>
    [
        new BlockVar(6m, ValueProp.Move),
        new DynamicVar("Defender", 6m)
    ];
    protected override async Task OnPlay(
        PlayerChoiceContext context,
        CardPlay play)
    {
        await CreatureCmd.GainBlock(Owner.Creature, base.DynamicVars.Block, play);
        await PowerCmd.Apply<DefenderPower>(Owner.Creature, base.DynamicVars["Defender"].BaseValue, Owner.Creature, this);
    }

    protected override void OnUpgrade()
    {

    }
}