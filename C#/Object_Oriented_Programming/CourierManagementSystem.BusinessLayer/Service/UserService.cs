using CourierManagementSystem.BusinessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.BusinessLayer.Service
{


    public class UserService : IUserService
    {
        IUserRepository _userRepository; 
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void DisplayEmployeeInfo()
        {
            _userRepository.DisplayEmployeeInfo();
        }
    }
}
