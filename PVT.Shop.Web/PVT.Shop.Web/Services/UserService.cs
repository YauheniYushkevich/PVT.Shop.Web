namespace PVT.Shop.Web.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using DAL.Repositories;
    using Infrastructure.Common;
    using Infrastructure.Common.Enums;
    using Infrastructure.Services;
    using Coinsidence = DAL.Repositories.UserRepository.Coinsidence;

    public class UserService : IUserService
    {
        private readonly UserRepository _repository;

        public UserService(UserRepository repository)
        {
            this._repository = repository;
        }

        public void AddUser(User user)
        {
            this._repository.Create(user);
        }

        public void DeleteUser(int id)
        {
            this._repository.Delete(id);
        }

        public User GetUser(int id)
        {
            return this._repository.GetById(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return this._repository.GetAll();
        }

        public void SaveUser()
        {
            this._repository.Save();
        }

        public void UpdateUser(User user)
        {
            this._repository.Update(user);
        }

        public User LoginUser(string login, string pass)
        {
            return this._repository.Login(login, pass);
        }

        public bool IsExist(string login, string password, out string message)
        {
            Coinsidence coins;
            message = "Empty message";
            bool isExist = this._repository.IsExist(login, password, out coins);
            if (isExist)
            {
                switch ((int)coins)
                {
                    case 0x03:
                        message = "User with such Login or Password is exist";
                        break;
                    case 0x01:
                        message = "User with such Login is exist";
                        break;
                    case 0x02:
                        message = "User with such Password is exist";
                        break;
                }

                return true;
            }

            return false;
        }

        public IEnumerable<User> SortByUserProp(IEnumerable<User> query, SortEnumByUserProp sortParam)
        {
            switch (sortParam)
            {
                case SortEnumByUserProp.Id:
                    query = query.OrderBy(x => x.Id);
                    break;
                case SortEnumByUserProp.IdDesc:
                    query = query.OrderByDescending(x => x.Id);
                    break;
                case SortEnumByUserProp.Login:
                    query = query.OrderBy(x => x.Login);
                    break;
                case SortEnumByUserProp.LoginDesc:
                    query = query.OrderByDescending(x => x.Login);
                    break;
                case SortEnumByUserProp.FirstName:
                    query = query.OrderBy(x => x.FirstName);
                    break;
                case SortEnumByUserProp.FirstNameDesc:
                    query = query.OrderByDescending(x => x.FirstName);
                    break;
                case SortEnumByUserProp.LastName:
                    query = query.OrderBy(x => x.LastName);
                    break;
                case SortEnumByUserProp.LastNameDesc:
                    query = query.OrderByDescending(x => x.LastName);
                    break;
                case SortEnumByUserProp.Email:
                    query = query.OrderBy(x => x.Email);
                    break;
                case SortEnumByUserProp.EmailDesc:
                    query = query.OrderByDescending(x => x.Email);
                    break;
                case SortEnumByUserProp.Birthday:
                    query = query.OrderBy(x => x.Birthday);
                    break;
                case SortEnumByUserProp.BirthdayDesc:
                    query = query.OrderByDescending(x => x.Birthday);
                    break;
                case SortEnumByUserProp.Gender:
                    query = query.OrderBy(x => x.Gender);
                    break;
                case SortEnumByUserProp.GenderDesc:
                    query = query.OrderByDescending(x => x.Gender);
                    break;
                case SortEnumByUserProp.Role:
                    query = query.OrderBy(x => x.Role);
                    break;
                case SortEnumByUserProp.RoleDesc:
                    query = query.OrderByDescending(x => x.Role);
                    break;
                case SortEnumByUserProp.Phone:
                    query = query.OrderBy(x => x.Phone);
                    break;
                case SortEnumByUserProp.PhoneDesc:
                    query = query.OrderByDescending(x => x.Phone);
                    break;
                default:
                    query = query.OrderByDescending(x => x.Id);
                    break;
            }

            return query;
        }

        public bool IsExistAnyAdmin(int id)
        {
            return this._repository.IsExistAnyAdmin(id);
        }

        public IEnumerable<User> GetUsersByRole(string searshRole)
        {
            var query = this._repository.GetAll();
            var usersByRole = query.Where(u => u.Role.ToString().ToUpper().Contains(searshRole.ToUpper()));
            return usersByRole;
        }
    }
}