namespace AlRayan.Settings
{
    public static class FileSettings
    {
        public const string FilePath = "/assets/image/";

        public const string AllowedExtentions = ".jpg,.jpeg,.png,.jfif";
        public const int MaxFileSizeInMB = 1;
        public const int MaxFileSizeInBytes = MaxFileSizeInMB *1024*1024;
    }
}
