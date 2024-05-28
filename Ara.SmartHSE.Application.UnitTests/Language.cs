using Ara.SmartHSE.Application.Resource;
using Microsoft.Extensions.Localization;
using Moq;


namespace Ara.SmartHSE.Application.UnitTests
{
    public class Language
    {
        public readonly Mock<IStringLocalizer<SharedResources>> _sharedResources;
        public Language()
        {
            _sharedResources = new Mock<IStringLocalizer<SharedResources>>();
            Message();
        }
        public void Message()
        {

            #region Message

            var AliasName = new List<string>() { "AliasName", "Enter A Nickname" };
            var AppKey = new List<string>() { "AppKey", "Program Key Not Specified" };
            var BrandId = new List<string>() { "BrandId", "Please Select Company" };
            var BrandName = new List<string>() { "BrandName", "Please Enter Company Name" };
            var ClientId = new List<string>() { "ClientId", "Please Enter The Text" };
            var CompanyName = new List<string>() { "CompanyName", "The Manufacturer Is Not Specified" };
            var DateTimeOfChangeLog = new List<string>() { "DateTimeOfChangeLog", "Please Enter The Date Of Change Of Clock Status" };
            var DeleteOk = new List<string>() { "DeleteOk", "Delete Was Successful" };
            var DeliverTime = new List<string>() { "DeliverTime", "Please Enter Deliver Time" };
            var DuplicateArea = new List<string>() { "DuplicateArea", "The Name And Code Of The Area Are Duplicated" };
            var DuplicateCompanyName = new List<string>() { "DuplicateCompanyName", "Duplicate Company Name" };
            var DuplicateContractor = new List<string>() { "DuplicateContractor", "It Is A Repeat Contractor" };
            var DuplicateEquipment = new List<string>() { "DuplicateEquipment", "The Equipment Is Already Registered" };
            var DuplicateIndexId = new List<string>() { "DuplicateIndexId", "The Index Id Is Duplicate" };
            var DuplicateModel = new List<string>() { "DuplicateModel", "Duplicate Model" };
            var DuplicatePersonnel = new List<string>() { "DuplicatePersonnel", "This Person Is Registered" };
            var DuplicateRole = new List<string>() { "DuplicateRole", "Duplicate Role" };
            var DuplicateSickness = new List<string>() { "DuplicateSickness", "The Name Of The Disease Is Repeated" };
            var DuplicateWatch = new List<string>() { "DuplicateWatch", "This Device Is Already Registered" };
            var EditOk = new List<string>() { "EditOk", "Edit Was Successful" };
            var EndDate = new List<string>() { "EndDate", "Specify The End Date Of The Contract" };
            var Exception = new List<string>() { "Exception", "An Error Occurred While Performing The Operation" };
            var FillSickness = new List<string>() { "FillSickness", "The Name Of The Disease Is Not Entered" };
            var Firmware = new List<string>() { "Firmware", "Enter Firmware" };
            var FirmwareVersion = new List<string>() { "FirmwareVersion", "Please Enter The Firmware Version" };
            var GatewayEUI = new List<string>() { "GatewayEUI", "Enter GatewayEUI" };
            var GatewayID = new List<string>() { "GatewayID", "Enter GatewayID" };
            var HasData = new List<string>() { "HasData", "Information Is Available" };
            var Id = new List<string>() { "Id", "Device Not Found" };
            var IndexId = new List<string>() { "IndexId", "Please Enter Index" };
            var IP = new List<string>() { "IP", "Please Specify The IP" };
            var IsAssignToPersonnelBefor = new List<string>() { "IsAssignToPersonnelBefor", "The Watch Is Given To The Person" };
            var Item = new List<string>() { "Item", "Item(s)" };
            var Lat = new List<string>() { "Lat", "Enter The Latitude" };
            var Location = new List<string>() { "Location", "Please Enter The Device Address" };
            var Long = new List<string>() { "Long", "Enter The Longitude" };
            var LoRaDevEUI = new List<string>() { "LoRaDevEUI", "Mac Clock Not Specified" };
            var LoRaGatewayId = new List<string>() { "LoRaGatewayId", "Enter LoRaGatewayId" };
            var LoRaGatewayModel = new List<string>() { "LoRaGatewayModel", " Enter The Model" };
            var MACAddress = new List<string>() { "MACAddress", "The MAC Is Not Specified" };
            var Maintenance = new List<string>() { "Maintenance ", "Please Enter The Test Report" };
            var MaintenanceId = new List<string>() { "MaintenanceId", "Please Specify The Report" };
            var Model = new List<string>() { "Model", "The Watch Model Is Not Specified" };
            var ModelId = new List<string>() { "ModelId", "Please Select Model" };
            var ModelName = new List<string>() { "ModelName", "Please Enter Model" };
            var MqttId = new List<string>() { "MqttId", "Please Specify The Configuration ID" };
            var NetworkIP = new List<string>() { "NetworkIP", "Enter Network" };
            var NetworkKey = new List<string>() { "NetworkKey", "The Network Key Is Not Specified" };
            var NoData = new List<string>() { "NoData", "No Information Found" };
            var NotAccessForEditDevice = new List<string>() { "NotAccessForEditDevice", "This Device Cannot Be Edited" };
            var NotFindContractor = new List<string>() { "NotFindContractor", "The Contractor Was Not Found" };
            var NotFindContractors = new List<string>() { "NotFindContractors", "No Contractor Found" };
            var NotFindDate = new List<string>() { "NotFindDate", "The Date Has Not Been Specified" };
            var NotFindLoRa = new List<string>() { "NotFindLoRa", "Equipment Not Found" };
            var NotFindSickness = new List<string>() { "NotFindSickness ", "Selected Disease Is Not Valid" };
            var NotFound = new List<string>() { "NotFound", "Nothing Found" };
            var NotFoundCompany = new List<string>() { "NotFoundCompany", "Not Found Company" };
            var NotFoundModel = new List<string>() { "NotFoundModel", "Not Found Model" };
            var NotValidPersonnelIdInAssignWatch = new List<string>() { "NotValidPersonnelIdInAssignWatch", "The Personnel Has Not Been Specified" };
            var NotValidWatchIdInAssignWatch = new List<string>() { "NotValidWatchIdInAssignWatch", "The Hour Is Not Specified" };
            var NullRoleName = new List<string>() { "NullRoleName", "The Role Name Must Not Be Empty" };
            var Port = new List<string>() { "Port", "Please Specify The Port" };
            var RegisterOk = new List<string>() { "RegisterOk", "Register  Was Successful" };
            var SelectPersonnel = new List<string>() { "SelectPersonnel", "No One Has Been Selected" };
            var SerialNumber = new List<string>() { "SerialNumber", "Enter The Serial Number" };
            var StartDate = new List<string>() { "StartDate", "Specify The Start Date Of The Contract" };
            var StatusWatch = new List<string>() { "StatusWatch", "The Status Of The Clock Is Not Specified" };
            var Tenant = new List<string>() { "Tenant", "Please Select An Employer" };
            var TextEquipmentDetails = new List<string>() { "TextEquipmentDetails", "Please Enter The Clock Status Change" };
            var Topic = new List<string>() { "Topic", "Please Specify The Title" };
            var TransactionOfWatchId = new List<string>() { "TransactionOfWatchId", "Please Specify The Clock Status Change" };
            var UnValidAreaCode = new List<string>() { "UnValidAreaCode", "The Area Code Must Not Be Empty" };
            var UnValidAreaId = new List<string>() { "UnValidAreaId", "The Area Is Unvalid" };
            var UnValidAreaName = new List<string>() { "UnValidAreaName", "The Field Name Must Not Be Empty" };
            var UnValidContractorAddress = new List<string>() { "UnValidContractorAddress", "The Address Must Not Be Empty" };
            var UnValidContractorAreaIds = new List<string>() { "UnValidContractorAreaIds", "The Area Is Not Specified For The Contractor" };
            var UnValidContractorCodeUnique = new List<string>() { "UnValidContractorCodeUnique", "The National ID Of The Contractor Must Not Be Empty" };
            var UnValidContractorId = new List<string>() { "UnValidContractorId", "Please Specify The Contractor" };
            var UnValidContractorImage = new List<string>() { "UnValidContractorImage", "The Image Should Not Be Empty" };
            var UnValidContractorMobileNum = new List<string>() { "UnValidContractorMobileNum", "The Contact Number Must Not Be Empty" };
            var UnValidContractorName = new List<string>() { "UnValidContractorName", "The Name Of The Contractor Must Not Be Empty" };
            var UnValidCoordinates = new List<string>() { "UnValidCoordinates", "The Geographical Characteristics Of The Area Have Not Been Determined" };
            var UnValidPersonnelBirthday = new List<string>() { "UnValidPersonnelBirthday", "Date Of Birth Must Not Be Empty" };
            var UnValidPersonnelCode = new List<string>() { "UnValidPersonnelCode", "Personnel Code Must Not Be Empty" };
            var UnValidPersonnelFamily = new List<string>() { "UnValidPersonnelFamily", "Family Must Not Be Empty" };
            var UnValidPersonnelId = new List<string>() { "UnValidPersonnelId", "The ID Of The Person Is Not Valid" };
            var UnValidPersonnelMobileNum = new List<string>() { "UnValidPersonnelMobileNum", "The Contact Number Must Not Be Empty" };
            var UnValidPersonnelName = new List<string>() { "UnValidPersonnelName", "The Contact Number Must Not Be Empty" };
            var UnValidPersonnelNationalCode = new List<string>() { "UnValidPersonnelNationalCode", "The National Code Must Not Be Empty" };
            var UnValidRequestAccess = new List<string>() { "UnValidRequestAccess", "The Access Is Unvalid" };
            var UnValidRequestArea = new List<string>() { "UnValidRequestArea", "The Area Is Not Valid" };
            var UnValidRequestPeronnel = new List<string>() { "UnValidRequestPeronnel", "Selected Personnel Is Not Valid" };
            var UnValidRoleId = new List<string>() { "UnValidRoleId", "Role Not Found" };

            var FindResource = new List<string>() { "FindResource", "There Is A Resource With The Same Name Or Key" };
            #endregion


            #region LocalizedString

            var localizedString1 = new LocalizedString(AliasName[0], AliasName[1]);
            var localizedString2 = new LocalizedString(AppKey[0], AppKey[1]);
            var localizedString3 = new LocalizedString(BrandId[0], BrandId[1]);
            var localizedString4 = new LocalizedString(BrandName[0], BrandName[1]);
            var localizedString5 = new LocalizedString(ClientId[0], ClientId[1]);
            var localizedString6 = new LocalizedString(CompanyName[0], CompanyName[1]);
            var localizedString7 = new LocalizedString(DateTimeOfChangeLog[0], DateTimeOfChangeLog[1]);
            var localizedString8 = new LocalizedString(DeleteOk[0], DeleteOk[1]);
            var localizedString9 = new LocalizedString(DeliverTime[0], DeliverTime[1]);
            var localizedString10 = new LocalizedString(DuplicateArea[0], DuplicateArea[1]);
            var localizedString11 = new LocalizedString(DuplicateCompanyName[0], DuplicateCompanyName[1]);
            var localizedString12 = new LocalizedString(DuplicateContractor[0], DuplicateContractor[1]);
            var localizedString13 = new LocalizedString(DuplicateEquipment[0], DuplicateEquipment[1]);
            var localizedString14 = new LocalizedString(DuplicateIndexId[0], DuplicateIndexId[1]);
            var localizedString15 = new LocalizedString(DuplicateModel[0], DuplicateModel[1]);
            var localizedString16 = new LocalizedString(DuplicatePersonnel[0], DuplicatePersonnel[1]);
            var localizedString17 = new LocalizedString(DuplicateRole[0], DuplicateRole[1]);
            var localizedString18 = new LocalizedString(DuplicateSickness[0], DuplicateSickness[1]);
            var localizedString19 = new LocalizedString(DuplicateWatch[0], DuplicateWatch[1]);
            var localizedString20 = new LocalizedString(EditOk[0], EditOk[1]);
            var localizedString21 = new LocalizedString(EndDate[0], EndDate[1]);
            var localizedString22 = new LocalizedString(Exception[0], Exception[1]);
            var localizedString23 = new LocalizedString(FillSickness[0], FillSickness[1]);
            var localizedString24 = new LocalizedString(Firmware[0], Firmware[1]);
            var localizedString25 = new LocalizedString(FirmwareVersion[0], FirmwareVersion[1]);
            var localizedString26 = new LocalizedString(GatewayEUI[0], GatewayEUI[1]);
            var localizedString27 = new LocalizedString(GatewayID[0], GatewayID[1]);
            var localizedString28 = new LocalizedString(HasData[0], HasData[1]);
            var localizedString29 = new LocalizedString(Id[0], Id[1]);
            var localizedString30 = new LocalizedString(IndexId[0], IndexId[1]);
            var localizedString31 = new LocalizedString(IP[0], IP[1]);
            var localizedString32 = new LocalizedString(IsAssignToPersonnelBefor[0], IsAssignToPersonnelBefor[1]);
            var localizedString33 = new LocalizedString(Item[0], Item[1]);
            var localizedString34 = new LocalizedString(Lat[0], Lat[1]);
            var localizedString35 = new LocalizedString(Location[0], Location[1]);
            var localizedString36 = new LocalizedString(Long[0], Long[1]);
            var localizedString37 = new LocalizedString(LoRaDevEUI[0], LoRaDevEUI[1]);
            var localizedString38 = new LocalizedString(LoRaGatewayId[0], LoRaGatewayId[1]);
            var localizedString39 = new LocalizedString(LoRaGatewayModel[0], LoRaGatewayModel[1]);
            var localizedString40 = new LocalizedString(MACAddress[0], MACAddress[1]);
            var localizedString41 = new LocalizedString(Maintenance[0], Maintenance[1]);
            var localizedString42 = new LocalizedString(MaintenanceId[0], MaintenanceId[1]);
            var localizedString43 = new LocalizedString(Model[0], Model[1]);
            var localizedString44 = new LocalizedString(ModelId[0], ModelId[1]);
            var localizedString45 = new LocalizedString(ModelName[0], ModelName[1]);
            var localizedString46 = new LocalizedString(MqttId[0], MqttId[1]);
            var localizedString47 = new LocalizedString(NetworkIP[0], NetworkIP[1]);
            var localizedString48 = new LocalizedString(NetworkKey[0], NetworkKey[1]);
            var localizedString49 = new LocalizedString(NoData[0], NoData[1]);
            var localizedString50 = new LocalizedString(NotAccessForEditDevice[0], NotAccessForEditDevice[1]);
            var localizedString51 = new LocalizedString(NotFindContractor[0], NotFindContractor[1]);
            var localizedString52 = new LocalizedString(NotFindContractors[0], NotFindContractors[1]);
            var localizedString53 = new LocalizedString(NotFindDate[0], NotFindDate[1]);
            var localizedString54 = new LocalizedString(NotFindLoRa[0], NotFindLoRa[1]);
            var localizedString55 = new LocalizedString(NotFindSickness[0], NotFindSickness[1]);
            var localizedString56 = new LocalizedString(NotFound[0], NotFound[1]);
            var localizedString57 = new LocalizedString(NotFoundCompany[0], NotFoundCompany[1]);
            var localizedString58 = new LocalizedString(NotFoundModel[0], NotFoundModel[1]);
            var localizedString59 = new LocalizedString(NotValidPersonnelIdInAssignWatch[0], NotValidPersonnelIdInAssignWatch[1]);
            var localizedString60 = new LocalizedString(NotValidWatchIdInAssignWatch[0], NotValidWatchIdInAssignWatch[1]);
            var localizedString61 = new LocalizedString(NullRoleName[0], NullRoleName[1]);
            var localizedString62 = new LocalizedString(Port[0], Port[1]);
            var localizedString63 = new LocalizedString(RegisterOk[0], RegisterOk[1]);
            var localizedString64 = new LocalizedString(SelectPersonnel[0], SelectPersonnel[1]);
            var localizedString65 = new LocalizedString(SerialNumber[0], SerialNumber[1]);
            var localizedString66 = new LocalizedString(StartDate[0], StartDate[1]);
            var localizedString67 = new LocalizedString(StatusWatch[0], StatusWatch[1]);
            var localizedString68 = new LocalizedString(Tenant[0], Tenant[1]);
            var localizedString69 = new LocalizedString(TextEquipmentDetails[0], TextEquipmentDetails[1]);
            var localizedString70 = new LocalizedString(Topic[0], Topic[1]);
            var localizedString71 = new LocalizedString(TransactionOfWatchId[0], TransactionOfWatchId[1]);
            var localizedStrin72 = new LocalizedString(UnValidAreaCode[0], UnValidAreaCode[1]);
            var localizedString73 = new LocalizedString(UnValidAreaId[0], UnValidAreaId[1]);
            var localizedString74 = new LocalizedString(UnValidAreaName[0], UnValidAreaName[1]);
            var localizedString75 = new LocalizedString(UnValidContractorAddress[0], UnValidContractorAddress[1]);
            var localizedString76 = new LocalizedString(UnValidContractorAreaIds[0], UnValidContractorAreaIds[1]);
            var localizedString77 = new LocalizedString(UnValidContractorCodeUnique[0], UnValidContractorCodeUnique[1]);
            var localizedString78 = new LocalizedString(UnValidContractorId[0], UnValidContractorId[1]);
            var localizedString79 = new LocalizedString(UnValidContractorImage[0], UnValidContractorImage[1]);
            var localizedString80 = new LocalizedString(UnValidContractorMobileNum[0], UnValidContractorMobileNum[1]);
            var localizedString81 = new LocalizedString(UnValidContractorName[0], UnValidContractorName[1]);
            var localizedString82 = new LocalizedString(UnValidCoordinates[0], UnValidCoordinates[1]);
            var localizedString83 = new LocalizedString(UnValidPersonnelBirthday[0], UnValidPersonnelBirthday[1]);
            var localizedString84 = new LocalizedString(UnValidPersonnelCode[0], UnValidPersonnelCode[1]);
            var localizedString85 = new LocalizedString(UnValidPersonnelFamily[0], UnValidPersonnelFamily[1]);
            var localizedString86 = new LocalizedString(UnValidPersonnelId[0], UnValidPersonnelId[1]);
            var localizedString87 = new LocalizedString(UnValidPersonnelMobileNum[0], UnValidPersonnelMobileNum[1]);
            var localizedString88 = new LocalizedString(UnValidPersonnelName[0], UnValidPersonnelName[1]);
            var localizedString89 = new LocalizedString(UnValidPersonnelNationalCode[0], UnValidPersonnelNationalCode[1]);
            var localizedString90 = new LocalizedString(UnValidRequestAccess[0], UnValidRequestAccess[1]);
            var localizedString91 = new LocalizedString(UnValidRequestArea[0], UnValidRequestArea[1]);
            var localizedString92 = new LocalizedString(UnValidRequestPeronnel[0], UnValidRequestPeronnel[1]);
            var localizedString93 = new LocalizedString(UnValidRoleId[0], UnValidRoleId[1]);

            var localizedString94 = new LocalizedString(FindResource[0], FindResource[1]);

            #endregion


            #region _sharedResources
            _sharedResources.Setup(_ => _[AliasName[0]]).Returns(localizedString1);
            _sharedResources.Setup(_ => _[AppKey[0]]).Returns(localizedString2);
            _sharedResources.Setup(_ => _[BrandId[0]]).Returns(localizedString3);
            _sharedResources.Setup(_ => _[BrandName[0]]).Returns(localizedString4);
            _sharedResources.Setup(_ => _[ClientId[0]]).Returns(localizedString5);
            _sharedResources.Setup(_ => _[CompanyName[0]]).Returns(localizedString6);
            _sharedResources.Setup(_ => _[DateTimeOfChangeLog[0]]).Returns(localizedString7);
            _sharedResources.Setup(_ => _[DeleteOk[0]]).Returns(localizedString8);
            _sharedResources.Setup(_ => _[DeliverTime[0]]).Returns(localizedString9);
            _sharedResources.Setup(_ => _[DuplicateArea[0]]).Returns(localizedString10);
            _sharedResources.Setup(_ => _[DuplicateCompanyName[0]]).Returns(localizedString11);
            _sharedResources.Setup(_ => _[DuplicateContractor[0]]).Returns(localizedString12);
            _sharedResources.Setup(_ => _[DuplicateEquipment[0]]).Returns(localizedString13);
            _sharedResources.Setup(_ => _[DuplicateIndexId[0]]).Returns(localizedString14);
            _sharedResources.Setup(_ => _[DuplicateModel[0]]).Returns(localizedString15);
            _sharedResources.Setup(_ => _[DuplicatePersonnel[0]]).Returns(localizedString16);
            _sharedResources.Setup(_ => _[DuplicateRole[0]]).Returns(localizedString17);
            _sharedResources.Setup(_ => _[DuplicateSickness[0]]).Returns(localizedString18);
            _sharedResources.Setup(_ => _[DuplicateWatch[0]]).Returns(localizedString19);
            _sharedResources.Setup(_ => _[EditOk[0]]).Returns(localizedString20);
            _sharedResources.Setup(_ => _[EndDate[0]]).Returns(localizedString21);
            _sharedResources.Setup(_ => _[Exception[0]]).Returns(localizedString22);
            _sharedResources.Setup(_ => _[FillSickness[0]]).Returns(localizedString23);
            _sharedResources.Setup(_ => _[Firmware[0]]).Returns(localizedString24);
            _sharedResources.Setup(_ => _[FirmwareVersion[0]]).Returns(localizedString25);
            _sharedResources.Setup(_ => _[GatewayEUI[0]]).Returns(localizedString26);
            _sharedResources.Setup(_ => _[GatewayID[0]]).Returns(localizedString27);
            _sharedResources.Setup(_ => _[HasData[0]]).Returns(localizedString28);
            _sharedResources.Setup(_ => _[Id[0]]).Returns(localizedString29);
            _sharedResources.Setup(_ => _[IndexId[0]]).Returns(localizedString30);
            _sharedResources.Setup(_ => _[IP[0]]).Returns(localizedString31);
            _sharedResources.Setup(_ => _[IsAssignToPersonnelBefor[0]]).Returns(localizedString32);
            _sharedResources.Setup(_ => _[Item[0]]).Returns(localizedString33);
            _sharedResources.Setup(_ => _[Lat[0]]).Returns(localizedString34);
            _sharedResources.Setup(_ => _[Location[0]]).Returns(localizedString35);
            _sharedResources.Setup(_ => _[Long[0]]).Returns(localizedString36);
            _sharedResources.Setup(_ => _[LoRaDevEUI[0]]).Returns(localizedString37);
            _sharedResources.Setup(_ => _[LoRaGatewayId[0]]).Returns(localizedString38);
            _sharedResources.Setup(_ => _[LoRaGatewayModel[0]]).Returns(localizedString39);
            _sharedResources.Setup(_ => _[MACAddress[0]]).Returns(localizedString40);
            _sharedResources.Setup(_ => _[Maintenance[0]]).Returns(localizedString41);
            _sharedResources.Setup(_ => _[MaintenanceId[0]]).Returns(localizedString42);
            _sharedResources.Setup(_ => _[Model[0]]).Returns(localizedString43);
            _sharedResources.Setup(_ => _[ModelId[0]]).Returns(localizedString44);
            _sharedResources.Setup(_ => _[ModelName[0]]).Returns(localizedString45);
            _sharedResources.Setup(_ => _[MqttId[0]]).Returns(localizedString46);
            _sharedResources.Setup(_ => _[NetworkIP[0]]).Returns(localizedString47);
            _sharedResources.Setup(_ => _[NetworkKey[0]]).Returns(localizedString48);
            _sharedResources.Setup(_ => _[NoData[0]]).Returns(localizedString49);
            _sharedResources.Setup(_ => _[NotAccessForEditDevice[0]]).Returns(localizedString50);
            _sharedResources.Setup(_ => _[NotFindContractor[0]]).Returns(localizedString51);
            _sharedResources.Setup(_ => _[NotFindContractors[0]]).Returns(localizedString52);
            _sharedResources.Setup(_ => _[NotFindDate[0]]).Returns(localizedString53);
            _sharedResources.Setup(_ => _[NotFindLoRa[0]]).Returns(localizedString54);
            _sharedResources.Setup(_ => _[NotFindSickness[0]]).Returns(localizedString55);
            _sharedResources.Setup(_ => _[NotFound[0]]).Returns(localizedString56);
            _sharedResources.Setup(_ => _[NotFoundCompany[0]]).Returns(localizedString57);
            _sharedResources.Setup(_ => _[NotFoundModel[0]]).Returns(localizedString58);
            _sharedResources.Setup(_ => _[NotValidPersonnelIdInAssignWatch[0]]).Returns(localizedString59);
            _sharedResources.Setup(_ => _[NotValidWatchIdInAssignWatch[0]]).Returns(localizedString60);
            _sharedResources.Setup(_ => _[NullRoleName[0]]).Returns(localizedString61);
            _sharedResources.Setup(_ => _[Port[0]]).Returns(localizedString62);
            _sharedResources.Setup(_ => _[RegisterOk[0]]).Returns(localizedString63);
            _sharedResources.Setup(_ => _[SelectPersonnel[0]]).Returns(localizedString64);
            _sharedResources.Setup(_ => _[SerialNumber[0]]).Returns(localizedString65);
            _sharedResources.Setup(_ => _[StartDate[0]]).Returns(localizedString66);
            _sharedResources.Setup(_ => _[StatusWatch[0]]).Returns(localizedString67);
            _sharedResources.Setup(_ => _[Tenant[0]]).Returns(localizedString68);
            _sharedResources.Setup(_ => _[TextEquipmentDetails[0]]).Returns(localizedString69);
            _sharedResources.Setup(_ => _[Topic[0]]).Returns(localizedString70);
            _sharedResources.Setup(_ => _[TransactionOfWatchId[0]]).Returns(localizedString71);
            _sharedResources.Setup(_ => _[UnValidAreaCode[0]]).Returns(localizedStrin72);
            _sharedResources.Setup(_ => _[UnValidAreaId[0]]).Returns(localizedString73);
            _sharedResources.Setup(_ => _[UnValidAreaName[0]]).Returns(localizedString74);
            _sharedResources.Setup(_ => _[UnValidContractorAddress[0]]).Returns(localizedString75);
            _sharedResources.Setup(_ => _[UnValidContractorAreaIds[0]]).Returns(localizedString76);
            _sharedResources.Setup(_ => _[UnValidContractorCodeUnique[0]]).Returns(localizedString77);
            _sharedResources.Setup(_ => _[UnValidContractorId[0]]).Returns(localizedString78);
            _sharedResources.Setup(_ => _[UnValidContractorImage[0]]).Returns(localizedString79);
            _sharedResources.Setup(_ => _[UnValidContractorMobileNum[0]]).Returns(localizedString80);
            _sharedResources.Setup(_ => _[UnValidContractorName[0]]).Returns(localizedString81);
            _sharedResources.Setup(_ => _[UnValidCoordinates[0]]).Returns(localizedString82);
            _sharedResources.Setup(_ => _[UnValidPersonnelBirthday[0]]).Returns(localizedString83);
            _sharedResources.Setup(_ => _[UnValidPersonnelCode[0]]).Returns(localizedString84);
            _sharedResources.Setup(_ => _[UnValidPersonnelFamily[0]]).Returns(localizedString85);
            _sharedResources.Setup(_ => _[UnValidPersonnelId[0]]).Returns(localizedString86);
            _sharedResources.Setup(_ => _[UnValidPersonnelMobileNum[0]]).Returns(localizedString87);
            _sharedResources.Setup(_ => _[UnValidPersonnelName[0]]).Returns(localizedString88);
            _sharedResources.Setup(_ => _[UnValidPersonnelNationalCode[0]]).Returns(localizedString89);
            _sharedResources.Setup(_ => _[UnValidRequestAccess[0]]).Returns(localizedString90);
            _sharedResources.Setup(_ => _[UnValidRequestArea[0]]).Returns(localizedString91);
            _sharedResources.Setup(_ => _[UnValidRequestPeronnel[0]]).Returns(localizedString92);
            _sharedResources.Setup(_ => _[UnValidRoleId[0]]).Returns(localizedString93);

            _sharedResources.Setup(_ => _[FindResource[0]]).Returns(localizedString94);

            #endregion


        }

    }
}
