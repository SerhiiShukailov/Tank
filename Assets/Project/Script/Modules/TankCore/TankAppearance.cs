using UnityEngine;

namespace Tank.Modules.TankCore.Project.Script.Modules.TankCore {
  public class TankAppearance : MonoBehaviour {
    [SerializeField]
    private Renderer [] _renderers;

    public void Apply (Material material) {
      if(material == null) {
        return;
      }

      foreach(Renderer target in _renderers) {
        target.sharedMaterial = material;
      }
    }
  }
}