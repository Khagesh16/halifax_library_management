#bat file
echo "executing SQL Scripts in DB"
mysql -p -u root sys < new_tables.sql
echo "executing the python to import data from authors.json to mongo"
echo "stage 1"
echo "converting authors.json to articles_after_cleaning.json"
echo "converting authors.json to articles.json"
python data2mongo.py
timeout 3
echo "droping the collections authors"
mongo project --eval "db.authors.drop()"
echo "dropping the collection articles"
mongo project --eval "db.articles.drop()"
echo "importing to authors.json to Mongo"
mongoimport --host 127.0.0.1:27017 --db project --collection authors --type json --file authors.json --jsonArray
timeout 3
echo "importing to articles_after_clearning.json to articles"
mongoimport --host 127.0.0.1:27017 --db project --collection articles --type json --file articles_after_cleaning.json --jsonArray
timeout 3
echo "processing data Mongo --> SQL"
python mongo2sql.py
chrome localhost

