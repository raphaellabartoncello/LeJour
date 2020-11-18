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
    class WeddingBLL
    {        
        private readonly BLLSecurity bLLSecurity;

        public WeddingBLL()
        {
            bLLSecurity = new BLLSecurity();
        }

        public async Task<IEnumerable<Wedding>> GetList(LeJourDBContext context)
        {
            var weddings = from wedding in context.TbWedding
                           select new Wedding
                           {
                                   idWedding = wedding.idWedding,
                               idUser = wedding.idUser,
                               vlBudget = wedding.vlBudget,
                               dtWedding = wedding.dtWedding,
                               nmGuests = wedding.nmGuests,
                               dsStyle = wedding.dsStyle
                           };

            return await weddings.ToListAsync();
        }

        public void Save(LeJourDBContext context, JsonElement body)
        {
            try
            {
                var weddingModel = JsonSerializer.Deserialize<Wedding>(body.ToString());

                var wedding = new TbWedding
                {
                    idWedding = weddingModel.idWedding,
                    idUser = weddingModel.idUser,
                    vlBudget = weddingModel.vlBudget,
                    dtWedding = weddingModel.dtWedding,
                    nmGuests = weddingModel.nmGuests,
                    dsStyle = weddingModel.dsStyle
                };


                using (context)
                {

                    if (context.TbWedding.Where(u => u.idWedding == wedding.idWedding).Any())
                    {
                        context.TbWedding.Update(wedding);

                        if (context.TbWedding.Where(a => a.idUser == wedding.idUser).Any())
                            context.TbWedding.Update(wedding);

                        if (context.TbWedding.Where(a => a.vlBudget == wedding.vlBudget).Any())
                            context.TbWedding.Update(wedding);

                        if (context.TbWedding.Where(a => a.nmGuests == wedding.nmGuests).Any())
                            context.TbWedding.Update(wedding);

                        if (context.TbWedding.Where(a => a.dsStyle == wedding.dsStyle).Any())
                            context.TbWedding.Update(wedding);
                        else
                            context.TbWedding.Add(wedding);
                    }
                    else
                    {
                        context.TbWedding.Add(wedding);
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
