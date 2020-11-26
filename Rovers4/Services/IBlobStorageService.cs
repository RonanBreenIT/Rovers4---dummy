﻿using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Rovers4.Services
{
    public interface IBlobStorageService
    {
        string UploadFileToBlob(string strFileName, byte[] fileData, string fileMimeType);
        void DeleteBlobData(string fileUrl);
        Task<string> UploadFileToBlobAsync(string strFileName, byte[] fileData, string fileMimeType);
    }

    public class BlobStorageService : IBlobStorageService
    {
        private readonly IConfiguration _configuration;

        public BlobStorageService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string UploadFileToBlob(string strFileName, byte[] fileData, string fileMimeType)
        {
            try
            {
                var _task = Task.Run(() => this.UploadFileToBlobAsync(strFileName, fileData, fileMimeType));
                _task.Wait();
                string fileUrl = _task.Result;
                return fileUrl;
            }
            catch (TargetInvocationException tiex)
            {
                throw tiex.InnerException;
            }
        }

        public async void DeleteBlobData(string fileUrl)
        {
            Uri uriObj = new Uri(fileUrl);
            string BlobName = Path.GetFileName(uriObj.LocalPath);


            var accessKey = _configuration["BlobAccessKey"];
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(accessKey);
            CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            string strContainerName = "uploads";
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(strContainerName);

            // get block blob reference    
            CloudBlockBlob blockBlob = cloudBlobContainer.GetBlockBlobReference(BlobName);

            // delete blob from container        
            await blockBlob.DeleteAsync().ConfigureAwait(true);
        }

        public async Task<string> UploadFileToBlobAsync(string strFileName, byte[] fileData, string fileMimeType)
        {
            try
            {
                // Retrieve storage account from connection string.
                var accessKey = _configuration["BlobAccessKey"];
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(accessKey);
                // Create the blob client.
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                // Retrieve a reference to a container.
                string strContainerName = "uploads";
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(strContainerName);
                //Check Permissions
                BlobContainerPermissions permissions = new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                };
                await cloudBlobContainer.SetPermissionsAsync(permissions).ConfigureAwait(true);

                if (strFileName != null && fileData != null)
                {
                    CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(strFileName);
                    cloudBlockBlob.Properties.ContentType = fileMimeType;
                    await cloudBlockBlob.UploadFromByteArrayAsync(fileData, 0, fileData.Length).ConfigureAwait(true);
                    return cloudBlockBlob.Uri.AbsoluteUri;
                }
                return "";
            }
            catch (TargetInvocationException tiex)
            {
                throw tiex.InnerException;
            }
        }
    }
}