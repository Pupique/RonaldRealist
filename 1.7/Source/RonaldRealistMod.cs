using System.Reflection;
using HarmonyLib;
using Verse;

namespace RonaldRealist;

public sealed class RonaldRealistMod : Mod
{
  public RonaldRealistMod(ModContentPack content) : base(content)
  {
    var harmony = new Harmony("Pupique.RonaldRealist");
    Log.Message("[Ronald Realist] Applying Harmony patches...");
    harmony.PatchAll(Assembly.GetExecutingAssembly());
    Log.Message("[Ronald Realist] Harmony patches applied.");
  }
}
