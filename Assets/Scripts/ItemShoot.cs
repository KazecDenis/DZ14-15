

public class ItemShoot : Item
{
   private string _name = "Shoot";

    public override void Initialize(string nameItem)
    {
        base.Initialize(nameItem);
        NameItem = _name;
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void OnTransformParentChanged()
    {
        base.OnTransformParentChanged();
    }
}
