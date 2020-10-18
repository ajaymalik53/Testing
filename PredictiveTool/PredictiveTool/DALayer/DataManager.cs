using PredictiveTool.Models;
using System.Data;


namespace PredictiveTool.DALayer
{
    public class DataManager : BaseClass
    {
        public DataSet GetData(PredAnalysisModel predAnalysisModel)
        {

            SqlParam.Clear();
            SqlParamAdd("@TabID", DbType.String, predAnalysisModel.TabID);
            SqlParamAdd("@SectorID", DbType.String, predAnalysisModel.SectorID);
            SqlParamAdd("@from", DbType.String, predAnalysisModel.From);
            SqlParamAdd("@To", DbType.String, predAnalysisModel.To);
            SqlParamAdd("@type", DbType.String, predAnalysisModel.Type);
            return datasetFromDB("Proc_GetData", true);
        }
        //public DataSet GetDropDown(PredAnalysisModel predAnalysisModel)
        //{
        //    SqlParam.Clear();
        //    SqlParamAdd("@TabID", DbType.String, "test");
        //    SqlParamAdd("@SectorID", DbType.String, "test");
        //    SqlParamAdd("@type", DbType.String, "test");
        //    return datasetFromDB("Proc_GetDropDown", true);
        //}
        //    public DataMaster()
        //    {

        //    }
        //    public DataSet SaveUpdateContact(ContactModel obj)
        //    {

        //        SqlParam.Clear();
        //        SqlParamAdd("@Mode", DbType.String, obj.Mode);
        //        SqlParamAdd("@ID", DbType.String, obj.ID);
        //        SqlParamAdd("@Name", DbType.String, obj.ContactName);
        //        SqlParamAdd("@IDHCode", DbType.String, obj.CustomerIDH);
        //        SqlParamAdd("@ContactPersonName", DbType.String, obj.ContactPersonName);
        //        SqlParamAdd("@Address1", DbType.String, obj.Address1);
        //        SqlParamAdd("@Address2", DbType.String, obj.Address2);
        //        SqlParamAdd("@Address3", DbType.String, obj.Address3);
        //        SqlParamAdd("@ContactNo", DbType.String, obj.ContactNo);
        //        SqlParamAdd("@Email", DbType.String, obj.EmailAddress);
        //        SqlParamAdd("@GSTNO", DbType.String, obj.GSTNo);
        //        SqlParamAdd("@Paymentterm", DbType.String, obj.PaymentTerms);
        //        SqlParamAdd("@CountryID", DbType.String, obj.Country);
        //        SqlParamAdd("@CurrencyID", DbType.String, obj.Currency);
        //        SqlParamAdd("@BankDetail", DbType.String, obj.BankDetails);
        //        SqlParamAdd("@GroupID", DbType.String, obj.Group);
        //        SqlParamAdd("@RegionID", DbType.String, obj.Region);
        //        SqlParamAdd("@Status", DbType.String, obj.Status);
        //        SqlParamAdd("@CategoryID", DbType.String, obj.CategoryID);
        //        SqlParamAdd("@BUID", DbType.String, obj.BU);
        //        SqlParamAdd("@MAID", DbType.String, "");
        //        SqlParamAdd("@MCID", DbType.String, "");
        //        SqlParamAdd("@CreatedBy", DbType.String, "");
        //        SqlParamAdd("@CreatedDate", DbType.String, "");
        //        return datasetFromDB("Proc_MasterContact", true);
        //    }
        //    public DataSet SaveUpdateContactPer(Contactperson obj)
        //    {
        //        SqlParam.Clear();
        //        SqlParamAdd("@Mode", DbType.String, obj.Mode);
        //        SqlParamAdd("@ID", DbType.String, obj.ID);
        //        SqlParamAdd("@ContactType", DbType.String, obj.ContactTypeID);
        //        SqlParamAdd("@Email", DbType.String, obj.Email);
        //        SqlParamAdd("@Name", DbType.String, obj.Name);
        //        SqlParamAdd("@IsActive", DbType.String, obj.IsActive);
        //        SqlParamAdd("@CreatedBy", DbType.String, obj.LoginMID);
        //        SqlParamAdd("@MAID", DbType.String, obj.MAID);
        //        SqlParamAdd("@MCID", DbType.String, obj.MCID);
        //        SqlParamAdd("@CategorytypeID", DbType.String, obj.CategoryTypeID);
        //        return datasetFromDB("Master_usp_ContactPerson", true);
        //    }
        //    public DataSet UploaDdata(UploadModel uploadModel)
        //    {

