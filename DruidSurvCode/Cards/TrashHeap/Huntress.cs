using BaseLib.Utils;
using DruidSurv.DruidSurvCode.Cards;
using Godot;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;

namespace DruidSurv.DruidSurvCode.Cards;

public class Huntress() : DruidSurvCard(1,
    CardType.Attack, CardRarity.Event,
    TargetType.AnyEnemy, "Huntress")
{
    protected override HashSet<CardTag> CanonicalTags => new HashSet<CardTag> { CardTag.Strike };

    protected override IEnumerable<DynamicVar> CanonicalVars =>
        new DynamicVar[]
        {
            new DamageVar(9m, ValueProp.Move),
            new CardsVar(1)
        };
    protected override async Task OnPlay(
        PlayerChoiceContext context,
        CardPlay play)
    {
        await DamageCmd.Attack(base.DynamicVars.Damage.BaseValue)
            .FromCard(this).Targeting(play.Target)
            .WithHitFx("vfx/vfx_attack_slash", null, "blunt_attack.mp3")
            .Execute(context);
        await PowerCmd.Apply<DrawCardsNextTurnPower>(Owner.Creature, DynamicVars.Cards.BaseValue, Owner.Creature, play.Card);
    }

    public override Material CreateCustomFrameMaterial => ShaderUtils.GenerateHsv(8.1f / 360f, .7f, 1f);

    protected override void OnUpgrade()
    {

    }
}