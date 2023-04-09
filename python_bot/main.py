import telebot
import configparser

from back_end_methods import postToBackEnd
from reason_module import add_reason, set_reason_price, select_reason
from results import results

config = configparser.ConfigParser()
config.read('config.txt')
bot_token = config.get('SETTINGS', 'bot_token')

# Создаем экземпляр бота
bot = telebot.TeleBot(bot_token)

# # Обработчик текстовых сообщений
# @bot.message_handler(content_types=['text'])
# def text_message(message):
#     if message.text == '/help':
#         bot.send_message(message.chat.id, 'Напиши привет')
#     else:
#         bot.send_message(message.chat.id, 'Я тебя не понимаю. Напиши /help.')


# Обработчик команды /start
@bot.message_handler(commands=['start'])
def start_command(message):
    data = {'': ''}
    err, response = postToBackEnd(message.chat.id, data, 'AddUser')

    if err:
        bot.send_message(message.chat.id, f'Произошла ошибка при отправке запроса на сервер, попробуйте позже.')
    else:
        bot.send_message(message.chat.id,
                         f'Привет, ты зарегистрирован в системе. Твой айди: {response} \n Список команд: /help')


@bot.message_handler(commands=['help'])
def start_command(message):
    bot.send_message(message.chat.id, f'Список доступных комманд: \n'
                                      f'/add_reason Добавить причину\n'
                                      f'/remove_reason Удалить причину\n'
                                      f'/set_reason_price Установить стоймость причины\n'
                                      f'/imdone Обнулить причину\n')


@bot.message_handler(commands=['add_reason'])
def start_command(message):
    bot.send_message(message.chat.id, f'Введите название причины')
    bot.register_next_step_handler(message, add_reason)  # следующий шаг – функция get_reason
    # help_message(message)


@bot.message_handler(commands=['set_reason_price'])
def start_command(message):
    bot.send_message(message.chat.id, f'Выберите причину')
    bot.register_next_step_handler(message, select_reason)
    bot.send_message(message.chat.id, f'Введите cтоймость причины')
    bot.register_next_step_handler(message, set_reason_price)
    # help_message(message)



def help_message(message):
    bot.send_message(message.chat.id, f'Список доступных комманд: \n'
                                      f'/add Добавить причину\n'
                                      f'/remove Удалить причину\n'
                                      f'/set Установить стоймость причины\n'
                                      f'/imdone Обнулить причину\n')


# Запускаем бота
bot.polling(none_stop=True, interval=0)
