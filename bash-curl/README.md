# Elis API client in bash using curl

- specify your API key
- submit your invoice file (PDF or PNG)
  - it returns a document id
- poll for the result using the document id
  - it's either being processed, is succesfully done or it failed
  - in this case get_invoice.sh performs a single query, not a polling loop

```
export ELIS_API_KEY="xxxxxxxxxxxxxxxxxxxxxx_YOUR_ELIS_API_KEY_xxxxxxxxxxxxxxxxxxxxxxx"

./upload_invoice_pdf.sh invoice.pdf
./upload_invoice_png.sh invoice.png
./get_invoice.sh 9d1068d6a13515a6bc0f7879
```

In progress:

```
{"status": "processing", "id": "9d1068d6a13515a6bc0f7879"}
```

Successfully done (it contains a lot of data):

```
{"status": "ready", ...}
```

Error:

```
{"message": "Cannot process input file", "status": "error"}
```
