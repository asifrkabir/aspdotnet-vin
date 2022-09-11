<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OfficeLocationForm.aspx.cs" Inherits="HRISWebApplication.Setup.OfficeLocationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <webopt:bundlereference runat="server" path="~/Content/css" />
    <title>Company Information</title>

    <style>
        td{
            font-size: 20px;
        }
    </style>
</head>
<body>
    <form class="form" id="form1" runat="server">
        <div>
            <h2 class="bg-primary text-center">COMPANY SETUP</h2>
            <table style="width: 100%;">
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px;">
                        <asp:Label ID="LabelCompanySelect" runat="server" Text="Select Company"></asp:Label>
                    </td>
                    <td style="width: 10px;">:</td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" Width="300px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px;">
                        <asp:Label ID="Label1" runat="server" Text="Office Location Code"></asp:Label>
                    </td>
                    <td style="width: 10px;">:</td>
                    <td>
                        <asp:TextBox ID="txtOfficeLocationCode" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Office Location Name"></asp:Label>
                    </td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtOfficeLocationName" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Location"></asp:Label>
                    </td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtOfficeLocation" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Address 1"></asp:Label>
                    </td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtOfficeAddress1" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Address 2"></asp:Label>
                    </td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtOfficeAddress2" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Address 3"></asp:Label>
                    </td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtOfficeAddress3" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Button style="margin-right: 20px" class="btn btn-primary" ID="btnSaveOfficeLocation" runat="server" Text="Save" Width="100px" Height="30px" OnClick="btnSaveOfficeLocation_Click" />
                        <asp:Button class="btn btn-warning" ID="btnClearOfficeLocation" runat="server" Text="Clear All" Width="100px" Height="30px" OnClick="btnClearOfficeLocation_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>

            <h2 class="bg-primary text-center">ALL OFFICE LOCATIONS</h2>

            <%--<asp:GridView CssClass="table table-bordered table-condensed table-striped" ID="companyGrid" runat="server" OnRowCommand="companyGrid_RowCommand" OnRowDeleting="companyGrid_RowDeleting" OnSelectedIndexChanged="companyGrid_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ControlStyle-CssClass="btn btn-danger" ButtonType="Link" DeleteText="Delete" ShowDeleteButton="True" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:CommandField>
                    <asp:CommandField ControlStyle-CssClass="btn btn-info" ButtonType="Link" SelectText="Select" ShowSelectButton="True">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:CommandField>
                </Columns>
            </asp:GridView>--%>
        </div>
    </form>
</body>
</html>