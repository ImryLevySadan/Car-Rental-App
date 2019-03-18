using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace CarIsYourHome
{ 
    public class UsersLogic :BaseLogic
    {
        // Users Section - authorization: Manager

        //Most of the function are based on the same concept as the CarLogic class, 
        //So, documentation will include only new notes
        public List<UserModel> GetAllUsers ()
        {
          
               return DB.Users.Select(user => new UserModel
               {
                userid = user.User_ID,
                fullname = user.Full_Name,
                idnumber = user.ID_Number,
                birthdate = user.Birth_Date,
                gender = user.Gender,
                email = user.Email,

                   }).ToList();
        }

        public UserModel GetUserById (int id)
        {
            return DB.Users.Where(user => user.User_ID == id).Select(user => new UserModel
            {
                userid = user.User_ID,
                fullname = user.Full_Name,
                username = user.User_Name,
                idnumber = user.ID_Number,
                birthdate = user.Birth_Date,
                gender = user.Gender,
                email = user.Email,
                password = user.Password,
                description = user.Description
           
            }).SingleOrDefault();
        
        } 

        public UserModel AddUser (UserModel user)


        {
            User newuser = new User
            {
                Full_Name = user.fullname,
                User_Name = user.username,
                ID_Number = user.idnumber,
                Birth_Date = user.birthdate,
                Gender = user.gender,
                Email = user.email,
                Password = user.password,
                Description = user.description
            };

            DB.Users.Add(newuser);
            DB.SaveChanges();

            return GetUserById(newuser.User_ID)
;
        }

        public UserModel UpdateUserDetails (UserModel user)
        {

            User changedUser = new User();
            changedUser.User_ID = (int)user.userid;
            changedUser.User_Name = user.username;
            changedUser.Full_Name = user.fullname;
            changedUser.ID_Number = user.idnumber;
            changedUser.Birth_Date = user.birthdate;
            changedUser.Gender = user.gender;
            changedUser.Email = user.email;
            changedUser.Password = user.password;
            changedUser.Description = user.description;

            
            DB.Users.Attach(changedUser);
            DB.Entry(changedUser).State = EntityState.Modified;
            DB.SaveChanges();


            return GetUserById(changedUser.User_ID);
        }

        public void DeleteUser (int id)
        {
            User user = new User { User_ID = id };
            DB.Users.Attach(user);
            if (user == null)
                return;

            DB.Users.Remove(user);
            DB.SaveChanges();
            
            
        }

        public UserModel UserLogIn(string username, string password)
        {
            return DB.Users.Where(user => user.User_Name == username && user.Password == password).Select(user => new UserModel
            {
                userid = user.User_ID,
                fullname = user.Full_Name,
                username = user.User_Name,
                idnumber = user.ID_Number,
                birthdate = user.Birth_Date,
                gender = user.Gender,
                email = user.Email,
                password = user.Password,
                description = user.Description

            }).SingleOrDefault();
        }

        public bool IsUserIdValid (string IDNumber)
        {
            int mone = 0;
            int incNum;
            for (int i = 0; i < 9; i++)
            {
                incNum = Convert.ToInt32(IDNumber[i].ToString());
                incNum *= (i % 2) + 1;
                if (incNum > 9)
                    incNum -= 9;
                mone += incNum;
            }
            if (mone % 10 == 0)
                return true;
            else
                return false;
        }


    }
}
