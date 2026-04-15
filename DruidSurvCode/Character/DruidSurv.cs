using BaseLib.Abstracts;
using DruidSurv.DruidSurvCode.Cards;
using DruidSurv.DruidSurvCode.Cards.Grover.Rare;
using DruidSurv.DruidSurvCode.Cards.Grover.Starter;
using DruidSurv.DruidSurvCode.Cards.TrashHeap;
using DruidSurv.DruidSurvCode.Extensions;
using Godot;
using MegaCrit.Sts2.Core.Entities.Characters;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.Models.Relics;

namespace DruidSurv.DruidSurvCode.Character;

public class DruidSurv : PlaceholderCharacterModel
{
    public const string CharacterId = "DruidSurv";

    public static readonly Color Color = new("974d2c");

    public override Color NameColor => Color;
    public override CharacterGender Gender => CharacterGender.Masculine;
    public override int StartingHp => 77;

    public override IEnumerable<CardModel> StartingDeck =>
    [
        ModelDb.Card<StrikeDruid>(),
        ModelDb.Card<StrikeDruid>(),
        ModelDb.Card<StrikeDruid>(),
        ModelDb.Card<StrikeDruid>(),
        ModelDb.Card<HeartOfThunder>(),
        ModelDb.Card<DefendDruid>(),
        ModelDb.Card<DefendDruid>(),
        ModelDb.Card<DefendDruid>(),
        ModelDb.Card<DefendDruid>(),
        ModelDb.Card<Defender>()
    ];

    public override IReadOnlyList<RelicModel> StartingRelics =>
    [
        ModelDb.Relic<BurningBlood>()
    ];

    public override CardPoolModel CardPool => ModelDb.CardPool<DruidSurvCardPool>();
    public override RelicPoolModel RelicPool => ModelDb.RelicPool<DruidSurvRelicPool>();
    public override PotionPoolModel PotionPool => ModelDb.PotionPool<DruidSurvPotionPool>();

    /*  PlaceholderCharacterModel will utilize placeholder basegame assets for most of your character assets until you
        override all the other methods that define those assets.
        These are just some of the simplest assets, given some placeholders to differentiate your character with.
        You don't have to, but you're suggested to rename these images. */
    public override string CustomIconTexturePath => "character_icon_char_name.png".CharacterUiPath();
    public override string CustomCharacterSelectIconPath => "char_select_char_name.png".CharacterUiPath();
    public override string CustomCharacterSelectLockedIconPath => "char_select_char_name_locked.png".CharacterUiPath();
    public override string CustomMapMarkerPath => "map_marker_char_name.png".CharacterUiPath();
}