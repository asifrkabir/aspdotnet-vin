<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SectionForm.aspx.cs" Inherits="HRISWebApplication.Setup.SectionForm" %>

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
            <h2 class="bg-primary text-center">SECTION SETUP</h2>
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
                        <asp:DropDownList ID="CompanyDDList" runat="server" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="CompanyDDList_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px;">
                        <asp:Label ID="Label6" runat="server" Text="Office Location"></asp:Label>
                    </td>
                    <td style="width: 10px;">:</td>
                    <td>
                        <asp:DropDownList ID="OfficeLocationDDList" runat="server" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="OfficeLocationDDList_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px;">
                        <asp:Label ID="Label7" runat="server" Text="Department Code"></asp:Label>
                    </td>
                    <td style="width: 10px;">:</td>
                    <td>
                        <asp:DropDownList ID="DepartmentDDList" runat="server" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="DepartmentDDList_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px;">
                        <asp:Label ID="Label1" runat="server" Text="Section Code"></asp:Label>
                    </td>
                    <td style="width: 10px;">:</td>
                    <td>
                        <asp:TextBox ID="txtSectionCode" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Section Name"></asp:Label>
                    </td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtSectionName" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Head of Section"></asp:Label>
                    </td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtHeadOfSection" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Substitute Head of Section"></asp:Label>
                    </td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtSubHeadOfSection" runat="server" Width="300px"></asp:TextBox>
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
                        <asp:Button style="margin-right: 20px" class="btn btn-primary" ID="btnSaveSection" runat="server" Text="Save" Width="100px" Height="30px" OnClick="btnSaveSection_Click"  />
                        <asp:Button class="btn btn-warning" ID="btnClearSection" runat="server" Text="Clear All" Width="100px" Height="30px" OnClick="btnClearSection_Click" />
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

            <h2 class="bg-primary text-center">ALL SECTIONS</h2>

            <asp:GridView CssClass="table table-bordered table-condensed table-striped" ID="sectionGrid" runat="server" OnRowCommand="sectionGrid_RowCommand" OnRowDeleting="sectionGrid_RowDeleting" OnSelectedIndexChanged="sectionGrid_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ControlStyle-CssClass="btn btn-danger" ButtonType="Link" DeleteText="Delete" ShowDeleteButton="True">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:CommandField>
                    <asp:CommandField ControlStyle-CssClass="btn btn-info" ButtonType="Link" SelectText="Select" ShowSelectButton="True">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:CommandField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>