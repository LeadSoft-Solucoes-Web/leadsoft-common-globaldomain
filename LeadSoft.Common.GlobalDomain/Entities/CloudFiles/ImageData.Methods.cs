using System.Drawing;
using System.Drawing.Imaging;

using Amazon.S3;

using LeadSoft.Adapter.AWS;
using LeadSoft.Common.Library.Extensions;

using Image = System.Drawing.Image;

namespace LeadSoft.Common.GlobalDomain.Entities.CloudFiles
{
    /// <summary>
    /// Image Data methods
    /// 
    /// TODO: Extending a future Interface feature, methods as delete, resize, download, and other stuff must be developed here
    /// </summary>
    public partial class ImageData
    {
        /// <summary>
        /// base constructor
        /// </summary>
        public ImageData()
        {
        }

        /// <summary>
        /// base constructor
        /// </summary>
        public ImageData(string aTitle, string aImageUrl)
        {
            Title = aTitle.IsSomething() ? aTitle : Id.GetString();
            Description = aTitle;
            Key = aImageUrl;
            Url = new(aImageUrl);
            Bytes = 0;
            ThumbnailKey = aImageUrl;
            ThumbnailUrl = new(aImageUrl);
        }

        /// <summary>
        /// Async Method to Upload Image and set Url and Thumbnail Url for ImageData
        /// </summary>
        /// <param name="aAmazonS3">AmazonS3 instance</param>
        /// <param name="aFileStream">Image File Stream</param>
        /// <param name="aFullFileName">Full File Name</param>
        /// <param name="aAccessType">S3 Access Type</param>
        /// <param name="aStorageType">S3 storage Type</param>
        /// <param name="aCreateThumbnail">Optional Create or not Thumbnail flag. Default: true.</param>
        public async Task<ImageData> UploadAsync(AmazonS3 aAmazonS3, Stream aFileStream, string aFullFileName, S3CannedACL aAccessType, S3StorageClass aStorageType, string aTitle = "", bool aCreateThumbnail = true, int aThumbX = 256, int aThumbY = 256)
        {
            Title = aTitle.IsSomething() ? aTitle : Id.GetString();
            Description = aFullFileName;
            Key = aFullFileName;
            Bytes = (int)aFileStream.Length;

            if (aCreateThumbnail)
            {
                string thumbnailFileName = aFullFileName.Replace(".", "_thumbnail.");

                Stream aThumbCopy = new MemoryStream();
                await aFileStream.Reset().CopyToAsync(aThumbCopy);

                ThumbnailKey = thumbnailFileName;
                ThumbnailUrl = await aAmazonS3.StoreFileAsync(CreateThumbnail(Image.FromStream(aThumbCopy.Reset()), aThumbX, aThumbY),
                                                              thumbnailFileName, aAccessType, aStorageType);
            }

            Url = await aAmazonS3.StoreFileAsync(aFileStream.Reset(), aFullFileName, aAccessType, aStorageType);

            return this;
        }

        /// <summary>
        /// Sets a new Id to image
        /// </summary>
        /// <param name="aId"></param>
        /// <returns></returns>
        public ImageData SetId(Guid aId)
        {
            Id = aId;
            return this;
        }

        public ImageData ProvideUrl(AmazonS3 aAmazonS3)
        {
            if (Key.IsSomething())
                Url = aAmazonS3.GetUrl(Key);

            if (ThumbnailKey.IsSomething())
                ThumbnailUrl = aAmazonS3.GetUrl(ThumbnailKey);

            return this;
        }

        public async Task<ImageData> DeleteContentAsync(AmazonS3 aAmazonS3)
        {
            if (Key.IsSomething())
            {
                await aAmazonS3.DeleteAsync(Key);
                Key = string.Empty;
            }

            if (ThumbnailKey.IsSomething())
            {
                await aAmazonS3.DeleteAsync(ThumbnailKey);
                ThumbnailKey = string.Empty;
            }

            return this;
        }

        /// <summary>
        /// Method to create resized Thumbnail from Image
        /// </summary>
        /// <param name="aImage">Image</param>
        /// <param name="aX">Image thumbnail X axis pixels</param>
        /// <param name="aY">Image thumbnail Y axis pixels</param>
        /// <returns>Stream</returns>
        public static Stream CreateThumbnail(Image aImage, int aX = 256, int aY = 256)
        {
            Bitmap resized = new(ScaleImage(aImage, aX, aY));

            MemoryStream imageStream = new();
            resized.Save(imageStream, ImageFormat.Png);

            return imageStream.Reset();
        }

        /// <summary>
        /// Method to create resized image stream
        /// </summary>
        /// <param name="aFile">Image Stream</param>
        /// <param name="aX">Image thumbnail X axis pixels</param>
        /// <param name="aY">Image thumbnail Y axis pixels</param>
        /// <returns>Stream</returns>
        public static Stream Resize(Stream aFile, int aX = 1024, int aY = 1024)
        {
            Bitmap resized = new(ScaleImage(Image.FromStream(aFile), aX, aY));

            MemoryStream imageStream = new();
            resized.Save(imageStream, ImageFormat.Png);

            return imageStream.Reset();
        }

        /// <summary>
        /// Auxiliar Method to resize image
        /// </summary>
        /// <param name="image"></param>
        /// <param name="maxWidth"></param>
        /// <param name="maxHeight"></param>
        /// <returns></returns>
        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            double ratioX = (double)maxWidth / image.Width;
            double ratioY = (double)maxHeight / image.Height;
            double ratio = Math.Min(ratioX, ratioY);

            int newWidth = (int)(image.Width * ratio);
            int newHeight = (int)(image.Height * ratio);

            Bitmap newImage = new(newWidth, newHeight);

            using Graphics graphics = Graphics.FromImage(newImage);

            graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }
    }
}