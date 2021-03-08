using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Files.Shares;

namespace mvcStorage.Services
{
    public class ServiceStorageFile
    {
        ShareClient client;
     
        public ServiceStorageFile()
        {
            String keys = "DefaultEndpointsProtocol=https;AccountName=storagetajamarmc;AccountKey=x0jTzyCgy9UTgxRTJf9z2Dnz7DXEB7+zqoIEUN5TAKHLjnICxrxKvt6IkjJAlVE+6MpX4rkYr9os5RWqVINC3Q==;EndpointSuffix=core.windows.net";
            this.client = new ShareClient(keys, "ejemplo");

        }
    }
}
