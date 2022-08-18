<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyInformationForm.aspx.cs" Inherits="HRISWebApplication.Setup.CompanyInformationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Company Information</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h4>COMPANY SETUP</h4>
            <table style="width: 100%;">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Company ID"></asp:Label>
                    </td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtCompanyID" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Company Name"></asp:Label>
                    </td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtCompanyName" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Company Address 1"></asp:Label>
                    </td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtCompanyAddress1" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Company Address 2"></asp:Label>
                    </td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtCompanyAddress2" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Company Address 3"></asp:Label>
                    </td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtCompanyAddress3" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Contact Person Address"></asp:Label>
                    </td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtContactPersonAddress" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="Contact Person Email"></asp:Label>
                    </td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtContactPersonEmail" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="Phone Number"></asp:Label>
                    </td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtPhoneNumber" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="Fax"></asp:Label>
                    </td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtFax" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text="Email"></asp:Label>
                    </td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label11" runat="server" Text="URL"></asp:Label>
                    </td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtURL" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label12" runat="server" Text="TIN"></asp:Label>
                    </td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtTIN" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label13" runat="server" Text="Reg No."></asp:Label>
                    </td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtRegNo" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label14" runat="server" Text="VAT No."></asp:Label>
                    </td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtVATNo" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label15" runat="server" Text="Insurance"></asp:Label>
                    </td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtInsurance" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Width="100px" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
