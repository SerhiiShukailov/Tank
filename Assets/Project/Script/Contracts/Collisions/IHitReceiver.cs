namespace Tank.Contracts.Project.Script.Contracts.Collisions {
  public interface IHitReceiver {
    void OnHit (in HitInfo hit);
  }
}