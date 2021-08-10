<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ASP.NET_CRUD.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:HiddenField ID="hfContactID" runat="server" />

            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txt_name" runat="server"></asp:TextBox>
                    </td>
                </tr>

                 <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Mobile"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txt_mobile" runat="server"></asp:TextBox>
                    </td>
                </tr>

                 <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Address"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txt_address" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        
                    </td>
                    <td colspan="2">
                        <asp:Button ID="btn_save" runat="server" Text="Save" OnClick="btn_save_Click" />
                        <asp:Button ID="btn_delete" runat="server" Text="Delete" OnClick="btn_delete_Click" />
                        <asp:Button ID="bnt_clear" runat="server" Text="Clear" OnClick="bnt_clear_Click" />
                    </td>
                </tr>

                  <tr>
                    <td>
                        
                    </td>
                    <td colspan="2">
                        
                        <asp:Label ID="lblSuccefullMessagge" runat="server" Text="" ForeColor="Blue"></asp:Label>

                    </td>
                </tr>

                  <tr>
                    <td>
                        
                    </td>
                    <td colspan="2">
                        <asp:Label ID="lblerrorMessagge" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
               

            </table>

            <br />

             <asp:GridView ID="gvContact" runat="server" AutoGenerateColumns="false">

                 <Columns>
                     <asp:BoundField DataField="Name" HeaderText="Name"/>
                      <asp:BoundField DataField="Mobile" HeaderText="Mobile"/>
                      <asp:BoundField DataField="Adress" HeaderText="Adress"/>

                     <asp:TemplateField>
                        
                         <ItemTemplate>
                                <asp:LinkButton ID="lkbutton" runat="server" CommandArgument='<%#Eval("ContacID")%>' OnClick="lbl_clickV">View</asp:LinkButton>
                        
                         </ItemTemplate>

                     </asp:TemplateField>
                     
                 </Columns>
                 
             </asp:GridView>

        </div>
    </form>
</body>
</html>