        //        SqlParam.Clear();
        //        SqlParamAdd("@LoginID", DbType.String, "");
        //        SqlParamAdd("@FileName", DbType.String, uploadModel.FileName);
        //        SqlParamAdd("@OrginalFilePath", DbType.String, uploadModel.OrginalFileName);
        //        SqlParamAdd("@createdBy", DbType.String, "1");
        //        SqlParamAdd("@Data", DbType.String, uploadModel.Data);
        //        SqlParamAdd("@Host", DbType.String, uploadModel.HostName);
        //        return datasetFromDB("proc_Upload_Product", true);
        //    }
        //    public DataSet GetUpdateApprovalFlow(ApprovalFlowModel uploadModel)
        //    {


        //        SqlParam.Clear();
        //        SqlParamAdd("@Mode", DbType.String, uploadModel.Mode);
        //        SqlParamAdd("@ProjectName", DbType.String, uploadModel.ProjectName);
        //        SqlParamAdd("@RFQDate", DbType.String, uploadModel.RFQDate);
        //        SqlParamAdd("@ApprovalDate", DbType.String, uploadModel.ApprovalDate);
        //        SqlParamAdd("@Level1", DbType.String, uploadModel.Level1);
        //        SqlParamAdd("@Level2", DbType.String, uploadModel.Level2);
        //        SqlParamAdd("@Level3", DbType.String, uploadModel.Level3);
        //        SqlParamAdd("@Level4", DbType.String, uploadModel.Level4);
        //        SqlParamAdd("@Level5", DbType.String, uploadModel.Level5);
        //        //SqlParamAdd("@Host", DbType.String, uploadModel.HostName);
        //        return datasetFromDB("Master_ApprovalFlowSP", true);
        //    }


        //    public DataSet LoginToUser(UserModel userModel)
        //    {
        //        SqlParam.Clear();
        //        SqlParamAdd("@Mode", DbType.String, userModel.Type);
        //        SqlParamAdd("@UserCode", DbType.String, userModel.LoginID);
        //        SqlParamAdd("@Password", DbType.String, userModel.PassWord);
        //        //return datasetFromDB("Proc_LoginSP", true);
        //        return datasetFromDB("LoginSP", true);
        //    }

        //    public DataSet SaveUpdateport(UserContactModel contactModel)
        //    {
        //        SqlParam.Clear();
        //        SqlParamAdd("@Mode", DbType.String, contactModel.Mode);
        //        SqlParamAdd("@ID", DbType.String, contactModel.ID);
        //        SqlParamAdd("@PTID", DbType.String, contactModel.PortTypeID);
        //        SqlParamAdd("@CityID", DbType.String, contactModel.CityID);
        //        SqlParamAdd("@CountryID", DbType.String, contactModel.CountryID);
        //        SqlParamAdd("@Name", DbType.String, contactModel.Name);
        //        SqlParamAdd("@ContactPerson", DbType.String, contactModel.ContactPerson);
        //        SqlParamAdd("@Address", DbType.String, contactModel.Address);
        //        SqlParamAdd("@PortNumber", DbType.String, contactModel.PortNumber);
        //        SqlParamAdd("@Email", DbType.String, contactModel.Email);
        //        SqlParamAdd("@MobileNumber", DbType.String, contactModel.MobileNumber);
        //        SqlParamAdd("@LandLineNumber", DbType.String, contactModel.LandLineNo);
        //        SqlParamAdd("@CreatedBy", DbType.String, contactModel.CreatedBy);
        //        SqlParamAdd("@Status", DbType.String, contactModel.ISActive);
        //        SqlParamAdd("@MCID", DbType.String, contactModel.MCID);
        //        return datasetFromDB("Proc_MasterPort", true);
        //    }
        //    public DataSet SavePreShipped(OrderModel contactModel)
        //    {
        //        SqlParam.Clear();
        //        SqlParamAdd("@Mode", DbType.String, contactModel.Mode);
        //        SqlParamAdd("@ID", DbType.String, contactModel.ID);

