import telebot
from back_end_methods import postToBackEnd, postToBackEndWithAddition
from results import results


# Создаем экземпляр бота
bot_token = '5385172304:AAHGWIaHVnYEGEptulSNUuMIBhiwdc5QIp8'
bot = telebot.TeleBot(bot_token)


def add_reason(message):
    data = {'message': message.text}
    err, response = postToBackEnd(message.chat.id, data, 'AddReason')

    if err:
        bot.send_message(message.chat.id, f'Произошла ошибка при отправке запроса на сервер, попробуйте позже.')
    else:
        bot.send_message(message.chat.id, f'Твоя причина: {message.text}')


def set_reason_price(message):
    data = {'message': message.text }
    addition = {'reason': results[message.chat.id]['reason']}
    chat_id = message.chat.id
    price = message.text
    err, response = postToBackEndWithAddition(message.chat.id, addition, data, 'SetReasonPrice')

    if err:
        bot.send_message(message.chat.id, f'Произошла ошибка при отправке запроса на сервер, попробуйте позже.')
    else:
        results[chat_id]['reason_price'] = price
        bot.send_message(message.chat.id, f'Установлена цена: {message.text}')


def select_reason(message):
    data = {'message': message.text}
    err, response = postToBackEnd(message.chat.id, data, 'SelectReason')
    chat_id = message.chat.id

    if err:
        bot.send_message(message.chat.id, f'Произошла ошибка при отправке запроса на сервер, попробуйте позже.')
    else:
        results[chat_id]['reason'] = message.text
        bot.send_message(message.chat.id, f'Твоя причина: {message.text}')