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
    public class AppointmentBLL
    {

        private readonly BLLSecurity bLLSecurity;

        public AppointmentBLL()
        {
            bLLSecurity = new BLLSecurity();
        }

        public async Task<IEnumerable<Appointment>> GetList(LeJourDBContext context)
        {
            var appointments = from appointment in context.TbAppointment
                        select new Appointment
                        {
                            idAppointment = appointment.idAppointment,
                            idWedding = appointment.idWedding,
                            idVendor = appointment.idVendor,
                            idStatus = appointment.idStatus,
                            dsCategoryVendor = appointment.dsCategoryVendor,
                            dtAppointment = appointment.dtAppointment,
                        };

            return await appointments.ToListAsync();
        }

        public void Save(LeJourDBContext context, JsonElement body)
        {
            try
            {
                var appointmentModel = JsonSerializer.Deserialize<Appointment>(body.ToString());

                var appointment = new TbAppointment
                {
                    idAppointment = appointmentModel.idAppointment,
                    idWedding = appointmentModel.idWedding,
                    idVendor = appointmentModel.idVendor,
                    idStatus = appointmentModel.idStatus,
                    dsCategoryVendor = appointmentModel.dsCategoryVendor,
                    dtAppointment = appointmentModel.dtAppointment
                };


                using (context)
                {

                    if (context.TbAppointment.Where(u => u.idAppointment == appointment.idAppointment).Any())
                    {
                        context.TbAppointment.Update(appointment);

                        if (context.TbAppointment.Where(a => a.idWedding == appointment.idWedding).Any())
                            context.TbAppointment.Update(appointment);

                        if (context.TbAppointment.Where(a => a.idVendor == appointment.idVendor).Any())
                            context.TbAppointment.Update(appointment);

                        if (context.TbAppointment.Where(a => a.idStatus == appointment.idStatus).Any())
                            context.TbAppointment.Update(appointment);

                        if (context.TbAppointment.Where(a => a.dsCategoryVendor == appointment.dsCategoryVendor).Any())
                            context.TbAppointment.Update(appointment);

                        if (context.TbAppointment.Where(a => a.dtAppointment == appointment.dtAppointment).Any())
                            context.TbAppointment.Update(appointment);
                        else
                            context.TbAppointment.Add(appointment);
                    }
                    else
                    {
                        context.TbAppointment.Add(appointment);
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
