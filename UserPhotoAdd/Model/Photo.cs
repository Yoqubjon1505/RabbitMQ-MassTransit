namespace UserPhotoAdd.Model
{
    public class Photo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IFormFile FilePath { get; set; }
        public string Description { get; set; }
        public byte[] OriginalPhoto { get; set; }
        public byte[] ProcessedPhoto { get; set; }
        public bool IsProcessed { get; set; }


    }
}
