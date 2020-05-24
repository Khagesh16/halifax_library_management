from pymongo import MongoClient
import mysql.connector
from mysql.connector import Error
from datetime import datetime

connection = mysql.connector.connect(host="localhost", database="project",
                                     user="root", password="Vgec@1234")

mycursor = connection.cursor(buffered=True)

client = MongoClient('localhost', 27017)
# connection=Connection('localhost',27017)
db = client.project
collection = db.articles
query = {"id": {"$lt": "500"}}
doc = collection.find()

insertArticles = "insert into p_articles (article_id,title,page_no,publication_id) values (%s,%s,%s,%s)"
insertMagazine = "insert into p_magazine (magazine_id,magazine_name) values (%s,%s)"
insertPublish = "insert into p_publication (volume_number,published_date,magazine_id) values (%s,%s,%s)"
insertAuthor = "insert into p_author (_id,lname,fname) values (%s,%s,%s)"
author_article = "insert into p_author_articles(author_id,article_id) values (%s,%s)"
selectID = "select publication_id from p_publication where volume_number=%s and magazine_id=%s"
error = 0
count = 0
journal = []
authors = []
for dic in doc:
    count += 1
    try:
        if dic["journal"] not in journal:
            journal.append(dic["journal"])
            magazine = (journal.index(dic["journal"]) + 1, dic["journal"])
            mycursor.execute(insertMagazine, magazine)
            connection.commit()

        #print(dic["journal"])
        publish = (int(dic["volume"]), datetime.strptime(str(dic["year"]), '%Y'), journal.index(dic["journal"]) + 1)
        mycursor.execute(insertPublish, publish)
        connection.commit()
        pubID = (int(dic["volume"]), journal.index(dic["journal"]) + 1)
        mycursor.execute(selectID, pubID)
        record = mycursor.fetchone()
        articles = (dic["id"], dic["title"], dic["pages"], record[0])
        mycursor.execute(insertArticles, articles)
        connection.commit()

        error += 1

        for author in dic["author"]:
            # print(dic["authors"])
            try:
                if author not in authors:
                    authors.append(author)
                    name = author.split(" ")
                # print(authors)
                    authInsert = (authors.index(author) + 1, name[1], name[0])
                    mycursor.execute(insertAuthor, authInsert)
                    connection.commit()
                    AuthorArticle = (authors.index(author) + 1, dic["id"])
                    mycursor.execute(author_article, AuthorArticle)
                    connection.commit()
                else:
                    AuthorArticle = (authors.index(author) + 1, dic["id"])
                    mycursor.execute(author_article, AuthorArticle)
                    connection.commit()



            except Exception as e:
                print(repr(e))

    except Exception as e:
        print(repr(e))

# print(type(dic["page"]))


# print(error)
