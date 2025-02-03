namespace Runtime.Gameplay.Attachment.Tree
{
    public class AttachableTree
    {
        private readonly AttachableNode _root;
        public AttachableNode Root => _root;
        
        public AttachableTree(AttachableNode root)
        {
            _root = root;
        }
    }
}