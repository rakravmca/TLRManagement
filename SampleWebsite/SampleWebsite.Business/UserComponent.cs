using SampleWebsite.Data;
using SampleWebsite.Model;
using SampleWebsite.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebsite.Business
{
    public class UserComponent
    {
        /// <summary>
        /// Gets the user information by username and password.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public UserModel GetUserInfoByUsernameAndPassword(string username, string password)
        {
            using (var db = new SampleEntities())
            {
                string encryptedPassword = EncryptionUtility.Encrypt(password, true);

                return db.Users.Where(w => w.Username == username
                    && w.Password == encryptedPassword).Select(s => new UserModel
                    {
                        Id = s.Id,
                        FirstName = s.FirstName,
                        MiddleName = s.MiddleName,
                        LastName = s.LastName,
                        Email = s.Email,
                        Phone = s.Phone,
                        Username = s.Username,
                        UserTypeId = s.UserTypeId
                    }).SingleOrDefault();
            }
        }

        /// <summary>
        /// Gets the user information by user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public UserModel GetUserInfoByUserId(long userId)
        {
            using (var db = new SampleEntities())
            {
                return db.Users.Where(w => w.Id == userId).Select(s => new UserModel
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    MiddleName = s.MiddleName,
                    LastName = s.LastName,
                    Email = s.Email,
                    Phone = s.Phone,
                    Username = s.Username,
                    UserType = new UserTypeModel
                    {
                        Id = s.UserType.Id,
                        Name = s.UserType.Name
                    }
                }).SingleOrDefault();
            }
        }

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns></returns>
        public List<UserModel> GetUsers()
        {
            using (var db = new SampleEntities())
            {
                return db.Users.Select(s => new UserModel
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    MiddleName = s.MiddleName ?? string.Empty,
                    LastName = s.LastName ?? string.Empty,
                    Email = s.Email ?? string.Empty,
                    Phone = s.Phone ?? string.Empty,
                    Username = s.Username,
                    UserTypeId = s.UserTypeId,
                    UserType = new UserTypeModel
                    {
                        Id = s.UserType.Id,
                        Name = s.UserType.Name
                    }
                }).ToList();
            }
        }

        /// <summary>
        /// Saves the user.
        /// </summary>
        /// <param name="userInfo">The user information.</param>
        /// <returns></returns>
        public bool SaveUser(UserModel userInfo)
        {
            using (var db = new SampleEntities())
            {
                User userData;

                if (userInfo.Id == 0)
                {
                    userData = new User
                    {
                        FirstName = userInfo.FirstName,
                        MiddleName = userInfo.MiddleName,
                        LastName = userInfo.LastName,
                        Email = userInfo.Email,
                        Username = userInfo.Username,
                        Password = EncryptionUtility.Encrypt(userInfo.Password, true),
                        Phone = userInfo.Phone,
                        UserTypeId = userInfo.UserType.Id
                    };

                    db.Users.Add(userData);
                }
                else
                {
                    userData = db.Users.Where(w => w.Id == userInfo.Id).SingleOrDefault();

                    if (userData != null)
                    {
                        userData.FirstName = userInfo.FirstName;
                        userData.MiddleName = userInfo.MiddleName;
                        userData.LastName = userInfo.LastName;
                        userData.Email = userInfo.Email;
                        userData.Phone = userInfo.Phone;
                        userData.UserTypeId = userInfo.UserType.Id;
                    }
                }

                db.SaveChanges();
            }

            return true;
        }

        /// <summary>
        /// Removes the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public bool RemoveUser(long userId)
        {
            using (var db = new SampleEntities())
            {
                User userData = db.Users.Where(w => w.Id == userId).SingleOrDefault();

                if (userData != null)
                {
                    db.Users.Remove(userData);
                    return db.SaveChanges() > 0;
                }

                return false;
            }
        }

        /// <summary>
        /// Updates the password.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns></returns>
        public bool UpdatePassword(long userId, string newPassword)
        {
            using (var db = new SampleEntities())
            {
                User userData = db.Users.Where(w => w.Id == userId).SingleOrDefault();

                if (userData != null)
                {
                    userData.Password = EncryptionUtility.Encrypt(newPassword, true);

                    db.SaveChanges();
                }

                return true;
            }
        }
    }
}