        //        return datasetFromDB("Proc_ExportDispatchOrder", true);
        //    }
        //    public DataSet SaveUpdateProduct(Productmodel contactModel)
        //    {
        //        SqlParam.Clear();
        //        SqlParamAdd("@Mode", DbType.String, contactModel.Mode);
        //        SqlParamAdd("@ID", DbType.String, contactModel.ID);
        //        SqlParamAdd("@ProductDesc", DbType.String, contactModel.ProductDesc);
        //        SqlParamAdd("@ProductIDH", DbType.String, contactModel.ProductIDH);
        //        SqlParamAdd("@Grade", DbType.String, contactModel.ProductName);
        //        SqlParamAdd("@Group", DbType.String, contactModel.Group);
        //        SqlParamAdd("@ProductName", DbType.String, contactModel.ProductName);
        //        SqlParamAdd("@PackSize", DbType.String, contactModel.PackSize);
        //        SqlParamAdd("@GechnicalGenericName", DbType.String, contactModel.Technical_Generi_Name);
        //        SqlParamAdd("@HSCode", DbType.String, contactModel.HSCode);
        //        SqlParamAdd("@Plant", DbType.String, contactModel.Plant);
        //        SqlParamAdd("@HazNonHaz", DbType.String, contactModel.Haz_Non_Haz);
        //        SqlParamAdd("@QtyinCons", DbType.String, contactModel.QtyinCons);
        //        SqlParamAdd("@QtyinKgs", DbType.String, contactModel.QtyinKgs);
        //        SqlParamAdd("@GrossWTKgs", DbType.String, contactModel.CateGrossWTgoryID);
        //        SqlParamAdd("@CountryofOrigin", DbType.String, contactModel.CountryofOrigin);
        //        SqlParamAdd("@MAID", DbType.String, contactModel.MAID);
        //        SqlParamAdd("@CreatedBy", DbType.String, contactModel.CreatedBy);
        //        SqlParamAdd("@Status", DbType.String, contactModel.ISActive);
        //        SqlParamAdd("@MCID", DbType.String, contactModel.MCID);
        //        return datasetFromDB("Proc_MasterInProduct", true);
        //    }
        //    public DataSet PostDispatch(CreatePOCModel obj)
        //    {
        //        SqlParam.Clear();
        //        SqlParamAdd("@Mode", DbType.String, obj.Mode);
        //        SqlParamAdd("@ID", DbType.String, obj.ID);
        //        SqlParamAdd("@LMID", DbType.String, obj.LMID);
        //        SqlParamAdd("@MAID", DbType.String, obj.MAID);
        //        SqlParamAdd("@MCID", DbType.String, obj.MCID);
        //        SqlParamAdd("@DOA", DbType.String, obj.ETA);
        //        SqlParamAdd("@DOD", DbType.String, obj.ETD);
        //        SqlParamAdd("@InvoiceNo", DbType.String, obj.InvoiceNo);
        //        SqlParamAdd("@DocType", DbType.String, obj.DocType);
        //        SqlParamAdd("@Data", DbType.String, obj.Data);
        //        SqlParamAdd("@VessleDetail", DbType.String, obj.VessleDetail);
        //        return datasetFromDB("Proc_SaveUpdatePostDocDetail", true);
        //    }
        //    public DataSet ApproveRejectByExport(ApproveModel model)
        //    {
        //         SqlParam.Clear();
        //        SqlParamAdd("@Mode", DbType.String, model.Mode);
        //        SqlParamAdd("@InvoiceID", DbType.String, model.InvoiceID);
        //        SqlParamAdd("@InvoiceIDs", DbType.String, model.InvoiceIDs);
        //        SqlParamAdd("@ApprovedBy", DbType.String, model.CreatedBy);
        //        SqlParamAdd("@VendorType", DbType.String, model.VendorType);
        //        return datasetFromDB("Proc_ExportApproveReject", true);
        //    }
        //        public DataSet SaveUpdateVendorData(MISUpdateModel model)
        //    {
        //        SqlParam.Clear();
        //        SqlParamAdd("@Mode", DbType.String, model.Mode);
        //        SqlParamAdd("@ID", DbType.String, model.ID);
        //        SqlParamAdd("@InvoiceID", DbType.String, model.InvoiceID);
        //        SqlParamAdd("@VendorType", DbType.String, model.VendorType);
        //        SqlParamAdd("@InvoiceNo", DbType.String, model.InvoiceNo);
        //        SqlParamAdd("@BLRcdDate", DbType.String, model.BLRcdDate);
        //        SqlParamAdd("@ValueasperBRC", DbType.String, model.ValueasperBRC);
        //        SqlParamAdd("@SubmittedToCustomer_Finance", DbType.String, model.SubmittedToCustomer_Finance);
        //        SqlParamAdd("@DHLNO", DbType.String, model.DHLNO);
        //        SqlParamAdd("@DelayInDispatch", DbType.String, model.DelayinDispatch);
        //        SqlParamAdd("@DispatchReason", DbType.String, model.DispatchReason);
        //        SqlParamAdd("@DelayinreceiptofBL", DbType.String, model.DelayinreceiptofBL);
        //        SqlParamAdd("@BLReason", DbType.String, model.BLReason);
        //        SqlParamAdd("@DelayinSubmissionCustomerDocs", DbType.String, model.DelayinSubmissionCustomerDocs);
        //        SqlParamAdd("@CDReason", DbType.String, model.CDReason);
        //        SqlParamAdd("@Remark", DbType.String, model.Remark);//Exporter
        //        SqlParamAdd("@DOCartingdetailsRequestedDate", DbType.String, model.DOCartingdetailsRequestedDate);
        //        SqlParamAdd("@DOCartingdetailsReceivedDate", DbType.String, model.DOCartingdetailsReceivedDate);
        //        SqlParamAdd("@BLNo", DbType.String, model.BLNo);
        //        SqlParamAdd("@BLDate", DbType.String, model.BLDate);
        //        SqlParamAdd("@TranshipmentPort", DbType.String, model.TranshipmentPort);
        //        SqlParamAdd("@TranshipmentVessel", DbType.String, model.TranshipmentVessel);
        //        SqlParamAdd("@TranshipmentETD", DbType.String, model.TranshipmentETD);
        //        SqlParamAdd("@TranshipmentETA", DbType.String, model.TranshipmentETA);
        //        SqlParamAdd("@Liner", DbType.String, model.Liner);
        //        SqlParamAdd("@FreightinRs", DbType.String, model.FreightinRs);//end FFF
        //        SqlParamAdd("@ExchangeRate", DbType.String, model.ExchangeRate);
        //        SqlParamAdd("@LoadingPortCode", DbType.String, model.LoadingPortCode);
        //        SqlParamAdd("@SBNo", DbType.String, model.SBNo);
        //        SqlParamAdd("@SbDate", DbType.String, model.SBDate);
        //        SqlParamAdd("@FOBValueasPerSB", DbType.String, model.FOBValueasPerSB);
        //        SqlParamAdd("@ShipmentReachedatPort", DbType.String, model.ShipmentReachedatPort);
        //        SqlParamAdd("@ClearanceDate", DbType.String, model.ClearanceDate);
        //        SqlParamAdd("@FreightinSB", DbType.String, model.FreightinSB);
        //        SqlParamAdd("@InsuaranceinSB", DbType.String, model.InsuaranceinSB);
        //        SqlParamAdd("@CommissioninSB", DbType.String, model.CommissioninSB);
        //        SqlParamAdd("@ExchangeRateinSB", DbType.String, model.ExchangeRateinSB);
        //        SqlParamAdd("@ScrollNo", DbType.String, model.ScrollNo);
        //        SqlParamAdd("@DBKrate", DbType.String, model.DBKrate);
        //        SqlParamAdd("@DBKAmount", DbType.String, model.DBKAmount);
        //        SqlParamAdd("@EGMNo", DbType.String, model.EGMNo);
        //        SqlParamAdd("@EGMDate", DbType.String, model.EGMDate);
        //        SqlParamAdd("@CHAChargesinRs", DbType.String, model.CHAChargesinRs);
        //        SqlParamAdd("@PalletChargesinRs", DbType.String, model.PalletChargesinRs);
        //        SqlParamAdd("@TransportChargesinRs", DbType.String, model.TransportChargesinRs);
        //        SqlParamAdd("@LoadingUnloadingChargesinRs", DbType.String, model.LoadingUnloadingChargesinRs);
        //        SqlParamAdd("@OtherChargesinRs", DbType.String, model.OtherChargesinRs);
        //        SqlParamAdd("@CreatedBy", DbType.String, model.CreatedBy);           
        //        return datasetFromDB("Proc_MISVendorUpdate", true);

