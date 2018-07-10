# Elis API client examples in Python

See also https://github.com/rossumai/rir-tocsv.

## `requests`

- [requests](http://docs.python-requests.org/en/master/)

```
import requests
import json

api_key = 'xxxxxxxxxxxxxxxxxxxxxx_YOUR_ELIS_API_KEY_xxxxxxxxxxxxxxxxxxxxxxx'
endpoint = 'https://all.rir.rossum.ai/'
 # do not use requests.auth.HTTPBasicAuth
auth_header = {'Authorization': 'secret_key ' + api_key}

with open('invoice.pdf', 'rb') as f:
    response = requests.post(
        endpoint + '/document',
        files={'file': f},
        headers=auth_header)
    submitted_response = json.loads(response.text)
    doc_id = submitted_response['id']

# Get document - status is either "processing", or "ready"
response = requests.get(endpoint + 'document/' + doc_id, headers=auth_header)
invoice = json.loads(response.text)
```

PNG:

```
with open('invoice.png', 'rb') as f:
    response = requests.post(
        endpoint + '/document',
        files={'file': ('invoice.png', f, 'image/png')},
        headers=auth_header)
```

## `requests` + `polling`

Polling using the `[https://github.com/justiniso/polling](polling)` library. See
article [Using the Polling module in Python](https://medium.com/@justiniso/using-the-polling-module-in-python-87052d7da4d9) for more details.

```
import polling
import requests
import json

api_key = 'xxxxxxxxxxxxxxxxxxxxxx_YOUR_ELIS_API_KEY_xxxxxxxxxxxxxxxxxxxxxxx'

def is_done(response):
    return json.loads(response.text)['status'] != 'processing'

with open('invoice.pdf', 'rb') as f:
    response = requests.post(
        endpoint + '/document',
        files={'file': f},
        headers=auth_header)
    submitted_response = json.loads(response.text)
    doc_id = submitted_response['id']

submitted_response = json.loads(response.text)
print(submitted_response['id'])

polled_result = polling.poll(
    lambda: requests.get(endpoint + 'document/' + doc_id, headers=auth_header),
    check_success=is_done,
    step=2,
    timeout=60)

invoice = json.loads(polled_result.text)
```
