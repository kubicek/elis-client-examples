# Extracting invoices with Rossum Elis Extraction API - client examples

These are examples on how to use the Elis Extraction API to automatically process your invoices with AI.

## Docs

https://rossum.ai/developers/api/

## Get API key

Sign up for free (via your Google or GitHub account):

- https://rossum.ai/developers
- "Signup successful! Thank you for signing up. You will receive an email with API access details in no later than a few hours."

```
Enjoy your new account in Rossum's Invoice Extraction API!

  Your authentication secret key is:

        xxxxxxxxxxxxxxxxxxxxxx_YOUR_ELIS_API_KEY_xxxxxxxxxxxxxxxxxxxxxxx

  Your assigned API endpoint is:

        https://all.rir.rossum.ai/

  Please refer to https://rossum.ai/developers/api/ for detailed
documentation of our REST API, and don't hesitate to ask for help
at support@rossum.ai - just reply to this email.

  Tip: You can visualize extracts returned by our API in the JavaScript
client builtin inside our homepage - see the documentation for an
example.

  Kind regards,
                                        Rossum Invoice Robot
```

You can check this information and your API usage in the dashboard: https://api.rossum.ai/

## Python API client & CLI

The easiest way to try out the Elis Extraction API
is the [`rossum`](https://github.com/rossumai/rossum-api-python-client)
Python package that provides a CLI and Python API.

```bash
pip install rossum
export ROSSUM_API_KEY="xxxxxxxxxxxxxxxxxxxxxx_YOUR_ELIS_API_KEY_xxxxxxxxxxxxxxxxxxxxxxx"
rossum extract invoice.pdf invoice.json
```

```python
import rossum
extracted_json = rossum.extract('invoice.pdf')
```

## Examples in various languages

In general we send a document file (with security key) to the Elis API, obtain a document id, wait for it being completed (via polling) and get the extracted data in JSON format.

- [Bash & curl](bash-curl/)
- [Python & requests/polling](python-requests/)
- [Java & unirest & gradle](java-unirest/)
- [Scala & sttp/json4s & sbt](scala-sttp/)
- [Javascript & node.js](javascript-nodejs/)
- [PHP & curl](php-curl/)
- [C#](c-sharp/)

## Example data

- [invoice in PDF](data/invoice.pdf)
- [invoice in PNG](data/invoice.png)
