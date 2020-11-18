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
    class WeddingFavoritesBLL
    {
        private readonly BLLSecurity bLLSecurity;

        public WeddingFavoritesBLL()
        {
            bLLSecurity = new BLLSecurity();
        }

        public async Task<IEnumerable<WeddingFavorites>> GetList(LeJourDBContext context)
        {
            var wfs = from wf in context.TbWeddingFavorites
                      select new WeddingFavorites
                        {
                            idWedding = wf.idWedding,
                            idVendor = wf.idVendor
                        };

            return await wfs.ToListAsync();
        }

        public void Save(LeJourDBContext context, JsonElement body)
        {
            try
            {
                var wfModel = JsonSerializer.Deserialize<WeddingFavorites>(body.ToString());

                var wf = new TbWeddingFavorites
                {
                    idWedding = wfModel.idWedding,
                    idVendor = wfModel.idVendor,
                };


                using (context)
                {

                    if (context.TbWeddingFavorites.Where(u => u.idWedding == wf.idWedding).Any())
                    {
                        context.TbWeddingFavorites.Update(wf);

                        if (context.TbWeddingFavorites.Where(a => a.idVendor == wf.idVendor).Any())
                            context.TbWeddingFavorites.Update(wf);
                        else
                            context.TbWeddingFavorites.Add(wf);
                    }
                    else
                    {
                        context.TbWeddingFavorites.Add(wf);
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