        //    }
        //    public DataSet DispatchOrder(OrderModel model)
        //    {
        //        SqlParam.Clear();
        //        SqlParamAdd("@Mode", DbType.String, model.Mode);
        //        SqlParamAdd("@LMID", DbType.String, model.ID);
        //        SqlParamAdd("@Data", DbType.String, model.Data);
        //        SqlParamAdd("@MCID", DbType.String, model.CAID);
        //        SqlParamAdd("@TTID", DbType.String, model.TTIDs);
        //        SqlParamAdd("@FFID", DbType.String, model.FFIDs);
        //        SqlParamAdd("@CHAID", DbType.String, model.CHAIDs);
        //        SqlParamAdd("@DispatcherID", DbType.String, model.DispatchIDs);
        //        SqlParamAdd("@OrderIDs", DbType.String, model.OrderIds);
        //        SqlParamAdd("@ProductIDs", DbType.String, model.PDIDs);
        //        SqlParamAdd("@PortFromID", DbType.String, model.PortFrom);
        //        SqlParamAdd("@PortToID", DbType.String, model.PortTO);
        //        SqlParamAdd("@ShipmenttypeID", DbType.String, model.ShipmentTypeID);
        //        SqlParamAdd("@SubShipmenttypeID", DbType.String, model.ShipmentSubTypeID);
        //        SqlParamAdd("@ShimentLoadID", DbType.String, model.ShipmentLoadID);
        //        SqlParamAdd("@SubShimentLoadID", DbType.String, model.ShipmentSubLoadID);
        //        SqlParamAdd("@PlantID", DbType.String, model.Plant_WH);
        //        SqlParamAdd("@WareHouseID", DbType.String, model.WareHouse);
        //        SqlParamAdd("@BUID", DbType.String, model.BUID);
        //        SqlParamAdd("@ModeType", DbType.String, model.ModeID);
        //        SqlParamAdd("@IncoTerms", DbType.String, model.IncoTerms);
        //        SqlParamAdd("@ShippingMarks", DbType.String, model.ShippingMakrs);
        //        SqlParamAdd("@AdditionalDetails", DbType.String, model.AdditionalDetails);
        //        SqlParamAdd("@Otherref", DbType.String, model.Otherreference);
        //        SqlParamAdd("@BaychNo", DbType.String, model.BatchNo);
        //        SqlParamAdd("@InvoiceNo", DbType.String, model.InvoiceNo);
        //        SqlParamAdd("@ContainerNo", DbType.String, model.ContainerNo);
        //        SqlParamAdd("@CustomerOrderNo", DbType.String, model.CustomerOrderNo);
        //        SqlParamAdd("@LCNo", DbType.String, model.LCNumber);
        //        SqlParamAdd("@SystemPreDocsName", DbType.String, model.SystemPreDocsName);
        //        SqlParamAdd("@SysFilePath", DbType.String, model.SysFilePath);
        //        SqlParamAdd("@UserUploadedFilename", DbType.String, model.UserUploadedFilename);
        //        SqlParamAdd("@UploadDocPath", DbType.String, model.UploadDocPath);
        //        SqlParamAdd("@ASSESSESEAL", DbType.String, model.ASSESSESEAL);
        //        SqlParamAdd("@Size", DbType.String, model.SIZE);
        //        SqlParamAdd("@ShippingLine", DbType.String, model.SHIPPINGLINE);
        //        SqlParamAdd("@NOOFPACKAGESINCont", DbType.String, model.NOOFPACKAGESINCont);
        //        SqlParamAdd("@GSTLUT", DbType.String, model.GSTLUTValue);
        //        SqlParamAdd("@Requestername", DbType.String, model.Requestername);
        //        SqlParamAdd("@CostLineno", DbType.String, model.CostLineno);
        //        SqlParamAdd("@CostCenterNo", DbType.String, model.CostCenterNo);
        //        SqlParamAdd("@SampleApprovedby", DbType.String, model.SampleApprovedby);
        //        SqlParamAdd("@Processedthrough", DbType.String, model.Processedthrough);
        //        SqlParamAdd("@TTEmailID", DbType.String, model.TTEmailID);
        //        SqlParamAdd("@CHAEmailID", DbType.String, model.CHAEmailID);
        //        SqlParamAdd("@FFEmailID", DbType.String, model.FFEmailID);
        //        SqlParamAdd("@LCDate", DbType.String, model.LCDate);
        //        SqlParamAdd("@InvoiceDate", DbType.String, model.InvoiceDate);
        //        return datasetFromDB("Proc_ExportDispatchOrder", true);

