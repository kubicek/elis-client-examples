# Elis API client examples in Python

In this example we send an invoice as a PDF or PNG document to Elis API, obtain the document id, then wait for the result by polling and get the extracted data in JSON format.

It uses the [requests](http://docs.python-requests.org/en/master/) library for as an HTTP client and [polling](https://github.com/justiniso/polling) See
article [Using the Polling module in Python](https://medium.com/@justiniso/using-the-polling-module-in-python-87052d7da4d9) for more details. See also https://github.com/rossumai/rir-tocsv.

Install dependencies:

```
pip install polling requests
```

## Usage

```
usage: elis_client_example.py [-h] [-s SECRET_KEY] [-u BASE_URL] DOCUMENT_PATH

Elis API client example.

positional arguments:
  DOCUMENT_PATH         Document path (PDF/PNG)

optional arguments:
  -h, --help            show this help message and exit
  -s SECRET_KEY, --secret-key SECRET_KEY
                        Secret API key
  -u BASE_URL, --base-url BASE_URL
                        Base API URL
```

We can send the invoice and get the extracted JSON by running:

```
python elis_client_example.py ../data/invoice.pdf -s xxxxxxxxxxxxxxxxxxxxxx_YOUR_ELIS_API_KEY_xxxxxxxxxxxxxxxxxxxxxxx
```

### Example output

```
Submitting document: ../data/invoice.pdf
Document id: e736c1d21fd08abbc258fb6a
{'message': 'Processing invoice...', 'status': 'processing'}
{'message': 'Processing invoice...', 'status': 'processing'}
{'message': 'Processing invoice...', 'status': 'processing'}
{'message': 'Processing invoice...', 'status': 'processing'}
{'message': 'Processing invoice...', 'status': 'processing'}
{'message': 'Processing invoice...', 'status': 'processing'}
{'message': 'Processing invoice...', 'status': 'processing'}
{'message': 'Processing invoice...', 'status': 'processing'}
{'message': 'Processing invoice...', 'status': 'processing'}
{'message': 'Processing invoice...', 'status': 'processing'}
{'message': 'Processing invoice...', 'status': 'processing'}
Extracted data:
{
    "fields": [
        {
            "title": "Bank Account",
            "value": "00375152",
            "score": 0.957390591633303,
            "page": 0,
            "bbox": [
                745,
                1626,
                833,
                1644
            ],
            "content": "00375152",
            "value_type": "text",
            "name": "account_num",
            "checks": {}
        },
        {
            "title": "Sort Code",
            "value": "40-02-02",
            "score": 0.9703049020571556,
            "page": 0,
            "bbox": [
                571,
                1620,
                645,
                1644
            ],
            "content": "40-02-02",
            "value_type": "text",
            "name": "bank_num",
            "checks": {}
        },
        {
            "title": "Tax Base Total",
            "value": "25474.00",
            "score": 0.8983528999867364,
            "page": 0,
            "bbox": [
                953,
                1122,
                1077,
                1158
            ],
            "content": "25,474.00",
            "value_type": "number",
            "name": "amount_total_base",
            "checks": {}
        },
        {
            "title": "Tax Total",
            "value": "5094.80",
            "score": 0.9294690197146265,
            "page": 0,
            "bbox": [
                968,
                1170,
                1078,
                1206
            ],
            "content": "5,094.80",
            "value_type": "number",
            "name": "amount_total_tax",
            "checks": {
                "amount_equations": "good"
            }
        },
        {
            "title": "Tax Total",
            "value": "25474.00",
            "score": 0.7885435252091348,
            "page": 0,
            "bbox": [
                954,
                1128,
                1078,
                1158
            ],
            "content": "25,474.00",
            "value_type": "number",
            "name": "amount_total_tax",
            "checks": {
                "amount_equations": "bad"
            }
        },
        {
            "title": "Total Amount",
            "value": "30568.80",
            "score": 0.9425718537569309,
            "page": 0,
            "bbox": [
                959,
                1236,
                1075,
                1278
            ],
            "content": "30,568.80",
            "value_type": "number",
            "name": "amount_total",
            "checks": {
                "amount_equations": "good"
            }
        },
        {
            "title": "Amount Due",
            "value": "30568.80",
            "score": 0.9693305559666132,
            "page": 0,
            "bbox": [
                962,
                1236,
                1076,
                1278
            ],
            "content": "30,568.80",
            "value_type": "number",
            "name": "amount_due",
            "checks": {
                "amount_equations": "good"
            }
        },
        {
            "title": "Amount Due",
            "value": "5094.80",
            "score": 0.8528612735351506,
            "page": 0,
            "bbox": [
                965,
                1170,
                1079,
                1206
            ],
            "content": "5,094.80",
            "value_type": "number",
            "name": "amount_due",
            "checks": {
                "amount_equations": "bad"
            }
        },
        {
            "title": "Issue Date",
            "value": "2014-05-01",
            "score": 0.9253548980242836,
            "page": 0,
            "bbox": [
                406,
                486,
                562,
                516
            ],
            "content": "1st May 2014",
            "value_type": "date",
            "name": "date_issue",
            "checks": {}
        },
        {
            "title": "Tax Point Date",
            "value": "2014-05-01",
            "score": 0.7686480680711036,
            "page": 0,
            "bbox": [
                405,
                498,
                561,
                516
            ],
            "content": "1St May 2014",
            "value_type": "date",
            "name": "date_uzp",
            "checks": {}
        },
        {
            "title": "Date Due",
            "value": "2014-05-01",
            "score": 0.8929166075893362,
            "page": 0,
            "bbox": [
                405,
                486,
                561,
                516
            ],
            "content": "1st May 2014",
            "value_type": "date",
            "name": "date_due",
            "checks": {}
        },
        {
            "title": "Invoice Identifier",
            "value": "MSG/5946",
            "score": 0.8109326838759122,
            "page": 0,
            "bbox": [
                402,
                750,
                538,
                780
            ],
            "content": "MSG/5946",
            "value_type": "text",
            "name": "invoice_id",
            "checks": {}
        },
        {
            "title": "Supplier VAT Number",
            "value": "832776212",
            "score": 0.899231131723511,
            "page": 0,
            "bbox": [
                401,
                846,
                551,
                876
            ],
            "content": "832 7762 12",
            "value_type": "text",
            "name": "sender_dic",
            "checks": {}
        },
        {
            "title": "Supplier Name",
            "value": "Gardiner & Theobald LLP",
            "score": 0.8598526967119424,
            "page": 0,
            "bbox": [
                850,
                168,
                1068,
                198
            ],
            "content": "Gardiner & Theobald LLP",
            "value_type": "text",
            "name": "sender_name",
            "checks": {}
        },
        {
            "title": "Supplier Name",
            "value": "Management Services",
            "score": 0.8115931665953814,
            "page": 0,
            "bbox": [
                848,
                192,
                1040,
                216
            ],
            "content": "Management Services",
            "value_type": "text",
            "name": "sender_name",
            "checks": {}
        },
        {
            "title": "Supplier Address",
            "value": "Glasgow G2 1DY",
            "score": 0.915607217191693,
            "page": 0,
            "bbox": [
                849,
                252,
                995,
                276
            ],
            "content": "Glasgow G2 1DY",
            "value_type": "text",
            "name": "sender_addrline",
            "checks": {}
        },
        {
            "title": "Supplier Address",
            "value": "5 George Square",
            "score": 0.9012883570935182,
            "page": 0,
            "bbox": [
                847,
                234,
                993,
                258
            ],
            "content": "5 George Square",
            "value_type": "text",
            "name": "sender_addrline",
            "checks": {}
        },
        {
            "title": "Supplier Address",
            "value": "The G1 Building",
            "score": 0.9138018679051039,
            "page": 0,
            "bbox": [
                849,
                210,
                985,
                240
            ],
            "content": "The G1 Building",
            "value_type": "text",
            "name": "sender_addrline",
            "checks": {}
        },
        {
            "title": "Supplier Address",
            "value": "Management Services",
            "score": 0.7961360167425722,
            "page": 0,
            "bbox": [
                847,
                192,
                1043,
                216
            ],
            "content": "Management Services",
            "value_type": "text",
            "name": "sender_addrline",
            "checks": {}
        },
        {
            "title": "Recipient Name",
            "value": "FIFE COLLEGE",
            "score": 0.9300391324295865,
            "page": 0,
            "bbox": [
                405,
                528,
                585,
                564
            ],
            "content": "FIFE COLLEGE",
            "value_type": "text",
            "name": "recipient_name",
            "checks": {}
        },
        {
            "title": "Recipient Name",
            "value": "Provision of Project Management Services",
            "score": 0.7615426582066985,
            "page": 0,
            "bbox": [
                -282,
                1020,
                570,
                1050
            ],
            "content": "Provision of Project Management Services",
            "value_type": "text",
            "name": "recipient_name",
            "checks": {}
        },
        {
            "title": "Recipient Name",
            "value": "Estates Strategy Planning & Busi",
            "score": 0.762418990561947,
            "page": 0,
            "bbox": [
                240,
                1044,
                570,
                1080
            ],
            "content": "Estates Strategy Planning & Busi",
            "value_type": "text",
            "name": "recipient_name",
            "checks": {}
        },
        {
            "title": "Recipient Address",
            "value": "Pittsburgh Road",
            "score": 0.9549529936833119,
            "page": 0,
            "bbox": [
                404,
                558,
                586,
                594
            ],
            "content": "Pittsburgh Road",
            "value_type": "text",
            "name": "recipient_addrline",
            "checks": {}
        },
        {
            "title": "Recipient Address",
            "value": "Dunfermline",
            "score": 0.8954835443058989,
            "page": 0,
            "bbox": [
                406,
                588,
                546,
                624
            ],
            "content": "Dunfermline",
            "value_type": "text",
            "name": "recipient_addrline",
            "checks": {}
        },
        {
            "title": "Recipient Address",
            "value": "KY11 8DY",
            "score": 0.9039893288574521,
            "page": 0,
            "bbox": [
                402,
                618,
                532,
                654
            ],
            "content": "KY11 8DY",
            "value_type": "text",
            "name": "recipient_addrline",
            "checks": {}
        },
        {
            "title": "Tax Details",
            "score": 0.8731676478204003,
            "page": 0,
            "bbox": [
                406,
                1170,
                438,
                1200
            ],
            "content": [
                {
                    "title": "Tax Rate",
                    "value": "20",
                    "score": 0.9148564406702246,
                    "page": 0,
                    "bbox": [
                        406,
                        1170,
                        438,
                        1200
                    ],
                    "content": "20",
                    "value_type": "number",
                    "name": "tax_detail_rate",
                    "checks": {}
                },
                {
                    "title": "Tax Amount",
                    "value": "5094.80",
                    "score": 0.8731676478204003,
                    "page": 0,
                    "bbox": [
                        967,
                        1170,
                        1077,
                        1206
                    ],
                    "content": "5,094.80",
                    "value_type": "number",
                    "name": "tax_detail_tax",
                    "checks": {
                        "amount_equations": "good"
                    }
                }
            ],
            "name": "tax_details"
        }
    ],
    "text_lines": {
        "title": "Rough Content",
        "content": [
            [
                "\u00d3Qrdlner Jheobold Gardiner & Theobald LLP\n",
                "Management Services\n",
                "The G1 Building\n",
                "5 George Square\n",
                "Glasgow G2 1DY\n",
                ". T 4440)141 568 7333\n",
                "r 568 7345\n",
                "e: gtmsglasgowQgardinercom\n",
                "www.gardiner.com\n",
                "Invoice\n",
                "J\n",
                "Date & Tax Point 1st May 2014                                                         \u019f\u019f\u019f\u011a                       |\n",
                "3                             q                          |\n",
                "To                    F\u00c9FE COLLEGE                     \u201eFife COIE\u010cC: : .\n",
                "7 Pittsburgh Road                                                         \u0159   \u2013\u00da             ,|\n",
                "Dunfermline 1 & May 101t          I .\n",
                "4 KY11 8DY                                                                                                                    !\n",
                "F.A.O. Mr Davie Neilson                                                                      |\n",
                "RECEIVED s                          |\n",
                "\"                            |\n",
                "Invoice No MSG/5946 !\n",
                "Job Ref 88/31035/05                                                                                     \u011a\n",
                "VAT Reg. No. 832 7762 12                                                                                           \u0161\n",
                " .\n",
                "FIFE COLLEGE E            ;\n",
                "To:                                                                                                                                                                              z\n",
                "Provision of Project Management Services                                                                                       4\n",
                "relative to Estates Strategy Planning & Business Case 25,474.00                  :\n",
                "\u017e\n",
                ". Sub Total Exclusive of VAT 25,474.00                     ==\n",
                "]\n",
                "Value Added Tax Q 20% 5,094.80 /\n",
                "TOTAL AMOUNT DUE                L&M\u2026 E30,568.80            j\n",
                "3                                                                                                              j\n",
                "DI               |\n",
                ".\n",
                "j\n",
                "D                  |\n",
                "MXRWR\u017dLM\u019fZSG                                                                                                                                            :\n",
                "i\n",
                "i\n",
                ". Cheques to be made payable to Gardiner Theobald LLP alternatively payment may be made directly to our bank account:                         :\n",
                "HSBC Bank PLC Sort Code 40-02-02  Account No. 00375152                                                                  ]\n",
                "Gardiner & Theobald LLP s a iniedliablity partnerahip (Regulated by RICS) which is England and Wales with regitered No. 0C307124                                   |L\n",
                "A liet of membars' names j avalable for inspaction at 10 South Crescenl, London WC1E 78D,the frm'sprincipal place of business and registred office                               |\n",
                "                                                                                              \u00fdl\n\n"
            ]
        ],
        "name": "text_lines"
    },
    "full_text": {
        "title": "Rough Content",
        "content": [
            "\u00d3Qrdlner Jheobold Gardiner & Theobald LLP\n",
            "Management Services\n",
            "The G1 Building\n",
            "5 George Square\n",
            "Glasgow G2 1DY\n",
            ". T 4440)141 568 7333\n",
            "r 568 7345\n",
            "e: gtmsglasgowQgardinercom\n",
            "www.gardiner.com\n",
            "Invoice\n",
            "J\n",
            "Date & Tax Point 1st May 2014                                                         \u019f\u019f\u019f\u011a                       |\n",
            "3                             q                          |\n",
            "To                    F\u00c9FE COLLEGE                     \u201eFife COIE\u010cC: : .\n",
            "7 Pittsburgh Road                                                         \u0159   \u2013\u00da             ,|\n",
            "Dunfermline 1 & May 101t          I .\n",
            "4 KY11 8DY                                                                                                                    !\n",
            "F.A.O. Mr Davie Neilson                                                                      |\n",
            "RECEIVED s                          |\n",
            "\"                            |\n",
            "Invoice No MSG/5946 !\n",
            "Job Ref 88/31035/05                                                                                     \u011a\n",
            "VAT Reg. No. 832 7762 12                                                                                           \u0161\n",
            " .\n",
            "FIFE COLLEGE E            ;\n",
            "To:                                                                                                                                                                              z\n",
            "Provision of Project Management Services                                                                                       4\n",
            "relative to Estates Strategy Planning & Business Case 25,474.00                  :\n",
            "\u017e\n",
            ". Sub Total Exclusive of VAT 25,474.00                     ==\n",
            "]\n",
            "Value Added Tax Q 20% 5,094.80 /\n",
            "TOTAL AMOUNT DUE                L&M\u2026 E30,568.80            j\n",
            "3                                                                                                              j\n",
            "DI               |\n",
            ".\n",
            "j\n",
            "D                  |\n",
            "MXRWR\u017dLM\u019fZSG                                                                                                                                            :\n",
            "i\n",
            "i\n",
            ". Cheques to be made payable to Gardiner Theobald LLP alternatively payment may be made directly to our bank account:                         :\n",
            "HSBC Bank PLC Sort Code 40-02-02  Account No. 00375152                                                                  ]\n",
            "Gardiner & Theobald LLP s a iniedliablity partnerahip (Regulated by RICS) which is England and Wales with regitered No. 0C307124                                   |L\n",
            "A liet of membars' names j avalable for inspaction at 10 South Crescenl, London WC1E 78D,the frm'sprincipal place of business and registred office                               |\n",
            "                                                                                              \u00fdl\n\n"
        ],
        "name": "full_text"
    },
    "original_pages": [
        "https://all.rir.rossum.ai/img/o_e736c1d21fd08abbc258fb6a_0.png"
    ],
    "previews": [
        "https://all.rir.rossum.ai/img/e736c1d21fd08abbc258fb6a_0.png"
    ],
    "preview": "https://all.rir.rossum.ai/img/e736c1d21fd08abbc258fb6a_0.png",
    "status": "ready",
    "language": "eng",
    "currency": "gbp"
}
```
