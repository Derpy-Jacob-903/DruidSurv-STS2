using BaseLib.Abstracts;
using BaseLib.Utils;
using DruidSurv.DruidSurvCode.Character;
using DruidSurv.DruidSurvCode.Extensions;
using MegaCrit.Sts2.Core.Entities.Cards;

namespace DruidSurv.DruidSurvCode.Cards;

[Pool(typeof(DruidSurvCardPool))]
public abstract class DruidSurvCard(int cost, CardType type, CardRarity rarity, TargetType target, string? cardArt = null) :
    CustomCardModel(cost, type, rarity, target)
{
    //Image size:
    //Normal art: 1000x760 (Using 500x380 should also work, it will simply be scaled.)
    //Full art: 606x852
    public override string CustomPortraitPath => cardArt == null ? $"NoArt.png".BigCardImagePath() : (cardArt+".png").BigCardImagePath();

    //Smaller variants of card images for efficiency:
    //Smaller variant of fullart: 250x350
    //Smaller variant of normalart: 250x190

    //Uses card_portraits/card_name.png as image path. These should be smaller images.
    public override string PortraitPath => cardArt == null ? $"NoArt.png".CardImagePath() : (cardArt+".png").CardImagePath();
    public override string BetaPortraitPath => cardArt == null ? $"beta/NoArt.png".CardImagePath() : ("beta/"+cardArt+"png").CardImagePath();
}