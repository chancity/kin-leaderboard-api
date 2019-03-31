# kin-leaderboard-api

## docker image
https://hub.docker.com/r/chancity/kin-leaderboard-api

## environment variables
{"ConnectionStrings_ApplicationDatabase","server=localhost;database=application_api;uid=root;pwd=password"},

{"Horizon_Url", "https://horizon.kinfederation.com/"},

{"HorizonNetwork_Id", "Kin Mainnet ; December 2018"},

{"Api_Key", "SuperSecretYo"},

{"Swagger_Enabled", "True"}

## triggers 
Start the app, it will build the database and tables for you.  Then create the 3 triggers below

"update app and paging token trigger.sql" should be set to before insert on app_operation table

"update app metric new wallet & add user wallet & add payment.sql" should be set to after insert on app_operation table

"update app metric new wallet & add user wallet & add payment.sql" should be set to after insert on app_payment table
