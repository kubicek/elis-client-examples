# Elis API client examples

## Docs

https://rossumrir.docs.apiary.io/

## Get API key

Sign up:

- https://rossum.ai/data-capture
- fill: name, email, expected monthly volume of invoices
- "Signup successful! Thank you for signing up. You will receive an email with API access details in no later than a few hours."

```
Enjoy your new account in Rossum's Invoice Extraction API!

  Your authentication secret key is:

        xxxxxxxxxxxxxxxxxxxxxx_YOUR_ELIS_API_KEY_xxxxxxxxxxxxxxxxxxxxxxx

  Your assigned API endpoint is:

        https://all.rir.rossum.ai/

  Please refer to http://docs.rossumrir.apiary.io/ for detailed
documentation of our REST API, and don't hesitate to ask for help
at support@rossum.ai - just reply to this email.

  Tip: You can visualize extracts returned by our API in the JavaScript
client builtin inside our homepage - see the documentation for an
example.

  Kind regards,
                                        Rossum Invoice Robot
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
