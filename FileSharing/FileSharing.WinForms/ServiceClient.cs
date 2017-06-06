using System;
using System.Net.Http;
using System.Net.Http.Headers;
using FileSharing.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace FileSharing.WinForms
{
    public class ServiceClient
    {
        private readonly Guid _currentUserId;
        private readonly HttpClient _client = new HttpClient();

        public ServiceClient(string connectionString, Guid currentUserId)
        {
            _currentUserId = currentUserId;
            _client.BaseAddress = new Uri(connectionString);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public ServiceClient(string connectionString)
        {
            _client.BaseAddress = new Uri(connectionString);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public File[] GetUserFiles()
        {
            var response = _client.GetAsync($"users/{_currentUserId}/files").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<File[]>().Result;
                return result;
            }
            throw new ServiceException("Error: {0}", response.StatusCode);
        }

        public Guid CreateFile(File file)
        {
            var response = _client.PostAsJsonAsync("files", file).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<File>().Result;
                return result.Id;
            }
            throw new ServiceException("Error: {0}", response.StatusCode);
        }

        public void UploadFileContent(Guid fileId, byte[] content)
        {
            using (var byteArrayContent = new ByteArrayContent(content))
            {
                var response = _client.PutAsync($"files/{fileId}/content", byteArrayContent).Result;
                if (!response.IsSuccessStatusCode)
                    throw new ServiceException("Error: {0}", response.StatusCode);
            }
        }

        public void DeleteFile(Guid fileId)
        {
            var response = _client.DeleteAsync($"files/{fileId}").Result;
            if (!response.IsSuccessStatusCode)
                throw new ServiceException("Error: {0}", response.StatusCode);
        }

        public byte[] DownloadFile(Guid fileId)
        {
            var response = _client.GetAsync($"files/{fileId}/content").Result;
            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<byte[]>().Result;
            throw new ServiceException("Error: {0}", response.StatusCode);
        }

        public User GetUser(Guid userId)
        {
            var response = _client.GetAsync($"users/{userId}").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<User>().Result;
                return result;
            }
            throw new ServiceException("Error: {0}", response.StatusCode);
        }

        public User[] GetUsers()
        {
            var response = _client.GetAsync($"users/all").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<User[]>().Result;
                return result;
            }
            throw new ServiceException("Error: {0}", response.StatusCode);
        }

        public void DeleteUser(Guid UserId)
        {
            var response = _client.DeleteAsync($"users/{UserId}").Result;
            if (!response.IsSuccessStatusCode)
                throw new ServiceException("Error: {0}", response.StatusCode);
        }

        public void CreateUser(string name, string email)
        {
            var user = new User
            {
                Name = name,
                Email = email
            };
            var response = _client.PostAsJsonAsync($"users", user).Result;
            if (!response.IsSuccessStatusCode)
                throw new ServiceException("Error: {0}", response.StatusCode);
        }

        public Comment[] GetCommentsFile(Guid fileId)
        {
            var response = _client.GetAsync($"files/{fileId}/comments").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<Comment[]>().Result;
                return result;
            }
            throw new ServiceException("Error: {0}", response.StatusCode);
        }

        public User[] GetUsersSharedFile(Guid fileId)
        {
            var response = _client.GetAsync($"files/SharingFiles/?id={fileId}").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<User[]>().Result;
                return result;
            }
            throw new ServiceException("Error: {0}", response.StatusCode);
        }

        public void DeleteShare(Guid id)
        {
            var response = _client.DeleteAsync($"files/Sharing/{id}").Result;
            if (!response.IsSuccessStatusCode)
                throw new ServiceException("Error: {0}", response.StatusCode);
        }

        public Guid GetShareId(Guid fileId, Guid userId)
        {
            var response = _client.GetAsync($"files/SharingFiles/?fileid={fileId}&userid={userId}").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<Guid>().Result;
                return result;
            }
            throw new ServiceException("Error: {0}", response.StatusCode);
        }

        public void CreateShare(Guid fileId, Guid userId)
        {
            var share = new Share
            {
                FileId = fileId,
                UserId = userId
            };
            var response = _client.PostAsJsonAsync($"files/SharingFiles", share).Result;
            if (!response.IsSuccessStatusCode)
                throw new ServiceException("Error: {0}", response.StatusCode);
        }

        public File[] GetFilesSharedUser(Guid userId)
        {
            var response = _client.GetAsync($"files/filesh/?id={userId}").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<File[]>().Result;
                return result;
            }
            throw new ServiceException("Error: {0}", response.StatusCode);
        }

        public Comment[] GetComments(Guid id)
        {
            var response = _client.GetAsync($"files/comments?id={id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<Comment[]>().Result;
                return result;
            }
            throw new ServiceException("Error: {0}", response.StatusCode);
        }

        public void CreateComment(Guid fileId, Guid userId, string text)
        {
            var comment = new Comment
            {
                FileId = fileId,
                UserId = userId,
                Text = text
            };
            var response = _client.PostAsJsonAsync($"comments", comment).Result;
            if (!response.IsSuccessStatusCode)
                throw new ServiceException("Error: {0}", response.StatusCode);
        }

        public void DeleteComment(Guid commentId)
        {
            var response = _client.DeleteAsync($"comments/{commentId}").Result;
            if (!response.IsSuccessStatusCode)
                throw new ServiceException("Error: {0}", response.StatusCode);
        }
    }
}