        //    }
        //    public DataSet SaveUpdateGetCountry(CountryModel countryModel)
        //    {

        //        SqlParam.Clear();
        //        SqlParamAdd("@Mode", DbType.String, countryModel.Mode);
        //        SqlParamAdd("@ID", DbType.String, countryModel.ID);
        //        SqlParamAdd("@CountryName", DbType.String, countryModel.Name);
        //        SqlParamAdd("@IsActive", DbType.String, countryModel.ISActive);
        //        return datasetFromDB("Master_CountrySP", true);
        //    }
        //    public DataSet SendFAQToSupplier(RFQSendmodel obj)
        //    {
        //        SqlParam.Clear();
        //        SqlParamAdd("@Mode", DbType.String, obj.Mode);
        //        SqlParamAdd("@SupplierIDs", DbType.String, obj.TOIDs);
        //        SqlParamAdd("@ProductIds", DbType.String, obj.FromIDs);
        //        SqlParamAdd("@SupplierID", DbType.String, obj.SupplierId);
        //        SqlParamAdd("@ProjectName", DbType.String, obj.Name);
        //        SqlParamAdd("@ProjectID", DbType.String, obj.ProjectID);
        //        return datasetFromDB("Proc_RFQSendSP", true);
        //    }
        //    public DataSet GetAllSupplier(RFQSendmodel obj)
        //    {
        //        SqlParam.Clear();
        //        SqlParamAdd("@SupplierIDs", DbType.String, obj.TOIDs);
        //        return datasetFromDB("Proc_RFQSendSP", true);
        //    }
        //    public DataSet ApprovedFAQToSupplier(RFQSendmodel obj)
        //    {
        //        SqlParam.Clear();
        //        SqlParamAdd("@Mode", DbType.String, obj.Mode);
        //        SqlParamAdd("@SupplierIDs", DbType.String, obj.TOIDs);
        //        SqlParamAdd("@ProductIds", DbType.String, obj.PricesData);
        //        SqlParamAdd("@SupplierID", DbType.String, obj.SupplierId);
        //        SqlParamAdd("@ProjectName", DbType.String, obj.ProjectID);
        //        SqlParamAdd("@ProjectID", DbType.String, obj.ProjectID);
        //        return datasetFromDB("Proc_RFQSendSP", true);
        //    }
        //    public DataSet ReceivedFAQToSupplier(RFQReceivedSendmodel obj)
        //    {
        //        SqlParam.Clear();
        //        SqlParamAdd("@Mode", DbType.String, obj.Mode);
        //        SqlParamAdd("@SupplierIDs", DbType.String, obj.TOIDs);
        //        SqlParamAdd("@ProductIds", DbType.String, obj.PricesData);
        //        SqlParamAdd("@SupplierID", DbType.String, obj.SupplierId);
        //        SqlParamAdd("@ProjectName", DbType.String, obj.ProjectID);
        //        SqlParamAdd("@ProjectID", DbType.String, obj.ProjectID);
        //        return datasetFromDB("Proc_RFQSendSP", true);
        //    }
        //    public DataSet ApproveLevel(ApprovalLvlModel obj)
        //    {

