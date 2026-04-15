using BaseLib.Abstracts;
using BaseLib.Utils;
using DruidSurv.DruidSurvCode.Character;
using DruidSurv.DruidSurvCode.Extensions;

namespace DruidSurv.DruidSurvCode.Relics;

[Pool(typeof(DruidSurvRelicPool))]
public abstract class DruidSurvRelic : CustomRelicModel
{
    public override string PackedIconPath => $"{Id.Entry.ToLowerInvariant()}.png".RelicImagePath();
    protected override string PackedIconOutlinePath => $"{Id.Entry.ToLowerInvariant()}_outline.png".RelicImagePath();
    protected override string BigIconPath => $"{Id.Entry.ToLowerInvariant()}.png".BigRelicImagePath();
}