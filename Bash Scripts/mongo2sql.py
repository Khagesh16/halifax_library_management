from pymongo import MongoClient
import mysql.connector
from mysql.connector import Error
from datetime import datetime
import urllib.parse
import sys

mysql_host=sys.argv[1]
print(mysql_host)
mysql_database=sys.argv[2]
print(mysql_database)
mysql_user=sys.argv[3]
print(mysql_user)
mysql_password=sys.argv[4]
print(mysql_password)

mongo_host=sys.argv[5]
print(mongo_host)
mongo_database=sys.argv[6]
print(mongo_database)
mongo_user=sys.argv[7]
print(mongo_user)
mongo_password=sys.argv[8]

print("The given MySQL connection details are")
print("Host: "+mysql_host)
print("Database: "+mysql_database)
print("User :"+mysql_user)
print("Password :"+mysql_password)

print("")
print("")

print("The given MongoDB connection details are")
print("Host: "+mongo_host)
print("Database: "+mongo_database)
print("User :"+mongo_user)
print("Password :"+mongo_password)

connection=mysql.connector.connect(host=mysql_host,database=mysql_database,
									   user=mysql_user,password=mysql_password)

mycursor=connection.cursor(buffered=True)



client =MongoClient('localhost',username=mongo_user,password=mongo_password,authSource=mongo_database,authMechanism='SCRAM-SHA-1')
#connection=Connection('localhost',27017)
db=client.k_pandya
collection=db.Articles
query={ "id" :{"$lt":"500" }}
doc=collection.find(query)


insertArticles="insert into p_articles (article_id,title,page_no,publication_id) values (%s,%s,%s,%s)"
insertMagazine="insert into p_magazine (magazine_id,magazine_name) values (%s,%s)" 
insertPublish="insert into p_publication (volume_number,published_date,magazine_id) values (%s,%s,%s)" 
insertAuthor="insert into p_author (_id,lname,fname) values (%s,%s,%s)"
author_article="insert into p_author_articles(author_id,article_id) values (%s,%s)"
selectID="select publication_id from p_publication where volume_number=%s and magazine_id=%s"
error=0
count=0
journal=[]
authors=[]
for dic in doc:
	count+=1
	try:
		if dic["journal"] not in journal:   
			journal.append(dic["journal"])
			magazine=(journal.index(dic["journal"])+1,dic["journal"])
			mycursor.execute(insertMagazine,magazine)
			connection.commit()
	
		pubID=(int(dic["volume"]),journal.index(dic["journal"])+1)
		mycursor.execute(selectID,pubID)
		record=mycursor.fetchone()
	
		if record is None:
			publish=(int(dic["volume"]),datetime.strptime(str(dic["year"]),'%Y'),journal.index(dic["journal"])+1)
			mycursor.execute(insertPublish,publish)
			connection.commit()
			pubID=(int(dic["volume"]),journal.index(dic["journal"])+1)
			mycursor.execute(selectID,pubID)
			record=mycursor.fetchone()
			articles=(dic["id"],dic["title"],dic["pages"],record[0])
			mycursor.execute(insertArticles,articles)
			connection.commit()
		else:
			articles=(dic["id"],dic["title"],dic["pages"],record[0])
			mycursor.execute(insertArticles,articles)
			connection.commit()

		for author in dic["author"]:
		#print(dic["authors"])
		
			if author not in authors:
				authors.append(author)
				name=author.split(" ")
			#print(authors)
				authInsert=(authors.index(author)+1,name[1],name[0])
				mycursor.execute(insertAuthor,authInsert)
				connection.commit()
				AuthorArticle=(authors.index(author)+1,int(dic["id"]))
				mycursor.execute(author_article,AuthorArticle)
				connection.commit()
			else:
				AuthorArticle=(authors.index(author)+1,int(dic["id"]))
				mycursor.execute(author_article,AuthorArticle)
				connection.commit()

	except Exception as e:
		print(repr(e))
				

						
print(error)
