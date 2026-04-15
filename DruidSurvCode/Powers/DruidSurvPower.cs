using BaseLib.Abstracts;
using BaseLib.Extensions;
using DruidSurv.DruidSurvCode.Extensions;

namespace DruidSurv.DruidSurvCode.Powers;

public abstract class DruidSurvPower : CustomPowerModel
{
    //Loads from DruidSurv/images/powers/your_power.png
    public override string CustomPackedIconPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".PowerImagePath();
    public override string CustomBigIconPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".BigPowerImagePath();
}