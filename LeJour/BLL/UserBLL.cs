using LeJour.DAL;
using LeJour.DataModel;
using LeJourModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LeJour.BLL
{
    public class UserBLL
    {
        private readonly BLLSecurity bLLSecurity;

        public UserBLL()
        {
            bLLSecurity = new BLLSecurity();
        }

        public async Task<IEnumerable<User>> GetList(LeJourDBContext context)
        {
            var users = from user in context.TbUser
                        select new User
                        {
                            idUser = user.idUser,
                            dtCreated = user.dtCreated
                        };

            return await users.ToListAsync();
        }

        internal Task Get(LeJourDBContext context, string idUser)
        {
            throw new NotImplementedException();
        }

        public void Save(LeJourDBContext context, JsonElement body)
        {
            try
            {
                var userModel = JsonSerializer.Deserialize<User>(body.ToString());

                var user = new TbUser
                {
                    idUser = userModel.idUser,
                    dtCreated = userModel.dtCreated,
                };


                using (context)
                {

                    if (context.TbUser.Where(u => u.idUser == user.idUser).Any())
                    {
                        context.TbUser.Update(user);

                        if (context.TbUser.Where(a => a.idUser == user.idUser).Any())
                            context.TbUser.Update(user);
                        else
                            context.TbUser.Add(user);
                    }
                    else
                    {
                        context.TbUser.Add(user);
                    }

                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                //Log exception
                throw;
            }

        }
    }
}
