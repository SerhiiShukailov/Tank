namespace Tank.Contracts.Project.Script.Contracts.Capabilities {
  public interface IWeapon {
    void Fire();

    bool CanFire { get; }
  }
}