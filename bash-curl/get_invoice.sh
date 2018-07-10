invoice_id=$1
endpoint='https://all.rir.rossum.ai'
curl -H "Authorization: secret_key $ELIS_API_KEY" $endpoint/document/$invoice_id
