namespace HTMLFileContent.Repository.HTMLFileContentClasses
{
    public interface IContentItem
    {
        string Content { get; set; }
        int ContentItemID { get; set; }
        ContentType ContentType { get; set; }
    }
}