        //        SqlParam.Clear();
        //        SqlParamAdd("@Mode", DbType.String, obj.Mode);
        //        SqlParamAdd("@ID", DbType.String, obj.ID);
        //        SqlParamAdd("@LvelData", DbType.String, obj.PricesData);
        //        return datasetFromDB("Proc_MasterApproval", true);
        //    }
        //    public DataSet SaveUpdateGetCity(CityModel obj)
        //    {

        //        SqlParam.Clear();
        //        SqlParamAdd("@Mode", DbType.String, obj.Mode);
        //        SqlParamAdd("@ID", DbType.String, obj.ID);
        //        SqlParamAdd("@CountryID", DbType.String, obj.ParentID);
        //        SqlParamAdd("@CityName", DbType.String, obj.Name);
        //        SqlParamAdd("@IsActive", DbType.String, obj.ISActive);
        //        return datasetFromDB("Master_CitySP", true);
        //    }
        //    public DataSet SaveUpdateGetUser(UserContactModel contactModel)
        //    {
        //        SqlParam.Clear();
        //        SqlParamAdd("@Mode", DbType.String, contactModel.Mode);
        //        SqlParamAdd("@ID", DbType.String, contactModel.ID);
        //        SqlParamAdd("@MasterTypeID", DbType.String, contactModel.MasterTypeID);
        //        SqlParamAdd("@UserName", DbType.String, contactModel.ContactPerson);
        //        SqlParamAdd("@CityID", DbType.String, contactModel.CityID);
        //        SqlParamAdd("@Email", DbType.String, contactModel.Email);
        //        SqlParamAdd("@MobileNo", DbType.String, contactModel.MobileNumber);
        //        SqlParamAdd("@UserCode", DbType.String, "");
        //        SqlParamAdd("@MAID", DbType.String, contactModel.MAID);
        //        SqlParamAdd("@IsActive", DbType.String, contactModel.ISActive);
        //        return datasetFromDB("Proc_MasterUser", true);
        //    }
        //    public DataSet UpdateMenuPermission(RFQSendmodel rFQSendmodel)
        //    {
        //        SqlParam.Clear();
        //        SqlParamAdd("@UserCode", DbType.String, rFQSendmodel.ProjectID);
        //        SqlParamAdd("@MenuIDs", DbType.String, rFQSendmodel.FromIDs);
        //        return datasetFromDB("Proc_MenuPermission", true);
        //    }
        //    public DataSet SaveUpdateGetCountry(UserContactModel contactModel)
        //    {

