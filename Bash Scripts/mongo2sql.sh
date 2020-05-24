printf "\nPlease enter the mysql username"
printf "\n"
read  mysql_user

printf "\nPlease enter the mysql host"
printf "\n"
read  mysql_host


printf "\nPlease enter the mysql password"
printf "\n"
read -s mysql_password

printf "\nPlease enter the name of the mysql database"
printf "\n"
read mysql_database

printf "\nPlease enter the name of the  MongoDB"
printf "\n"
read  mongo_database

printf "mongo host"
read mongo_host

printf "Mongo USer"
printf " "
read mongo_user

printf "mongo password"
read mongo_password


echo "$c translated as data file cleaned articles.json"
 
python3 mongo2sql.py $mysql_host $mysql_database $mysql_user $mysql_password $mongo_host $mongo_database $mongo_user $mongo_password

echo "bye"

