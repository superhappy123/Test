using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    public class WebUrlRead
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public bool SelectRealTime(string searchUrl, ref string resultConent, ref Stream resStream)
        {
            bool result = false;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Stream responseStream = null;
            StreamReader reader = null;

            try
            {
                request = WebRequest.Create(searchUrl) as HttpWebRequest;
                request.Method = "GET";
                response = request.GetResponse() as HttpWebResponse;
                responseStream = response.GetResponseStream();
                resStream = responseStream;
                Encoding encoding = Encoding.GetEncoding("UTF-8");
                reader = new StreamReader(responseStream, encoding);
                resultConent = reader.ReadToEnd();
                result = true;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                //DisposeObject(ref request, ref response, ref responseStream, ref reader);
            }
            return result;
        }

        private static void DisposeObject(ref HttpWebRequest request, ref HttpWebResponse response,
            ref Stream responseStream, ref StreamReader reader)
        {
            if (request != null)
            {
                request = null;
            }
            if (response != null)
            {
                response.Close();
                response = null;
            }
            if (responseStream != null)
            {
                responseStream.Close();
                responseStream.Dispose();
                responseStream = null;
            }
            if (reader != null)
            {
                reader.Close();
                reader.Dispose();
                reader = null;
            }
        }

    }
}