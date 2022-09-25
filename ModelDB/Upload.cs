using ModelDB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
public class Upload
{
    public int Id { get; set; }
    public int InsurId { get; set; }

    public int ReqCenterId { get; set; }
    [ForeignKey("ReqCenterId")]
    public virtual CenterInfo CenterInfo { get; set; }
    public virtual User Users { get; set; }
    public DateTime UploadDate { get; set; }


    public bool? Uploaded { get; set; }
    public bool? Answered { get; set; }
    public bool? UnderProcess { get; set; }

    public string UploadNotes { get; set; }
    public string ReplyNotes { get; set; }

    public string UploadUser { get; set; }

}
