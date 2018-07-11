from __future__ import division, print_function

import argparse
import json
import os

import requests
import polling

DEFAULT_API_URL='https://all.rir.rossum.ai'

class ElisClient(object):
    """
    Simple client for Rossum Elis API that allows to submit a document for
    extraction and then wait for the processed result.

    Usage:

    ```
    client = ElisClient(secret_key, base_url)
    document_id = client.send_document(document_path)
    extracted_document = client.get_document(document_id)
    ```
    """
    def __init__(self, secret_key, url=DEFAULT_API_URL):
        self.secret_key = secret_key
        self.url = url
        # we do not use requests.auth.HTTPBasicAuth
        self.headers = {'Authorization': 'secret_key ' + self.secret_key}

    def send_document(self, document_path):
        """
        Submits a document to Elis API for extractions.

        Returns: dict with 'id' representing job id
        """
        with open(document_path, 'rb') as f:
            content_type = self._content_type(document_path)
            response = requests.post(
                self.url + '/document',
                files={'file': (os.path.basename(document_path), f, content_type)},
                headers=self.headers)
        return json.loads(response.text)

    @staticmethod
    def _content_type(document_path):
        return 'image/png' if document_path.lower().endswith('.png') else 'application/pdf'

    def get_document_status(self, document_id):
        """
        Gets a single document status.
        """
        response = requests.get(self.url + '/document/' + document_id, headers=self.headers)
        response_json = json.loads(response.text)
        if response_json['status'] != 'ready':
            print(response_json)
        return response_json

    def get_document(self, document_id, max_retries=30, sleep_secs=5):
        """
        Waits for document via polling.
        """
        def is_done(response_json):
            return response_json['status'] != 'processing'

        return polling.poll(
            lambda: self.get_document_status(document_id),
            check_success=is_done,
            step=sleep_secs,
            timeout=int(round(max_retries * sleep_secs)))

def parse_args():
    parser = argparse.ArgumentParser(description='Elis API client example.')
    parser.add_argument('document_path', metavar='DOCUMENT_PATH',
                        help='Document path (PDF/PNG)')
    parser.add_argument('-s', '--secret-key', help='Secret API key')
    parser.add_argument('-u', '--base-url', default=DEFAULT_API_URL, help='Base API URL')

    return parser.parse_args()

def main():
    args = parse_args()
    client = ElisClient(args.secret_key, args.base_url)
    print('Submitting document:', args.document_path)
    send_result = client.send_document(args.document_path)
    document_id = send_result['id']
    print('Document id:', document_id)
    extracted_document = client.get_document(document_id)
    print('Extracted data:')
    print(json.dumps(extracted_document, indent=4))

if __name__ == '__main__':
    main()
