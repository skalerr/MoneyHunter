import configparser

config = configparser.ConfigParser()
config.read('config.txt')
url = config.get('SETTINGS', 'url')