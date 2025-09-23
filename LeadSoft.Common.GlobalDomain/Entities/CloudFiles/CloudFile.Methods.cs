using Amazon.S3;

using LeadSoft.Adapter.AWS;
using LeadSoft.Common.Library.Extensions;

using static LeadSoft.Common.Library.Enumerators.Enums;

namespace LeadSoft.Common.GlobalDomain.Entities.CloudFiles;

/// <summary>
/// Generic entity that represents a Cloud File
/// </summary>
public partial class CloudFile
{
    /// <summary>
    /// Empty Constructor
    /// </summary>
    public CloudFile()
    {
    }

    /// <summary>
    /// Main Constructor
    /// </summary>
    /// <remarks>
    /// Use File extension to set the mime type on file. To get that, there is a function to find the correct enum.
    /// If the file extension doesn't exist, create a new enum! Or request it on developers e-mail.
    ///     Enums.GetByDescription FileExtension (fileType)
    /// </remarks>
    /// <param name="bucket">Bucket name</param>
    /// <param name="aFileExtension">File mime type in FileExtension.</param>
    /// <param name="aKey">cloud key</param>
    /// <param name="aSize">file size in bytes</param>
    public CloudFile(string bucket, FileExtension aFileExtension, string aKey, long aSize)
    {
        Bucket = bucket;
        FileExtension = aFileExtension;
        Key = aKey;
        Size = aSize;
        Enable();
    }

    /// <summary>
    /// base constructor
    /// </summary>
    public CloudFile(string aTitle, string aImageUrl)
    {
        Title = aTitle.IsSomething() ? aTitle : Id.GetString();
        Description = aTitle;
        Key = aImageUrl;
        Url = new(aImageUrl);
        Size = 0;
    }

    /// <summary>
    /// Async Method to Upload Image and set Url and Thumbnail Url for ImageData
    /// </summary>
    /// <param name="aAmazonS3">AmazonS3 instance</param>
    /// <param name="aFileStream">Image File Stream</param>
    /// <param name="aFullFileName">Full File Name</param>
    /// <param name="aAccessType">S3 Access Type</param>
    /// <param name="aStorageType">S3 storage Type</param>
    public async Task<CloudFile> UploadAsync(AmazonS3 aAmazonS3, Stream aFileStream, string aFullFileName, S3CannedACL aAccessType, S3StorageClass aStorageType, string aTitle = "")
    {
        Title = aTitle.IsSomething() ? aTitle : Id.GetString();
        Description = aFullFileName;
        Key = aFullFileName;
        Size = (int)aFileStream.Length;
        Url = await aAmazonS3.StoreFileAsync(aFileStream.Reset(), aFullFileName, aAccessType, aStorageType);

        return this;
    }

    /// <summary>
    /// Method that provides the permanent URL from a file on Amazon S3 and sets it into class
    /// </summary>
    /// <param name="aAmazonS3">Amazon S3 instance</param>
    /// <returns>Self for chain call.</returns>
    public CloudFile ProvideUrl(AmazonS3 aAmazonS3)
    {
        if (Key.IsSomething())
            Url = aAmazonS3.GetUrl(Key);

        return this;
    }

    /// <summary>
    /// Method that provides the temporary URL from a file on Amazon S3 and sets it into class
    /// </summary>
    /// <param name="aAmazonS3">Amazon S3 instance</param>
    /// <param name="aSeconds">Seconds to expire</param>
    /// <returns>Self for chain call.</returns>
    public CloudFile ProvideTemporaryUrl(AmazonS3 aAmazonS3, int aSeconds)
    {
        if (Key.IsSomething())
            Url = aAmazonS3.GetTemporaryUrl(Key, aSeconds);

        return this;
    }

    /// <summary>
    /// Method that deletes on S3 the file and clear class
    /// </summary>
    /// <param name="aAmazonS3">Amazon S3 instance</param>
    /// <returns>Self for chain call.</returns>
    public async Task<CloudFile> DeleteContentAsync(AmazonS3 aAmazonS3)
    {
        if (Key.IsSomething())
        {
            await aAmazonS3.DeleteAsync(Key);
            Key = string.Empty;
        }

        return this;
    }

    /// <summary>
    /// Clear all properties
    /// </summary>
    /// <returns>Self for chain call.</returns>
    public CloudFile Clear()
    {
        ClearId();
        Bucket = string.Empty;
        Key = string.Empty;
        Size = long.MinValue;
        FileExtension = FileExtension.None;
        Url = null;

        return this;
    }
}
