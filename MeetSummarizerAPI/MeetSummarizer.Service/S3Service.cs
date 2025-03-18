using Amazon.S3;
using Amazon.S3.Model;
using MeetSummarizer.Core.IServices;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace MeetSummarizer.Service
{
    public class S3Service : IS3Service
    {
        private readonly IAmazonS3 _s3Service;
        private readonly string _bucketName;

        public S3Service(IAmazonS3 s3Service, IConfiguration configuration)
        {
            _s3Service = s3Service;
            var awsOptions = configuration.GetSection("AWS");
            _bucketName = awsOptions["BucketName"];
        }

        public async Task<string> GeneratePresignedUrlAsync(string fileName, string contentType)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = _bucketName,
                Key = fileName,
                Verb = HttpVerb.PUT,
                Expires = DateTime.UtcNow.AddMinutes(10),
                ContentType = contentType
            };

            return _s3Service.GetPreSignedURL(request);
        }

        public async Task<string> GetDownloadUrlAsync(string fileName)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = _bucketName,
                Key = fileName,
                Verb = HttpVerb.GET,
                Expires = DateTime.Now.AddMinutes(15)
            };

            return _s3Service.GetPreSignedURL(request);
        }
    }
}