        //        SqlParam.Clear();
        //        SqlParamAdd("@Mode", DbType.String, contactModel.Mode);
        //        SqlParamAdd("@ID", DbType.String, contactModel.ID);
        //        SqlParamAdd("@CountryName", DbType.String, contactModel.MasterTypeID);
        //        SqlParamAdd("@IsActive", DbType.String, contactModel.ISActive == "Yes" ? "1" : "No");
        //        return datasetFromDB("Proc_MasterUser", true);
        //    }

        //    public DataSet GetDropDown(string option, string option1 = "", string option2 = "")
        //    {
        //        SqlParam.Clear();
        //        SqlParamAdd("@option", DbType.String, option);
        //        SqlParamAdd("@option1", DbType.String, option1 == "null" ? "" : option1);
        //        SqlParamAdd("@option2", DbType.String, option2 == "null" ? "" : option2);
        //        return datasetFromDB("Proc_GetDropDown", true);
        //    }
        //    public DataSet GetTableData(string option, string option1 = "", string option2 = "")
        //    {
        //        SqlParam.Clear();
        //        SqlParamAdd("@option", DbType.String, option);
        //        SqlParamAdd("@option1", DbType.String, option1);
        //        SqlParamAdd("@option2", DbType.String, option2);
        //        return datasetFromDB("Proc_FetchTableData", true);
        //    }
    }
}
