using BaseLib.Abstracts;
using Godot;

namespace DruidSurv.DruidSurvCode.Character;

public class DruidSurvCardPool : CustomCardPoolModel
{
    public override string Title => DruidSurv.CharacterId; //This is not a display name.
    public override string EnergyColorName => DruidSurv.CharacterId;

    /* These HSV values will determine the color of your card back.
    They are applied as a shader onto an already colored image,
    so it may take some experimentation to find a color you like.
    Generally they should be values between 0 and 1. */
    public override float H => DruidSurv.Color.H; //Hue; changes the color.
    public override float S => 0.6f; //Saturation
    public override float V => 0.9f; //Brightness

    //Alternatively, leave these values at 1 and provide a custom frame image.
    /*public override Texture2D CustomFrame(CustomCardModel card)
    {
        //This will attempt to load DruidSurv/images/cards/frame.png
        return PreloadManager.Cache.GetTexture2D("cards/frame.png".ImagePath());
    }*/
    
    public override string BigEnergyIconPath => "res://DruidSurv/images/charui/druid_energy.png";
    public override string TextEnergyIconPath => "res://DruidSurv/images/charui/druid_energy.png";

    //Color of small card icons
    public override Color DeckEntryCardColor => new("e67645");

    public override bool IsColorless => false;
}