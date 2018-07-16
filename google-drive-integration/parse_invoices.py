from __future__ import print_function

from collections import defaultdict
from os import listdir
from os.path import isfile, join
import argparse
import io
import os
import requests
import csv

from apiclient.discovery import build, MediaFileUpload
from apiclient.http import MediaIoBaseDownload
from httplib2 import Http
from oauth2client import file, client, tools
import json

from elis import ElisClient, DEFAULT_API_URL



# Setup the Drive v3 API
SCOPES = 'https://www.googleapis.com/auth/drive'
store = file.Storage('credentials.json')
creds = store.get()
if not creds or creds.invalid:
    flow = client.flow_from_clientsecrets('client_secret.json', SCOPES)
    flags = tools.argparser.parse_args(args=[])
    creds = tools.run_flow(flow, store, flags)
service = build('drive', 'v3', http=creds.authorize(Http()))


def find_rossum_folder():
    page_token = None
    response = service.files().list(q="name='RossumAPI' and mimeType='application/vnd.google-apps.folder'",
                                          spaces='drive',
                                          fields='nextPageToken, files(id, name)',
                                          pageToken=page_token).execute()
    files = response.get('files', [])
    return files[0]

def find_files_in_folder(folder):
    folder_id = folder.get('id')
    q = "'{}' in parents and trashed = false".format(folder_id)
    page_token=None
    response = service.files().list(q=q,
                                    spaces='drive',
                                    fields='nextPageToken, files(id, name)',
                                    pageToken=page_token).execute()
    files = response.get('files', [])
    return files

def find_io_folders(parent_folder):
    files = find_files_in_folder(parent_folder)
    input_folder = [f for f in files if f.get('name') == 'Input'][0]
    output_folder = [f for f in files if f.get('name') == 'Output'][0]
    return input_folder, output_folder

def create_folder(directory):
    try:
        if not os.path.exists(directory):
            os.makedirs(directory)
    except OSError:
        print ('Error: Creating directory. ' + directory)

def download_file(f):
    fid = f.get('id')
    name = f.get('name')
    create_folder('invoices')
    request = service.files().get_media(fileId=fid)
    with io.FileIO(os.path.join('invoices', name), 'wb') as fh:
        downloader = MediaIoBaseDownload(fh, request)
        done = False
        while done is False:
            status, done = downloader.next_chunk()

def download_files(files):
    for f in files:
        download_file(f)

def upload_csv(folder, path):
    fname = os.path.basename(path)
    file_metadata = {
        'name': fname,
        'mimeType': 'application/vnd.google-apps.spreadsheet',
        'parents': [folder.get('id')]
    }
    media = MediaFileUpload(path,
                            mimetype='text/csv',
                            resumable=True)
    file = service.files().create(body=file_metadata,
                                  media_body=media,
                                  fields='id').execute()

def process_elis(client, dirname, invoice_files):
    files = [join(dirname, f['name']) for f in invoice_files]
    def parse_document(fname):
        print('[Elis] Submitting document:', fname)
        send_result = client.send_document(fname)
        document_id = send_result['id']
        print('[Elis] Document id:', document_id)
        return client.get_document(document_id)
    dicts = [parse_document(f) for f in files]
    return dicts

def write_csv(ofname, fieldnames, row):
    with open(ofname, 'w') as csv_fp:
        writer = csv.DictWriter(csv_fp, fieldnames)
        writer.writeheader()
        writer.writerow(row)

def to_csv(invoice_dict):
    fstr = defaultdict(list)
    for f in invoice_dict.get('fields', []):
        if isinstance(f['content'], str):
            fstr[f['title']].append(f['content'])
        else:
            fstr[f['title']].append('\n'.join('%s: %s' % (sf['title'], sf['content']) for sf in f['content']))

    row = dict(status=invoice_dict['status'], preview=invoice_dict.get('preview', ''))
    for k, vl in fstr.items():
        row[k] = '\n'.join(vl)
    return row

def get_rir_fieldnames(url):
    r = requests.get(url + '/fields')
    fields = json.loads(r.text)['names']
    titles = json.loads(r.text)['titles']
    fieldnames = ['filename', 'status', 'preview'] + [titles[f] for f in fields]
    return fieldnames

def dict_to_csv(fieldnames, invoice_dict, ofname):
    row = to_csv(invoice_dict)
    write_csv(ofname, fieldnames, row)

def upload_csvs(parent_folder, dicts, files, fieldnames):
    create_folder('csv')
    for invoice_dict, g_file in zip(dicts, files):
        fname = g_file['name']
        ofname = os.path.join('csv', os.path.basename(fname).split('.')[0] + '.csv')
        dict_to_csv(fieldnames, invoice_dict, ofname)
        upload_csv(parent_folder, ofname)

def parse_args():
    from oauth2client.tools import argparser
    parser = argparse.ArgumentParser(description='Rossum API Google Drive integration.', parents=[argparser])
    parser.add_argument('-s', '--secret-key', help='Secret API key')
    parser.add_argument('-u', '--base-url', default=DEFAULT_API_URL, help='Base API URL')
    return parser.parse_args()

def main():
    args = parse_args()

    ## Find files in the rossum folder
    parent_folder = find_rossum_folder()
    input_folder, output_folder = find_io_folders(parent_folder)
    invoice_files = find_files_in_folder(input_folder)
    download_files(invoice_files)

    ## Process in RIR
    client = ElisClient(args.secret_key, args.base_url)
    invoice_dicts = process_elis(client, 'invoices/', invoice_files)

    ## Upload the results
    fieldnames = get_rir_fieldnames(args.base_url)
    upload_csvs(output_folder, invoice_dicts, invoice_files, fieldnames)

if __name__ == '__main__':
    main()

