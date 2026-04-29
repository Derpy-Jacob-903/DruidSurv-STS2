using BaseLib.Utils;
using Godot;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;

namespace DruidSurv.DruidSurvCode.Cards.TrashHeap;

public class WhiteBloon() : DruidSurvCard(1,
    CardType.Attack, CardRarity.Event,
    TargetType.Self, "WhiteBloon_CardArt")
{
    protected override HashSet<CardTag> CanonicalTags => [CardTag.Defend];

    protected override IEnumerable<DynamicVar> CanonicalVars =>
    [
        new BlockVar(9m, ValueProp.Move),
        new CardsVar(1),
        new StarsVar(1)
    ];
    protected override async Task OnPlay(
        PlayerChoiceContext context,
        CardPlay play)
    {
        await CreatureCmd.GainBlock(Owner.Creature, base.DynamicVars.Block, play);
        await PowerCmd.Apply<DrawCardsNextTurnPower>(Owner.Creature, DynamicVars.Cards.BaseValue, Owner.Creature, play.Card);
        if (Owner.PlayerCombatState != null && Owner.PlayerCombatState.Stars < 6)
        {
            await PlayerCmd.GainStars(Math.Max(6 - Owner.PlayerCombatState.Stars, 1), Owner);
        }
    }

    public override Material CreateCustomFrameMaterial => ShaderUtils.GenerateHsv(207.88f / 360f, .7f, .9f);
    
    protected override void OnUpgrade() => this.DynamicVars.Block.UpgradeValueBy(3M);
}