namespace Runtime.Gameplay.Attachment
{
    public interface IAttachable
    {
        bool IsAttached { get; set; }
        AttachZone AttachZone { get; }
    }
}