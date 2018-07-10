invoice_file=$1
endpoint='https://all.rir.rossum.ai'
curl -H "Authorization: secret_key $ELIS_API_KEY" -X POST -F file="@$invoice_file;type=image/png" $endpoint/document
