namespace AlRayan.Settings
{

    public class ImageConverter
    {
        public static byte[] ImageToByteArray(string imagePath)
        {
            try
            {
                // Read the image file into a byte array
                using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    byte[] imageBytes = new byte[fs.Length];
                    fs.Read(imageBytes, 0, imageBytes.Length);
                    return imageBytes;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error converting image to byte array: {ex.Message}");
                return null;
            }
        }

    }
}
