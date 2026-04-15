using System.Diagnostics.CodeAnalysis;
using DruidSurv.DruidSurvCode.Cards;
using DruidSurv.DruidSurvCode.Cards.TrashHeap;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Events;

namespace DruidSurv.DruidSurvCode.Character;

[HarmonyPatch(typeof(ColorfulPhilosophers))]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public static class ColorfulPhilosophersPatch
{
    [HarmonyPatch("CardPoolColorOrder", MethodType.Getter)]
    [HarmonyPostfix]
    public static void Postfix(ref IEnumerable<CardPoolModel> __result)
    {
        __result = __result.Append(ModelDb.CardPool<DruidSurvCardPool>());
    }
}

[HarmonyPatch(typeof(TrashHeap))]
public static class TrashHeapPatch
{
    [HarmonyPatch("Cards", MethodType.Getter)]
    [HarmonyPostfix]
    public static void Postfix(ref CardModel[] __result)
    {
        __result = __result.AddToArray(ModelDb.Card<Huntress>());
        __result = __result.AddToArray(ModelDb.Card<WhiteBloon>());
        __result = __result.AddToArray(ModelDb.Card<DefendTheBreach>());
    }
}