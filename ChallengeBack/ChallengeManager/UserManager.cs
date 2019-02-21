using Challenge.Domain;
using Challenge.Repository;
using System;
using System.Collections.Generic;

namespace ChallengeManager
{
    public class UserManager: IUserManager
    {       
        IUserRepository _UserRepository;

        public UserManager(IUserRepository userRepository)
        {
            _UserRepository = userRepository ?? throw new ArgumentNullException("userRepository"); 
        }

        /// <summary>
        /// method manager get users
        /// </summary>
        /// <returns></returns>
        public DataExecutionResult<List<User>> GetByFilter(int NumPage, int NumRegisters)
        {
            DataExecutionResult<List<User>> result = new DataExecutionResult<List<User>>();
            try
            {
                if (NumRegisters > 200)
                {
                    result.Success = false;
                    result.ErrorCode = 1;
                    result.Message = "No se pueden cargar mas de 200 registros.";
                }
                
                result.Data = _UserRepository.GetByFilter(NumPage, NumRegisters);

                return result;
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.ErrorCode = 2;
                result.Message = ex.Message;
                return result;
            }
           
        }

        /// <summary>
        /// method for get user by id
        /// </summary>
        /// <param name="IdValue"></param>
        /// <returns></returns>
        public DataExecutionResult<User> GetById(string IdValue)
        {
            DataExecutionResult<User> result = new DataExecutionResult<User>();

            try
            {               
                result.Data = _UserRepository.GetById(IdValue);
                return result;
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.ErrorCode = 2;
                result.Message = ex.Message;
                return result;
            }
        }

        public ExecutionResult Save(User user)
        {
            ExecutionResult result = new ExecutionResult();
            try
            {
                result.Success = _UserRepository.Save(user);
                result.Message = Challenge.Managers.Helpers.ResourceHelper.Instance.Resources.GetString("SaveUserOK");
                return result;
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.ErrorCode = 2;
                result.Message = Challenge.Managers.Helpers.ResourceHelper.Instance.Resources.GetString("SaveUserFail");
                return result;
            }
        }

        /// <summary>
        /// method to save of list users
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ExecutionResult Save(List<User> users)
        {
            ExecutionResult result = new ExecutionResult();
            try
            {
                result.Success = _UserRepository.Save(users);
                result.Message = Challenge.Managers.Helpers.ResourceHelper.Instance.Resources.GetString("SaveUserOK");
                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorCode = 2;
                result.Message = Challenge.Managers.Helpers.ResourceHelper.Instance.Resources.GetString("SaveUserFail");
                return result;
            }
        }

        public ExecutionResult Delete(string IdValue)
        {
            ExecutionResult result = new ExecutionResult();
            try
            {
                result.Success = _UserRepository.Delete(IdValue);
                result.Message = Challenge.Managers.Helpers.ResourceHelper.Instance.Resources.GetString("DeleteUserOK");
                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorCode = 2;
                result.Message = Challenge.Managers.Helpers.ResourceHelper.Instance.Resources.GetString("DeleteUserFail");
                return result;
            }
        }
    }
}
