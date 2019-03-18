using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CarIsYourHome
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api")]
    public class UserApiController : ApiController
    {

        private UsersLogic userlogic = new UsersLogic();

        //User section - authorization: Manager

        [HttpGet]
        [Route("users")]
        public HttpResponseMessage GetAllUsers()
        {
            try
            {
                List<UserModel> allusers = userlogic.GetAllUsers();
                return Request.CreateResponse(HttpStatusCode.OK, allusers);
            }
            catch (Exception ex)
            {

                Errors error = ErrorsHelper.GetErrors(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, error);
            }
            
        }

        [HttpGet]
        [Route("users/{id}")]
        public HttpResponseMessage GetUserById(int id)
        {
            try
            {
                
                UserModel user = userlogic.GetUserById(id);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {

                Errors error = ErrorsHelper.GetErrors(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, error);
            }
            
        }

        [HttpPost]
        [Route("users")]
        public HttpResponseMessage AddUser([FromBody] UserModel user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Errors errors = ErrorsHelper.GetErrors(ModelState);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
                }
                UserModel newUser = userlogic.AddUser(user);
                return Request.CreateResponse(HttpStatusCode.Created, newUser);
            }
            catch (Exception ex)
            {

                Errors error = ErrorsHelper.GetErrors(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, error);
            }
           
        }

        [HttpPut]
        [Route("users/{id}")]
        public HttpResponseMessage UpdateUser(int id, [FromBody] UserModel user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Errors errors = ErrorsHelper.GetErrors(ModelState);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
                }
                user.userid = id;
                UserModel updatedCar = userlogic.UpdateUserDetails(user);
                return Request.CreateResponse(HttpStatusCode.OK, updatedCar);
            }
          
            catch (Exception ex)
            {

                Errors error = ErrorsHelper.GetErrors(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, error);
            }
            
        }

        [HttpDelete]
        [Route("users/{id}")]
        public HttpResponseMessage DeleteUser(int id)
        {
            try
            {
               
                userlogic.DeleteUser(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {

                Errors error = ErrorsHelper.GetErrors(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, error);
            }
            
        }

        //This function suuport the Login proccess in the client side.
        // It get only two parameters inside the user model: username and password. 
        //Then it checks does this user is exist in the user Table, and return a boolean answer
        [HttpPost]
        [Route("users/login")]
        public HttpResponseMessage IsUserExist([FromBody] UserModel user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Errors errors = ErrorsHelper.GetErrors(ModelState);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
                }
                UserModel verifiedUser = userlogic.UserLogIn(user.username, user.password);
                return Request.CreateResponse(HttpStatusCode.OK, verifiedUser);
            }
            catch (Exception ex)
            {

                Errors error = ErrorsHelper.GetErrors(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, error);
            }
        }



    }
}
