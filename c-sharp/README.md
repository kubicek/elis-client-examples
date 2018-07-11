# Elis API client example in C#

Build the example app, submit a document and wait for the result processed by Elis API:

```
dotnet run -- ../data/invoice.pdf https://all.rir.rossum.ai xxxxxxxxxxxxxxxxxxxxxx_YOUR_ELIS_API_KEY_xxxxxxxxxxxxxxxxxxxxxxx
```

Check the source code: [ElisClientExample.cs](ElisClientExample.cs).

Example output:

```
Submitting invoice: ../data/invoice.pdf
Media type: application/pdf
HTTP status code: OK
Submitted invoice with id: d881ea589dc4577c404bd49d
Waiting for invoice: 0 s / 150 s
status: processing, message: Processing invoice...
Waiting for invoice: 5 s / 150 s
status: processing, message: Processing invoice...
Waiting for invoice: 10 s / 150 s
status: processing, message: Processing invoice...
Waiting for invoice: 15 s / 150 s
status: processing, message: Processing invoice...
Waiting for invoice: 20 s / 150 s
status: processing, message: Processing invoice...
Waiting for invoice: 25 s / 150 s
status: processing, message: Processing invoice...
Waiting for invoice: 30 s / 150 s
status: processing, message: Processing invoice...
Waiting for invoice: 35 s / 150 s
status: processing, message: Processing invoice...
Waiting for invoice: 40 s / 150 s
status: processing, message: Processing invoice...
Waiting for invoice: 45 s / 150 s
status: processing, message: Processing invoice...
Waiting for invoice: 50 s / 150 s
status: ready, message:
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
      "checks": {},
      "content": "00375152",
      "name": "account_num",
      "page": 0,
      "score": 0.957390591633303,
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
      "checks": {},
      "content": "40-02-02",
      "name": "bank_num",
      "page": 0,
      "score": 0.9703049020571556,
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
      "checks": {},
      "content": "25,474.00",
      "name": "amount_total_base",
      "page": 0,
      "score": 0.8983528999867364,
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
      "score": 0.9294690197146265,
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
      "score": 0.7885435252091348,
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
      "score": 0.9425718537569309,
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
      "score": 0.9693305559666132,
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
      "score": 0.8528612735351506,
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
      "checks": {},
      "content": "1st May 2014",
      "name": "date_issue",
      "page": 0,
      "score": 0.9253548980242836,
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
      "checks": {},
      "content": "1St May 2014",
      "name": "date_uzp",
      "page": 0,
      "score": 0.7686480680711036,
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
      "checks": {},
      "content": "1st May 2014",
      "name": "date_due",
      "page": 0,
      "score": 0.8929166075893362,
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
      "checks": {},
      "content": "MSG/5946",
      "name": "invoice_id",
      "page": 0,
      "score": 0.8109326838759122,
      "title": "Invoice Identifier",
      "value": "MSG/5946",
      "value_type": "text"
    },
    {
      "bbox": [
        401,
        846,
        551,
        876
      ],
      "checks": {},
      "content": "832 7762 12",
      "name": "sender_dic",
      "page": 0,
      "score": 0.899231131723511,
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
      "checks": {},
      "content": "Gardiner & Theobald LLP",
      "name": "sender_name",
      "page": 0,
      "score": 0.8598526967119424,
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
      "checks": {},
      "content": "Management Services",
      "name": "sender_name",
      "page": 0,
      "score": 0.8115931665953814,
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
      "checks": {},
      "content": "Glasgow G2 1DY",
      "name": "sender_addrline",
      "page": 0,
      "score": 0.915607217191693,
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
      "checks": {},
      "content": "5 George Square",
      "name": "sender_addrline",
      "page": 0,
      "score": 0.9012883570935182,
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
      "checks": {},
      "content": "The G1 Building",
      "name": "sender_addrline",
      "page": 0,
      "score": 0.9138018679051039,
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
      "checks": {},
      "content": "Management Services",
      "name": "sender_addrline",
      "page": 0,
      "score": 0.7961360167425722,
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
      "checks": {},
      "content": "FIFE COLLEGE",
      "name": "recipient_name",
      "page": 0,
      "score": 0.9300391324295865,
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
      "checks": {},
      "content": "Provision of Project Management Services",
      "name": "recipient_name",
      "page": 0,
      "score": 0.7615426582066985,
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
      "checks": {},
      "content": "Estates Strategy Planning & Busi",
      "name": "recipient_name",
      "page": 0,
      "score": 0.762418990561947,
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
      "checks": {},
      "content": "Pittsburgh Road",
      "name": "recipient_addrline",
      "page": 0,
      "score": 0.9549529936833119,
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
      "checks": {},
      "content": "Dunfermline",
      "name": "recipient_addrline",
      "page": 0,
      "score": 0.8954835443058989,
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
      "checks": {},
      "content": "KY11 8DY",
      "name": "recipient_addrline",
      "page": 0,
      "score": 0.9039893288574521,
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
          "checks": {},
          "content": "20",
          "name": "tax_detail_rate",
          "page": 0,
          "score": 0.9148564406702246,
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
          "score": 0.8731676478204003,
          "title": "Tax Amount",
          "value": "5094.80",
          "value_type": "number"
        }
      ],
      "name": "tax_details",
      "page": 0,
      "score": 0.8731676478204003,
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
    "name": "full_text",
    "title": "Rough Content"
  },
  "language": "eng",
  "original_pages": [
    "https://all.rir.rossum.ai/img/o_d881ea589dc4577c404bd49d_0.png"
  ],
  "preview": "https://all.rir.rossum.ai/img/d881ea589dc4577c404bd49d_0.png",
  "previews": [
    "https://all.rir.rossum.ai/img/d881ea589dc4577c404bd49d_0.png"
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
    "name": "text_lines",
    "title": "Rough Content"
  }
}
```
