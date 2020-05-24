#!/bin/bash
printf "Please enter the mysql username "
read mysql_username
printf " "
printf "Please enter the mysql password "
read mysql_password
printf " "
#printf "Please enter the name of the mysql database"
#read -s mysql_database

printf "Please enter the MongoDB user name "
read mongo_username
printf " "
printf "Please enter the MongoDB password "
read  mongo_password
printf " "
printf "Please enter the name of the  MongoDB "
read mongo_database

coll1="Articles"
coll2="Authors"

mysql -u $mysql_username -p  < ./new_tables.sql

python3 data2mongo.py
echo "Writing data to Mongo DB.."
sleep 10
mongo $mongo_database --eval "db.$coll1.drop()"
mongo $mongo_database --eval "db.$coll2.drop()"

mongoimport -d "$mongo_database" -u "$mongo_username" -p "$mongo_password" -c "$coll1" --file "./articles_after_cleaning.json" --jsonArray
mongoimport -d "$mongo_database" -u "$mongo_username" -p "$mongo_password" -c "$coll2" --file "./authors.json" --jsonArray

rm -r output.json

echo "bye"
