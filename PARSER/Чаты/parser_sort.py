import json
import csv
class Pars:
    def __init__(self, name):
        with open(f'{name}', encoding="utf8") as f:
            self.my_dict = json.load(f)
        self.k=0
        self.lst = []
        for key in self.my_dict:
            if key == 'admins':
                continue
            else:
                for key2 in self.my_dict[key]:
                    if self.my_dict[key][key2]['username'] is not None and self.my_dict[key][key2]["bot"] == False and self.my_dict[key][key2]['deleted']== False and self.my_dict[key][key2]['scam'] == False:
                        self.lst.append('@'+self.my_dict[key][key2]['username'])
                        self.k+=1
        print(f'In chat {self.k} members')
        input_in_csv(self.k,self.lst)

def input_in_csv(k,lst):
    with open(f'chat{k}.csv','w',newline = '\n') as f:
            writer = csv.writer(f)
            writer.writerow(['username'])
            for i in range(len(lst)):
                writer.writerow([lst[i]])
    print("Success")
        
def sub_check(name, _set = set()):
    with open(f'{name}', encoding= "utf8") as f1:
        f1_reader = csv.reader(f1, delimiter = ",")
        count = 0
        for row in f1_reader:
            if count == 0:
                print(f'Файл содержит столбцы: {", ".join(row)}')
            else:
                _set.add(row[0])
                
            count += 1
    print(f'Всего в файле {count} строк.')
def check(name1,name2):
    set1 = set()
    set2 = set()
    sub_check(name1,set1)
    sub_check(name2,set2)
    print(f'Individuals: {len(set1.symmetric_difference(set2))}')
    set3 = list(set1.symmetric_difference(set2))
    input_in_csv(len(set3),set3)
    
if __name__ == "__main__":
    #P = Pars('D:\PARSER\Чаты\Допомога ВПО від УВКБ ООН💙💛\Участники Допомога ВПО від УВКБ ООН💙💛.json')
    check("chat30404.csv","Допомога ВПО від УВКБ ООН.csv")