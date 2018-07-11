# Elis API client example in PHP & cURL

It shows how to upload the document file (PDF/PNG), get it's document id, poll for the result and obtain the extracted data.

For simplicity we run PHP on Apache in Docker:

```
docker run -it --rm -p 8000:80 --name elis_client_example_php -v "$PWD":/var/www/html php:7.0-apache
```

## Usage

Fill your secret key to [submit_invoice.php](submit_invoice.php) and set the invoice path:

```
$API_KEY = 'xxxxxxxxxxxxxxxxxxxxxx_YOUR_ELIS_API_KEY_xxxxxxxxxxxxxxxxxxxxxxx';
$document_path = 'invoice.pdf';
```

Put invoice PDF/PNG files into the current directory (which is mounted to `/var/www/html` within the container):

```
cp ../data/* .
```

Open [http://locahost:8000/submit_invoice.php](http://locahost:8000/submit_invoice.php) in your browser.

The result should look like the following. You can open the extraction result page at the `Rossum JavaScript API client` link to see the results visually.

### Example output

```
File uploaded successfully (3ea61ded5c273b96c4a0e3f9).
After 5 seconds, the status was still processing.
After 10 seconds, the status was still processing.
After 15 seconds, the status was still processing.
After 20 seconds, the status was still processing.
After 25 seconds, the status was still processing.
After 30 seconds, the status was still processing.
After 35 seconds, the status was still processing.
After 40 seconds, the status was still processing.
After 45 seconds, the document has been processed.
Check the results here:
Rossum JavaScript API client


{
    "currency": "gbp",
    "fields": [
        {
            "bbox": [
                745,
                1626,
                833,
                1644
            ],
            "checks": [],
            "content": "00375152",
            "name": "account_num",
            "page": 0,
            "score": 0.9573905916333,
            "title": "Bank Account",
            "value": "00375152",
            "value_type": "text"
        },
        {
            "bbox": [
                571,
                1620,
                645,
                1644
            ],
            "checks": [],
            "content": "40-02-02",
            "name": "bank_num",
            "page": 0,
            "score": 0.97030490205716,
            "title": "Sort Code",
            "value": "40-02-02",
            "value_type": "text"
        },
        {
            "bbox": [
                953,
                1122,
                1077,
                1158
            ],
            "checks": [],
            "content": "25,474.00",
            "name": "amount_total_base",
            "page": 0,
            "score": 0.89835289998674,
            "title": "Tax Base Total",
            "value": "25474.00",
            "value_type": "number"
        },
        {
            "bbox": [
                968,
                1170,
                1078,
                1206
            ],
            "checks": {
                "amount_equations": "good"
            },
            "content": "5,094.80",
            "name": "amount_total_tax",
            "page": 0,
            "score": 0.92946901971463,
            "title": "Tax Total",
            "value": "5094.80",
            "value_type": "number"
        },
        {
            "bbox": [
                954,
                1128,
                1078,
                1158
            ],
            "checks": {
                "amount_equations": "bad"
            },
            "content": "25,474.00",
            "name": "amount_total_tax",
            "page": 0,
            "score": 0.78854352520913,
            "title": "Tax Total",
            "value": "25474.00",
            "value_type": "number"
        },
        {
            "bbox": [
                959,
                1236,
                1075,
                1278
            ],
            "checks": {
                "amount_equations": "good"
            },
            "content": "30,568.80",
            "name": "amount_total",
            "page": 0,
            "score": 0.94257185375693,
            "title": "Total Amount",
            "value": "30568.80",
            "value_type": "number"
        },
        {
            "bbox": [
                962,
                1236,
                1076,
                1278
            ],
            "checks": {
                "amount_equations": "good"
            },
            "content": "30,568.80",
            "name": "amount_due",
            "page": 0,
            "score": 0.96933055596661,
            "title": "Amount Due",
            "value": "30568.80",
            "value_type": "number"
        },
        {
            "bbox": [
                965,
                1170,
                1079,
                1206
            ],
            "checks": {
                "amount_equations": "bad"
            },
            "content": "5,094.80",
            "name": "amount_due",
            "page": 0,
            "score": 0.85286127353515,
            "title": "Amount Due",
            "value": "5094.80",
            "value_type": "number"
        },
        {
            "bbox": [
                406,
                486,
                562,
                516
            ],
            "checks": [],
            "content": "1st May 2014",
            "name": "date_issue",
            "page": 0,
            "score": 0.92535489802428,
            "title": "Issue Date",
            "value": "2014-05-01",
            "value_type": "date"
        },
        {
            "bbox": [
                405,
                498,
                561,
                516
            ],
            "checks": [],
            "content": "1St May 2014",
            "name": "date_uzp",
            "page": 0,
            "score": 0.7686480680711,
            "title": "Tax Point Date",
            "value": "2014-05-01",
            "value_type": "date"
        },
        {
            "bbox": [
                405,
                486,
                561,
                516
            ],
            "checks": [],
            "content": "1st May 2014",
            "name": "date_due",
            "page": 0,
            "score": 0.89291660758934,
            "title": "Date Due",
            "value": "2014-05-01",
            "value_type": "date"
        },
        {
            "bbox": [
                402,
                750,
                538,
                780
            ],
            "checks": [],
            "content": "MSG\/5946",
            "name": "invoice_id",
            "page": 0,
            "score": 0.81093268387591,
            "title": "Invoice Identifier",
            "value": "MSG\/5946",
            "value_type": "text"
        },
        {
            "bbox": [
                401,
                846,
                551,
                876
            ],
            "checks": [],
            "content": "832 7762 12",
            "name": "sender_dic",
            "page": 0,
            "score": 0.89923113172351,
            "title": "Supplier VAT Number",
            "value": "832776212",
            "value_type": "text"
        },
        {
            "bbox": [
                850,
                168,
                1068,
                198
            ],
            "checks": [],
            "content": "Gardiner & Theobald LLP",
            "name": "sender_name",
            "page": 0,
            "score": 0.85985269671194,
            "title": "Supplier Name",
            "value": "Gardiner & Theobald LLP",
            "value_type": "text"
        },
        {
            "bbox": [
                848,
                192,
                1040,
                216
            ],
            "checks": [],
            "content": "Management Services",
            "name": "sender_name",
            "page": 0,
            "score": 0.81159316659538,
            "title": "Supplier Name",
            "value": "Management Services",
            "value_type": "text"
        },
        {
            "bbox": [
                849,
                252,
                995,
                276
            ],
            "checks": [],
            "content": "Glasgow G2 1DY",
            "name": "sender_addrline",
            "page": 0,
            "score": 0.91560721719169,
            "title": "Supplier Address",
            "value": "Glasgow G2 1DY",
            "value_type": "text"
        },
        {
            "bbox": [
                847,
                234,
                993,
                258
            ],
            "checks": [],
            "content": "5 George Square",
            "name": "sender_addrline",
            "page": 0,
            "score": 0.90128835709352,
            "title": "Supplier Address",
            "value": "5 George Square",
            "value_type": "text"
        },
        {
            "bbox": [
                849,
                210,
                985,
                240
            ],
            "checks": [],
            "content": "The G1 Building",
            "name": "sender_addrline",
            "page": 0,
            "score": 0.9138018679051,
            "title": "Supplier Address",
            "value": "The G1 Building",
            "value_type": "text"
        },
        {
            "bbox": [
                847,
                192,
                1043,
                216
            ],
            "checks": [],
            "content": "Management Services",
            "name": "sender_addrline",
            "page": 0,
            "score": 0.79613601674257,
            "title": "Supplier Address",
            "value": "Management Services",
            "value_type": "text"
        },
        {
            "bbox": [
                405,
                528,
                585,
                564
            ],
            "checks": [],
            "content": "FIFE COLLEGE",
            "name": "recipient_name",
            "page": 0,
            "score": 0.93003913242959,
            "title": "Recipient Name",
            "value": "FIFE COLLEGE",
            "value_type": "text"
        },
        {
            "bbox": [
                -282,
                1020,
                570,
                1050
            ],
            "checks": [],
            "content": "Provision of Project Management Services",
            "name": "recipient_name",
            "page": 0,
            "score": 0.7615426582067,
            "title": "Recipient Name",
            "value": "Provision of Project Management Services",
            "value_type": "text"
        },
        {
            "bbox": [
                240,
                1044,
                570,
                1080
            ],
            "checks": [],
            "content": "Estates Strategy Planning & Busi",
            "name": "recipient_name",
            "page": 0,
            "score": 0.76241899056195,
            "title": "Recipient Name",
            "value": "Estates Strategy Planning & Busi",
            "value_type": "text"
        },
        {
            "bbox": [
                404,
                558,
                586,
                594
            ],
            "checks": [],
            "content": "Pittsburgh Road",
            "name": "recipient_addrline",
            "page": 0,
            "score": 0.95495299368331,
            "title": "Recipient Address",
            "value": "Pittsburgh Road",
            "value_type": "text"
        },
        {
            "bbox": [
                406,
                588,
                546,
                624
            ],
            "checks": [],
            "content": "Dunfermline",
            "name": "recipient_addrline",
            "page": 0,
            "score": 0.8954835443059,
            "title": "Recipient Address",
            "value": "Dunfermline",
            "value_type": "text"
        },
        {
            "bbox": [
                402,
                618,
                532,
                654
            ],
            "checks": [],
            "content": "KY11 8DY",
            "name": "recipient_addrline",
            "page": 0,
            "score": 0.90398932885745,
            "title": "Recipient Address",
            "value": "KY11 8DY",
            "value_type": "text"
        },
        {
            "bbox": [
                406,
                1170,
                438,
                1200
            ],
            "content": [
                {
                    "bbox": [
                        406,
                        1170,
                        438,
                        1200
                    ],
                    "checks": [],
                    "content": "20",
                    "name": "tax_detail_rate",
                    "page": 0,
                    "score": 0.91485644067022,
                    "title": "Tax Rate",
                    "value": "20",
                    "value_type": "number"
                },
                {
                    "bbox": [
                        967,
                        1170,
                        1077,
                        1206
                    ],
                    "checks": {
                        "amount_equations": "good"
                    },
                    "content": "5,094.80",
                    "name": "tax_detail_tax",
                    "page": 0,
                    "score": 0.8731676478204,
                    "title": "Tax Amount",
                    "value": "5094.80",
                    "value_type": "number"
                }
            ],
            "name": "tax_details",
            "page": 0,
            "score": 0.8731676478204,
            "title": "Tax Details"
        }
    ],
    "full_text": {
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
            "Invoice No MSG\/5946 !\n",
            "Job Ref 88\/31035\/05                                                                                     \u011a\n",
            "VAT Reg. No. 832 7762 12                                                                                           \u0161\n",
            " .\n",
            "FIFE COLLEGE E            ;\n",
            "To:                                                                                                                                                                              z\n",
            "Provision of Project Management Services                                                                                       4\n",
            "relative to Estates Strategy Planning & Business Case 25,474.00                  :\n",
            "\u017e\n",
            ". Sub Total Exclusive of VAT 25,474.00                     ==\n",
            "]\n",
            "Value Added Tax Q 20% 5,094.80 \/\n",
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
        "name": "full_text",
        "title": "Rough Content"
    },
    "language": "eng",
    "original_pages": [
        "https:\/\/all.rir.rossum.ai\/img\/o_3ea61ded5c273b96c4a0e3f9_0.png"
    ],
    "preview": "https:\/\/all.rir.rossum.ai\/img\/3ea61ded5c273b96c4a0e3f9_0.png",
    "previews": [
        "https:\/\/all.rir.rossum.ai\/img\/3ea61ded5c273b96c4a0e3f9_0.png"
    ],
    "status": "ready",
    "text_lines": {
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
                "Invoice No MSG\/5946 !\n",
                "Job Ref 88\/31035\/05                                                                                     \u011a\n",
                "VAT Reg. No. 832 7762 12                                                                                           \u0161\n",
                " .\n",
                "FIFE COLLEGE E            ;\n",
                "To:                                                                                                                                                                              z\n",
                "Provision of Project Management Services                                                                                       4\n",
                "relative to Estates Strategy Planning & Business Case 25,474.00                  :\n",
                "\u017e\n",
                ". Sub Total Exclusive of VAT 25,474.00                     ==\n",
                "]\n",
                "Value Added Tax Q 20% 5,094.80 \/\n",
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
        "name": "text_lines",
        "title": "Rough Content"
    }
}
```

Press `CTRL+C` in the terminal to kill the Docker container.
