import time

import requests
from bs4 import BeautifulSoup
from time import sleep
headers = {
    'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36',
    'Accept-Language': 'en-US,en;q=0.9',
    'Connection': 'keep-alive',
    'Upgrade-Insecure-Requests': '1',
    'Cache-Control': 'max-age=0',
}


def download(image_url, pd_code):
    response = requests.get(image_url, stream=True)
    with open('images\\' + pd_code + '_' + image_url.split("/")[-1], 'wb') as r:
        for value in response.iter_content(1024*1024):
            r.write(value)
    print(pd_code + '_' + image_url.split("/")[-1], 'downloaded')


def get_pd_carts():
    for count in range(1, 7):
        url = f'https://newbalance.ua/store/man?page={count}'
        response = requests.get(url)

        soup = BeautifulSoup(response.text, 'lxml')

        data = soup.find_all("li", class_='products__item')

        for pd in data:
            pd_url = pd.find('a', class_='products__link').get('href')
            yield pd_url


def array():
    for card_url in get_pd_carts():
        sleep(0.3)
        response = requests.get(card_url, headers=headers)
        soup = BeautifulSoup(response.text, 'lxml')

        pd_content = soup.find_all('img', class_='lazy-image zoom-img product-img')

        pd_code = soup.find('div', class_='product-info__code').text.split(' ')[-1]

        for image in pd_content:
            image_url = image.get('data-src')
            download(image_url, pd_code)


if __name__ == "__main__":
    array()



