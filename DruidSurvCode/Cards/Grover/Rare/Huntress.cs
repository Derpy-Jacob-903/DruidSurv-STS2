using HarmonyLib;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Potions;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.Rooms;
using MegaCrit.Sts2.Core.ValueProps;

namespace DruidSurv.DruidSurvCode.Cards.Grover.Rare;

public class BloonsdayDevice() : DruidSurvCard(6,
    CardType.Attack, CardRarity.Rare,
    TargetType.AllEnemies, "BloonsdayDevice_CardArt")
{
    
    protected override HashSet<CardTag> CanonicalTags => [CardTag.Strike];

    protected override IEnumerable<DynamicVar> CanonicalVars =>
    [
        new DamageVar(50m, ValueProp.Move),
        new DynamicVar("Poison", 10)
    ];
    protected override async Task OnPlay(
        PlayerChoiceContext context,
        CardPlay play)
    {
        if (CombatState?.RunState?.CurrentRoom is not CombatRoom combatRoom) return;
        await DamageCmd.Attack(base.DynamicVars.Damage.BaseValue)
            .FromCard(this).TargetingAllOpponents(CombatState)
            .WithHitFx("vfx/vfx_attack_slash", null, "blunt_attack.mp3")
            .Execute(context);
        await PowerCmd.Apply<PoisonPower>((IEnumerable<Creature>) CombatState.HittableEnemies, DynamicVars["Poison"].BaseValue, Owner.Creature, this);
        
        await DamageCmd.Attack(base.DynamicVars.Damage.BaseValue)
            .FromCard(this).Targeting(Owner.Creature)
            .WithHitFx("vfx/vfx_attack_slash", null, "blunt_attack.mp3")
            .Execute(context);
        await PowerCmd.Apply<PoisonPower>(this.Owner.Creature, DynamicVars["Poison"].BaseValue, Owner.Creature, this);
        if (!combatRoom.Enemies.Any(e => e.IsAlive))
        {
            await CreatureCmd.Heal(this.Owner.Creature, 1);
        }
    }

    /*private bool _shouldDie = false;

    public override bool ShouldDie(Creature creature) => creature != this.Owner.Creature && _shouldDie;

    public override async Task AfterPreventingDeath(Creature creature)
    {
        if (_shouldDie == true) { return; }
        if (CombatState?.RunState?.CurrentRoom is not CombatRoom combatRoom) { return; }

        this.Owner.Creature.ShowsInfiniteHp = true;
        await CreatureCmd.Heal(this.Owner.Creature, 1);
        this.ExhaustOnNextPlay = true;
        await this.OnPlay(new ThrowingPlayerChoiceContext(), null!);
        _shouldDie = true;
        this.Owner.Creature.ShowsInfiniteHp = false;
    }*/

    protected override void OnUpgrade() => this.AddKeyword(CardKeyword.Retain);
}