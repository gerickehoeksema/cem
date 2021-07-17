namespace CEM.DAL.Entities
{
    public class Image : AuditableEntity
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string Size { get; set; }
        public byte[] Data { get; set; }
    }
}
