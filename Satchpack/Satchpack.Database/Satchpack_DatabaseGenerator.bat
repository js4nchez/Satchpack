@echo off
echo ************************************************************
echo *WHEN UPDATING BATCH FILE, ADD SCRIPTS THAT HAVE NO        *
echo *REFERENCES TO THE TOP OF THE LIST, AND SCRIPTS THAT HAVE  *
echo *REFERENCES TO THE BOTTOM OF THE LIST. IF YOU HAVE NOT DONE*
echo *THIS, PLEASE CLOSE THIS FILE AND REORGANIZE IT            *
echo ************************************************************
pause

sqlcmd -S localhost -E -i C:\Users\%UserName%\Documents\GitHub\Satchpack\Satchpack\Satchpack.Database\Database\CreateDatabase.sql
sqlcmd -S localhost -E -i C:\Users\%UserName%\Documents\GitHub\Satchpack\Satchpack\Satchpack.Database\Tables\CreateProduct.sql
sqlcmd -S localhost -E -i C:\Users\%UserName%\Documents\GitHub\Satchpack\Satchpack\Satchpack.Database\Tables\CreateShippingMethod.sql
sqlcmd -S localhost -E -i C:\Users\%UserName%\Documents\GitHub\Satchpack\Satchpack\Satchpack.Database\Tables\CreateCustomer.sql
sqlcmd -S localhost -E -i C:\Users\%UserName%\Documents\GitHub\Satchpack\Satchpack\Satchpack.Database\Tables\CreateInvoiceStatus.sql
sqlcmd -S localhost -E -i C:\Users\%UserName%\Documents\GitHub\Satchpack\Satchpack\Satchpack.Database\Tables\CreateUser.sql
sqlcmd -S localhost -E -i C:\Users\%UserName%\Documents\GitHub\Satchpack\Satchpack\Satchpack.Database\Tables\CreateInvoice.sql
sqlcmd -S localhost -E -i C:\Users\%UserName%\Documents\GitHub\Satchpack\Satchpack\Satchpack.Database\Tables\CreateProductList.sql
sqlcmd -S localhost -E -i C:\Users\%UserName%\Documents\GitHub\Satchpack\Satchpack\Satchpack.Database\Tables\CreateInventory.sql


pause