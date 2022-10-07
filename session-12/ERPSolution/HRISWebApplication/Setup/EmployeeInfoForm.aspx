<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="EmployeeInfoForm.aspx.cs" Inherits="HRISWebApplication.Setup.EmployeeInfoForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%--<%@ Register TagPrefix="ew" Namespace="eWorld.UI.Compatibility" Assembly="eWorld.UI.Compatibility" %>--%>

<%--<asp:ScriptManager ID="EmployeeScriptManager" runat="server">
            </asp:ScriptManager>--%>

<asp:Content ID="EmployeeInfoForm" ContentPlaceHolderID="MainContent" runat="server">

    <form class="form" id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
        <div>
            <h2 class="bg-primary text-light text-center">EMPLOYEE SETUP</h2>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                

                <ContentTemplate>

                    <table style="width: 100%">
                        <tr>
                            <td>
                                <ajaxToolkit:TabContainer ID="TabContainer1" CssClass="MyTabStyle" Height="500px" Width="100%" runat="server" ActiveTabIndex="12">
                                    <ajaxToolkit:TabPanel ID="tabPersonalInformation" runat="server" HeaderText="Basic Information">
                                        <ContentTemplate>

                                            <table style="width: 100%;">
                                                <tr>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>Hello</td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>World</td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>.NET</td>
                                                </tr>
                                            </table>

                                        </ContentTemplate>
                                    </ajaxToolkit:TabPanel>



                                </ajaxToolkit:TabContainer>
                            </td>
                        </tr>

                    </table>

                </ContentTemplate>

                <Triggers>
                    <%--<asp:PostBackTrigger ControlID="TabContainer1$tabBasic$btnBasicInfo" />
                    <asp:PostBackTrigger ControlID="TabContainer1$tabAcademic$btnAddSingleAcademicRecord" />
                    <asp:PostBackTrigger ControlID="TabContainer1$tabAcademic$grdAcademicRecords" />
                    <asp:PostBackTrigger ControlID="TabContainer1$tabEmployeementHistory$btnAddProfessionalRecordSingle" />
                    <asp:PostBackTrigger ControlID="TabContainer1$tabPhoto$imgBtnProfileUpload" />--%>

                    <%--<asp:PostBackTrigger ControlID="TabContainer1$tabView$Button11"/>--%>

                    <%--<asp:PostBackTrigger ControlID="TabContainer1$tabAddress$btnSaveAddress" />

                    <asp:PostBackTrigger ControlID="TabContainer1$tabTraining$btnAddTrainingRecord" />
                    <asp:PostBackTrigger ControlID="TabContainer1$tabTraining$grdTrainingRecord" />
                    <asp:AsyncPostBackTrigger ControlID="TabContainer1$tabAddress$btnPrvAddress" />
                    <asp:PostBackTrigger ControlID="TabContainer1$tabReference$btnSaveRef" />
                    <asp:AsyncPostBackTrigger ControlID="TabContainer1$tabActiveEmployee$btnShow" />
                    <asp:AsyncPostBackTrigger ControlID="TabContainer1$tabActiveEmployee$btnShowActiveEmpbyID" />
                    <asp:PostBackTrigger ControlID="TabContainer1$tabPersonalInformation$btnSaveEBasic" />
                    <asp:PostBackTrigger ControlID="TabContainer1$tabBankAcc$btnSaveBankAccount" />
                    <asp:PostBackTrigger ControlID="TabContainer1$tabDependentsInformation$btnSaveDependent" />
                    <asp:PostBackTrigger ControlID="TabContainer1$tabAssetAllocation$btnSaveEAsset" />
                    <asp:PostBackTrigger ControlID="TabContainer1$tabDocumentUpload$btnUploadDoc" />


                    <asp:PostBackTrigger ControlID="TabContainer1$tabEmployeementHistory$grdProfessionalQualification" />
                    <asp:PostBackTrigger ControlID="TabContainer1$tabAssetAllocation$grdAssetAllocation" />--%>
                </Triggers>

            </asp:UpdatePanel>

            <h2 class="bg-primary text-center text-light">ALL EMPLOYEES</h2>


        </div>
    </form>
</asp:Content>
