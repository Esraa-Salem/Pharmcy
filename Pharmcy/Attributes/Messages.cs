using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Pharmcy.Attributes
{
    internal class Content
    {
        public string Message;
        public string MessageDetails;

    };
    struct Messages
    {
        static Content content = new Content();
        public static Content InsertedSuccessfully(string tablename)
        {
            content.Message = "Inserted Successfully";
            content.MessageDetails = "Inserted Successfully 1 row to " + tablename;

            return content;
        }
        public static Content UpdatedSuccessfully(string tablename)
        {
            content.Message = "Updated Successfully";
            content.MessageDetails = "Updated Successfully 1 row to " + tablename;

            return content;
        }
        public static Content DeletedSuccessfully(string tablename)
        {
            content.Message = "Deleted Successfully";
            content.MessageDetails = "Deleted Successfully 1 row to " + tablename;

            return content;
        }

        public static Content Exception(Exception ex)
        {
            content.Message = "Exception";
            content.MessageDetails = ex.Message;

            return content;
        }
    }
}