﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Configuration;
using System.Xml;
using ZIT.LOG;

namespace ZIT.Utility
{
    public class XmlUtil
    {
        #region 反序列化
        /// <summary>  
        /// 反序列化  
        /// </summary>  
        /// <param name="type">类型</param>  
        /// <param name="xml">XML字符串</param>  
        /// <returns></returns>  
        public static object Deserialize(Type type, string xml)
        {
            try
            {
                xml = XmlFormat(xml, type.Name);
                using (StringReader sr = new StringReader(xml))
                {
                    XmlSerializer xmldes = new XmlSerializer(type);
                    return xmldes.Deserialize(sr);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        private static string XmlFormat(string xml, string type)
        {
            string xmls = xml.Replace("ZXEMC", type);
            return xmls;
        }
        /// <summary>  
        /// 反序列化  
        /// </summary>  
        /// <param name="type"></param>  
        /// <param name="xml"></param>  
        /// <returns></returns>  
        public static object Deserialize(Type type, Stream stream)
        {
            XmlSerializer xmldes = new XmlSerializer(type);
            return xmldes.Deserialize(stream);
        }
        #endregion

        #region 序列化XML文件
        /// <summary>  
        /// 序列化XML文件  
        /// </summary>  
        /// <param name="type">类型</param>  
        /// <param name="obj">对象</param>  
        /// <returns></returns>  
        public static string Serializer(Type type, object obj)
        {
            
            MemoryStream Stream = new MemoryStream();
            //创建序列化对象  
            XmlSerializer xml = new XmlSerializer(type);
            try
            {
               
                //序列化对象  
               // xml.Serialize(Stream, obj);
                XmlSerializerNamespaces name=new XmlSerializerNamespaces();
               name.Add ("", "");
             
               xml.Serialize(Stream, obj, name);
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            Stream.Position = 0;
            StreamReader sr = new StreamReader(Stream);
            string str = sr.ReadToEnd();
            str = SequenceFormat(str, type);
            return str;
        }
        private static string SequenceFormat(string xml, Type t)
        {
            string type = t.Name;
            xml = xml.Replace("<" + type, "<ZXEMC");
            xml = xml.Replace("</" + type + ">", "</ZXEMC>");
            return xml;
        }
        #endregion
        
        #region 将XML转换为DATATABLE
        /// <summary>  
        /// 将XML转换为DATATABLE  
        /// </summary>  
        /// <param name="FileURL"></param>  
        /// <returns></returns>  
        public static DataTable XmlAnalysisArray()
        {
            try
            {
                /*
                string FileURL =  ConfigurationManager.AppSettings["Client"].ToString();
                DataSet ds = new DataSet();
                ds.ReadXml(FileURL);
                return ds.Tables[0];
                 */
                return null;
            }
            catch (Exception ex)
            {
                //System.Web.HttpContext.Current.Response.Write(ex.Message.ToString());
                throw ex;
            }
        }
        /// <summary>  
        /// 将XML转换为DATATABLE  
        /// </summary>  
        /// <param name="FileURL"></param>  
        /// <returns></returns>  
        public static DataTable XmlAnalysisArray(string FileURL)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(FileURL);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("XmlAnalysisArray", ex);
                return null;
            }
        }
        #endregion

        #region 获取对应XML节点的值
        /// <summary>  
        /// 摘要:获取对应XML节点的值  
        /// </summary>  
        /// <param name="stringRoot">XML节点的标记</param>  
        /// <returns>返回获取对应XML节点的值</returns>  
        public static string XmlAnalysis(string stringRoot, string xml)
        {
            if (stringRoot.Equals("") == false)
            {
                try
                {
                    XmlDocument XmlLoad = new XmlDocument();
                    XmlLoad.LoadXml(xml);
                    return XmlLoad.DocumentElement.SelectSingleNode(stringRoot).InnerXml.Trim();
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog("XmlAnalysis", ex);
                }
            }
            return "";
        }
        #endregion

        public static string GetXMlStart()
        {
            string sql = "<?xml version='1.0' encoding='gb2312'?>";
            return sql;
        }
    }

}
