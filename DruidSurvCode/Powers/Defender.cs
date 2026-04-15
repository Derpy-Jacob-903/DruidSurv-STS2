using BaseLib.Utils;
using DruidSurv.DruidSurvCode.Relics;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;

namespace DruidSurv.DruidSurvCode.Powers;

public class DefenderPower() : DruidSurvPower
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.None;
    
    public override async Task BeforeDamageReceived(
        PlayerChoiceContext choiceContext,
        Creature target,
        Decimal amount,
        ValueProp props,
        Creature dealer,
        CardModel cardSource)
    {
        if (target != this.Owner || dealer == null || !props.IsPoweredAttack() && !(cardSource is Omnislice))
            return;
        this.Flash();
        IEnumerable<DamageResult> damageResults = await CreatureCmd.Damage(choiceContext, dealer, (Decimal) this.Amount, ValueProp.Unpowered | ValueProp.SkipHurtAnim, this.Owner, (CardModel) null);
        if (dealer.IsDead)
        {
            amount = 0;
        }
        await PowerCmd.Remove(this);
    }
}