using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.Utilities
{
    public class ExcelClient : IDisposable
    {

        public ExcelClient(Uri webUri, ICredentials credentials)
        {
            WebUri = webUri;
            _client = new WebClient { Credentials = credentials };
        }


        public string ReadTable(string libraryName, string fileName, string tableName, string formatType)
        {
            var endpointUrl = string.Format("{0}/_vti_bin/ExcelRest.aspx/{1}/{2}/Model/Tables('{3}')?$format={4}", WebUri, libraryName, fileName, tableName, formatType);
            return _client.DownloadString(endpointUrl);
        }


        public void Dispose()
        {
            _client.Dispose();
            GC.SuppressFinalize(this);
        }

        public Uri WebUri { get; private set; }

        private readonly WebClient _client;

    }
}
