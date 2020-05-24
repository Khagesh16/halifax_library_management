import json
import os
from collections import OrderedDict
from time import sleep
import re



def clean(file):
    cwd = os.getcwd()
    print("Cleaning the input file articles.json...")
    parser = json.JSONDecoder()
    parsed = []  
    with open(file) as f:
        data = f.read()
    head = 0  
    while True:
        head = (data.find('{', head) + 1 or data.find('[', head) + 1) - 1
        try:
            struct, head = parser.raw_decode(data, head)
            parsed.append(struct)
        except (ValueError, json.JSONDecodeError): 
            break

    file2 = "output.json"
    with open(file2, 'a+') as f:
        json.dump(parsed, f, indent=2)


def create_author(authors):
    cwd = os.getcwd()
    author_list = list(dict.fromkeys(authors))
    author_info = OrderedDict()
    authorlist = []
    i = 1
    for author in author_list:
        fl=author.split(" ")
        author_info = {
            
                    'id': str(i),
                    'firstname':fl[0],
                    'lastname':fl[-1],
                    'Name':author
            
            }
        i += 1
        authorlist.append(author_info)
    print("Writing the distinct authors names to authors.json..")   
    if (authorlist is not None):
        with open('authors.json', 'a+') as fp:
            json.dump(authorlist, fp, indent=4)     
    

def parse(file):
    
        with open(file) as f:
            data = f.read()
            
        input = json.loads(data)
        regex = re.compile('[^a-zA-Z ]')
        lists = []
        authors = []  
        #print(len(input))
        print("Parsing JSON...")
        
        for i in range(0, len(input)):
            
            try:
                
                article_authors=[]
                if 'pages' in input[i].keys() and 'author' in input[i].keys() and 'title' in input[i].keys() and 'year' in input[i].keys():
                    
                    if len(input[i]['title']) == 2 and 'ftext' in input[i]['title'].keys():
                        # print(input[i]['title']['ftext'])  
                        title = input[i]['title']['ftext']
                            
                        if isinstance(input[i]['pages']['ftext'], str):
                            pages = input[i]['pages']['ftext']
                         
                        year=input[i]['year']['ftext']           
                        volume = input[i]['volume']['ftext']
                        journal = input[i]['journal']['ftext']
                        year = input[i]['year']['ftext']
                        id = i + 1
                            
                        for j in input[i]['author']:
                            if isinstance(j, str) and j == 'ftext':
                                    # print(input[i]['author'][j])
                                
                                author = input[i]['author'][j]
                                author=regex.sub('',author)
                                #articles_info = create_json(id, title, pages, volume, journal, author)
                                article_authors.append(author)
                                authors.append(author)
                                #lists.append(articles_info)
                            elif isinstance(j, dict):
                                    # print(j['ftext'])
                                author = j['ftext']
                                author=regex.sub('',author)
                                authors.append(author)
                                #articles_info = create_json(id, title, pages, volume, journal, author)
                                article_authors.append(author)
                                #lists.append(articles_info)
                            else:
                                continue
                        
                        articles_info= {
                            'id': str(i+1),
                            'title' : title,
                            'year': year,
                            'pages':pages,
                            'volume':volume,
                            'journal':journal,
                            'author': article_authors
                        }
                        lists.append(articles_info)
                        
                   
                   
            except Exception as e:
                print(repr(e))
                
                continue
                
             
        create_author(authors)
        return lists
   
    
if __name__ == "__main__":
    cwd = os.getcwd()
    #print(cwd)
    input_file = "articles.json"
    clean(input_file)
    sleep(5)
    file = "output.json"
    article_info = parse(file)
    print("Writing the file to articles.json..")
    if (article_info is not None):
        with open('articles_after_cleaning.json', 'a+') as fp:
            json.dump(article_info, fp, indent=4)  
    
