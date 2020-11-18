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
    class InvoiceBLL
    {


        private readonly BLLSecurity bLLSecurity;

        public InvoiceBLL()
        {
            bLLSecurity = new BLLSecurity();
        }

        public async Task<IEnumerable<Invoice>> GetList(LeJourDBContext context)
        {
            var invoices = from invoice in context.TbInvoice
                           select new Invoice
                           {
                               idInvoice = invoice.idInvoice,
                               idWedding = invoice.idWedding,
                               idVendor = invoice.idVendor,
                               vlAmount = invoice.vlAmount,
                               vlAmountVendor = invoice.vlAmountVendor,
                               dtCreated = invoice.dtCreated,
                               dsAccepted = invoice.dsAccepted,
                               dsCategoryVendor = invoice.dsCategoryVendor
                           };

            return await invoices.ToListAsync();
        }

        public void Save(LeJourDBContext context, JsonElement body)
        {
            try
            {
                var invoiceModel = JsonSerializer.Deserialize<Invoice>(body.ToString());

                var invoice = new TbInvoice
                {
                    idInvoice = invoiceModel.idInvoice,
                    idWedding = invoiceModel.idWedding,
                    idVendor = invoiceModel.idVendor,
                    vlAmount = invoiceModel.vlAmount,
                    vlAmountVendor = invoiceModel.vlAmountVendor,
                    dtCreated = invoiceModel.dtCreated,
                    dsAccepted = invoiceModel.dsAccepted,
                    dsCategoryVendor = invoiceModel.dsCategoryVendor
                };


                using (context)
                {

                    if (context.TbInvoice.Where(u => u.idInvoice == invoice.idInvoice).Any())
                    {
                        context.TbInvoice.Update(invoice);

                        if (context.TbInvoice.Where(a => a.idWedding == invoice.idWedding).Any())
                            context.TbInvoice.Update(invoice);

                        if (context.TbInvoice.Where(a => a.idVendor == invoice.idVendor).Any())
                            context.TbInvoice.Update(invoice);

                        if (context.TbInvoice.Where(a => a.vlAmount == invoice.vlAmount).Any())
                            context.TbInvoice.Update(invoice);

                        if (context.TbInvoice.Where(a => a.vlAmountVendor == invoice.vlAmountVendor).Any())
                            context.TbInvoice.Update(invoice);

                        if (context.TbInvoice.Where(a => a.dtCreated == invoice.dtCreated).Any())
                            context.TbInvoice.Update(invoice);

                        if (context.TbInvoice.Where(a => a.dsAccepted == invoice.dsAccepted).Any())
                            context.TbInvoice.Update(invoice);

                        if (context.TbInvoice.Where(a => a.dsCategoryVendor == invoice.dsCategoryVendor).Any())
                            context.TbInvoice.Update(invoice);

                        context.TbInvoice.Add(invoice);
                    }
                    else
                    {
                        context.TbInvoice.Add(invoice);
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
