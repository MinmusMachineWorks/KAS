// Kerbal Attachment System
// Author: igor.zavoychinskiy@gmail.com
// License: Public Domain

using System.Linq;
using KASAPIv2;
using KSPDev.GUIUtils;
using KSPDev.PartUtils;

// ReSharper disable once CheckNamespace
namespace KAS {

/// <summary>
/// Exposes a single custom action-group control to break an active link on parts that host multiple
/// <see cref="KASLinkTargetBase"/> modules (e.g. JS-1 joint socket).
/// </summary>
// Next localization ID: #kasLOC_15001.
// ReSharper disable once InconsistentNaming
public sealed class KASModuleSocketDisconnect : AbstractPartModule {

  /// <summary>Breaks the active KAS link whose target peer lives on this part.</summary>
  /// <include file="../SpecialDocTags.xml" path="Tags/KspAction/*"/>
  [KSPAction(null)]
  [LocalizableItem(
      tag = "#kasLOC_15000",
      defaultTemplate = "Disconnect",
      description = "Name of the custom action that breaks the active KAS link from the joint socket.")]
  public void DisconnectLinkAction(KSPActionParam unused) {
    var target = part.Modules.OfType<ILinkTarget>().FirstOrDefault(t => t.isLinked);
    target?.linkSource?.BreakCurrentLink(LinkActorType.Player);
  }

  /// <inheritdoc/>
  public override void OnUpdate() {
    base.OnUpdate();
    if (!HighLogic.LoadedSceneIsFlight) {
      return;
    }
    var ba = PartModuleUtils.GetAction(this, DisconnectLinkAction);
    if (ba != null) {
      ba.active = part.Modules.OfType<ILinkTarget>().Any(t => t.isLinked);
    }
  }
}

}  // namespace
