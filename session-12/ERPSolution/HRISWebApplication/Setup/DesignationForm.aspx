<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="DesignationForm.aspx.cs" Inherits="HRISWebApplication.Setup.DesignationForm" %>

<asp:Content ID="DesignationForm" ContentPlaceHolderID="MainContent" runat="server">

    <form class="form" id="form1" runat="server">
        <div>
            <h2 class="bg-primary text-center text-light">DESIGNATION SETUP</h2>
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
                        <asp:Label ID="Label3" runat="server" Text="Section Code"></asp:Label>
                    </td>
                    <td style="width: 10px;">:</td>
                    <td>
                        <asp:DropDownList ID="SectionDDList" runat="server" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="SectionDDList_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px;">
                        <asp:Label ID="Label1" runat="server" Text="Designation Code"></asp:Label>
                    </td>
                    <td style="width: 10px;">:</td>
                    <td>
                        <asp:TextBox ID="txtDesignationCode" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Designation Name"></asp:Label>
                    </td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtDesignationName" runat="server" Width="300px"></asp:TextBox>
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
                        <asp:Button style="margin-right: 20px" class="btn btn-primary" ID="btnSaveDesignation" runat="server" Text="Save" OnClick="btnSaveDesignation_Click"  />
                        <asp:Button class="btn btn-warning" ID="btnClearDesignation" runat="server" Text="Clear All" OnClick="btnClearDesignation_Click" />
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

            <h2 class="bg-primary text-center text-light">ALL DESIGNATIONS</h2>

            <asp:GridView CssClass="table table-dark table-bordered table-condensed table-striped" ID="designationGrid" runat="server" OnRowCommand="designationGrid_RowCommand" OnRowDeleting="designationGrid_RowDeleting" OnSelectedIndexChanged="designationGrid_SelectedIndexChanged">
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

</asp:Content>