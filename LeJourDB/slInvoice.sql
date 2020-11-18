CREATE TABLE [dbo].[Invoice]
(
	[idInvoice] NCHAR(10) NOT NULL, 
    [idWedding] NCHAR(10) NULL, 
    [idVendor] NCHAR(10) NULL, 
    [vlAmount] NCHAR(10) NULL, 
    [vlAmountVendor] NCHAR(10) NULL, 
    [dtCreated] NCHAR(10) NULL, 
    [dsAccepted] NCHAR(10) NULL, 
    [dsCategoryVendor] NCHAR(10) NULL 
)
