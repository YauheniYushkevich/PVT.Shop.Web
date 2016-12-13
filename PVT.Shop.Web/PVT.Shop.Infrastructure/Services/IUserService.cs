namespace PVT.Shop.Infrastructure.Services
{
    using System;
    using System.Collections.Generic;
    using Common;
    using Common.Enums;

    public interface IUserService
    {
        void AddUser(User user);

        void DeleteUser(int id);

        void UpdateUser(User user);

        User GetUser(int id);

        IEnumerable<User> GetAllUsers();

        void SaveUser();

        User LoginUser(string login, string pass);

        bool IsExist(string login, string password, out string message);

        IEnumerable<User> SortByUserProp(IEnumerable<User> query, SortEnumByUserProp sortParam);

        bool IsExistAnyAdmin(int id);

        IEnumerable<User> GetUsersByRole(string searchString);
    }
}