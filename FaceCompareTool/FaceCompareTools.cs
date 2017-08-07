using System.Collections.Generic;
using HttpConnect;
using Newtonsoft.Json;
using System;


namespace FaceCompareTool
{



    public class FaceCompareTools
    {
        private readonly static string DETECT_URL = "https://api-cn.faceplusplus.com/facepp/v3/detect";
        private readonly static string COMPARE_URL = "https://api-cn.faceplusplus.com/facepp/v3/compare";
        private readonly static string API_KEY = "s_W6dF_kruWZuRkfAyPfa_FWcsKGBGWG";
        private readonly static string API_SECRET = "rR_C9zcPYDdmP7lETeLF1cEW7_iTHxqH";

        private readonly static int MAXTIMES = 3;

        private string GetFaceToken(Face face)
        {
            HttpMethods httpMethods = new HttpMethods();
            string token = null;
            var dic = new Dictionary<object, object>();
            dic.Add("api_key", API_KEY);
            dic.Add("api_secret", API_SECRET);
            string strResult = null;
            try
            {
                strResult = httpMethods.HttpPost(DETECT_URL, dic, face.fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetFaceToken >>>>>>> " + ex.Message);
            }
            if (strResult != null)
            {
                DetectResult decResult = (DetectResult)JsonConvert.DeserializeObject(strResult, typeof(DetectResult));
                foreach (HttpConnect.Face eleFace in decResult.faces)
                {
                    token = eleFace.face_token;
                }
            }
            face.face_token = token;
            return token;
        }

        private double GetCompareResult(Face face1, Face face2)
        {
            HttpMethods httpMethods = new HttpMethods();
            double result = 0.0;
            string param = "api_key=" + API_KEY + "&api_secret=" + API_SECRET +
                "&face_token1=" + face1.face_token + "&face_token2=" + face2.face_token;
            string strResult = null;

            try
            {
                strResult = httpMethods.HttpPost(COMPARE_URL, param);
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetCompareResult >>>> " + ex.Message);
            }
            if (strResult != null)
            {
                CompareResult compareResult = (CompareResult)JsonConvert.DeserializeObject(strResult, typeof(CompareResult));
                result = compareResult.confidence;
            }
            return result;
        }

        public double CompareFace(string faceFileName, string tmpFaceFilename)
        {
            int times = 0;
            double result = 0.0;
            Face face = new Face(); face.fileName = faceFileName;
            Face tmpFace = new Face(); tmpFace.fileName = tmpFaceFilename;
            do
            {
                GetFaceToken(face);
                times++;
            } while (face.face_token == null && times <= MAXTIMES);
            times = 0;
            do
            {
                GetFaceToken(tmpFace);
                times++;
            } while (tmpFace.face_token == null && times <= MAXTIMES);

            Console.WriteLine("face : {0} , tmpFace : {1}", face.face_token, tmpFace.face_token);
            if (face.face_token != null && tmpFace.face_token != null)
            {
                times = 0;
                do
                {
                    result = GetCompareResult(face, tmpFace);
                    times++;
                } while (result == 0.0 && times <= MAXTIMES);
            }

            return result;
        }

    }
}
