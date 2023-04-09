import requests
from settings import url


def postToBackEnd(id, body, method):
    err = False
    message = ''

    if '' in body.values():
        data = {'chat_id': id}
    else:
        data = {key: value for key, value in body.items() if value != ''}
        data['chat_id'] = id

    try:
        response = requests.post(url + method, data=data)
        message = response.text
        if response.status_code != 200:
            err = True
    except:
        err = True
        message = f'Произошла ошибка при отправке запроса на сервер, попробуйте позже.'

    return err, response.text


def postToBackEndWithAddition(id, addition, body, method):
    err = False
    message = ''
    data = {body.name: body.text,
            addition.name: addition.text,
            'chat_id': id}
    try:
        response = requests.post(url + method, data=data)
        message = response.text
    except:
        err = True
        message = f'Произошла ошибка при отправке запроса на сервер, попробуйте позже.'
    return err, response.text
