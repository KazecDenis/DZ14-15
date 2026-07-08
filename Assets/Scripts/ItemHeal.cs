

public class ItemHeal : Item
{
   private string _name = "Health";

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
