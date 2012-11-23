using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

namespace TeamPortal.Infrastructure
{
    public class BlobAgent : IBlobAgent
    {
        public CloudBlobContainer GetContainer()
        {
            // Get a handle on account, create a blob service client and get container proxy
            var account = CloudStorageAccount.FromConfigurationSetting("storageAccount");
            var client = account.CreateCloudBlobClient();
            return client.GetContainerReference("roster-images");
        }

        public static void EnsureContainerExists()
        {
            var agent = new BlobAgent();
            var container = agent.GetContainer();
            container.CreateIfNotExist();

            var permissions = container.GetPermissions();
            permissions.PublicAccess = BlobContainerPublicAccessType.Container;
            container.SetPermissions(permissions);
        }

        public static string GetContentTypeFromExtension(string extension)
        {
            switch (extension)
            {
                case ".png":
                    return "image/png";
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".bmp":
                    return "image/bmp";
                case ".htm":
                    return "text/html";
                case ".css":
                    return "text/css";
                case ".js":
                    return "text/x-javascript";
                case ".zip":
                    return "application/zip";
                default:
                    return null;
            }

        }
    }

    public interface IBlobAgent
    {
        CloudBlobContainer GetContainer();
    }
}