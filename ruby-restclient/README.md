# Elis API client example in ruby & RestClient

It shows how to upload the document file (PDF), get it's document id, poll for the result and obtain the extracted data.

## Usage

Install RestClient gem

```
gem install restclient
```

Fill your secret key to [elis_client_example.rb](elis_client_example.rb), set the invoice path, its locale and the endpoint URL:

```
secret_key='xxxxxxxxxxxxxxxxxxxxxx_YOUR_ELIS_API_KEY_xxxxxxxxxxxxxxxxxxxxxxx'
invoice="/path/to/invoice.pdf"
locale="cz_CZ"
endpoint='https://all.rir.rossum.ai'
```

Run this script and profit.
